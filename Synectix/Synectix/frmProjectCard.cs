using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using ServicesLayer;

namespace Synectix
{
    public partial class frmProjectCard : Form
    {
        Project _project;
        User _manager;
        User _implementer;
        User _editor;
        ProjectStage _stage;
        ProjectState _state;
        Dictionary<string, string> tabText = new Dictionary<string, string>(5);
        string[] btnText = { "Изменить состав", "Редакт-ть блоки", "Добавить оборуд." };

        List<FileData> listFile = new List<FileData>();
        List<FileInfo> listFileInfo = new List<FileInfo>();
        ImageList listIcon = new ImageList();
        string tempFolder = @"C:\tempFiles\";

        #region Конструктор

        public frmProjectCard(Project project)
        {
            InitializeComponent();
          
            if (!Directory.Exists(tempFolder)) Directory.CreateDirectory(tempFolder);
            if (project != null)
            {
                _project = project;
                bs_Project.DataSource = _project;
            }
            /* для тестового запуска */
            else
            {
                _project = new Project();

                _project.Id = 1;
                _project.IdEditor = 1;
                _project.IdImplementer = 6;
                _project.IdManager = 3;
                _project.IdNumber = 0;
                _project.IdStage = 2;
                _project.IdState = 1;
                _project.Version = 2;
                _project.Date = DateTime.Now;

                bs_Project.DataSource = _project;
            }

            /* проверка наличия сконфигурированных блоков */
            if (EquipServices.HasAnyBlocks(_project))
            {
                btnConfig.Text = btnText[1]; //Редактировать блоки
            }
        }

        #endregion

        #region Методы

        //исходные наименования вкладок
        void TabPagesTitleSave()
        {
            tabText.Add(tbpCurBreaker.Name, tbpCurBreaker.Text);
            tabText.Add(tbpContactor.Name, tbpContactor.Text);
            tabText.Add(tbpMotorProtect.Name, tbpMotorProtect.Text);
            tabText.Add(tbpTransformerCurrent.Name, tbpTransformerCurrent.Text);
            tabText.Add(tbpModuleCurBr.Name, tbpTransformerCurrent.Text);
        }

        //загрузка связанных источников для списка выключателей
        void CbrDataSourceLoad()
        {
            //для карточки проекта
            txtProjectNumber.Text = ProjectServices.GetProjectNumber(_project);

            //общее
            bs_EquipNote.DataSource = EquipServices.GetAllProjectNote();

            ////аналоги
            bs_CbrAn.DataSource = EquipServices.GetProjectCbr(_project, true);
            bs_AnalogEquip.DataSource = EquipServices.GetAllEquipCbr(_project, true);

            bs_cbrCCbrAn.DataSource = EquipServices.GetAllCbCur();
            bs_disCCbrAn.DataSource = EquipServices.GetAllDisCur();
            bs_disMCbrAn.DataSource = EquipServices.GetAllDisModel();
            bs_icuLCbrAn.DataSource = EquipServices.GetAllIcuLiteral();
            bs_seriaCbrAn.DataSource = EquipServices.GetAllSeria();

            //основное
            bs_CbrPrj.DataSource = EquipServices.GetProjectCbr(_project, false);
            bs_CbrEquip.DataSource = EquipServices.GetAllEquipCbr(_project, false);

            bs_cbrCCbrPrj.DataSource = EquipServices.GetAllCbCur();
            bs_disCCbrPrj.DataSource = EquipServices.GetAllDisCur();
            bs_disMCbrPrj.DataSource = EquipServices.GetAllDisModel();
            bs_icuLCbrPrj.DataSource = EquipServices.GetAllIcuLiteral();
            bs_seriaCbrPrj.DataSource = EquipServices.GetAllSeria();

            //для истории проекта
            bs_ProjectLog.DataSource = ProjectServices.GetProjectHistory(_project);
            bs_ProjectNumber.DataSource = ProjectServices.GetAllProjectNum();
            bs_ProjectStage.DataSource = ProjectServices.GetAllProjectStage();
            bs_ProjectState.DataSource = ProjectServices.GetAllProjectState();
            bs_User.DataSource = AuthServices.GetAllUser();

        }

        //обновление информации на вкладках
        void UpdateTabPageInfo()
        {
            //количество оборудования по типам (если 0, то вкладка отсутствует)
            foreach (TabPage tbp in tabControl.TabPages)
            {
                foreach (Control ctr in tbp.Controls)
                {
                    if (ctr.Name.Contains("dgvProjectEquip"))
                    {
                        DataGridView dgv = ctr as DataGridView;
                        int recordCount = dgv.RowCount;
                        if (recordCount == 0)
                        {
                            tabControl.TabPages.RemoveAt(tabControl.TabPages.IndexOf(tbp));
                        }
                        else
                        {
                            tbp.Text = tabText[tbp.Name] + " - " + recordCount.ToString();
                        }
                    }
                }
            }
        }

        #endregion

        #region События формы

        //загрузка формы
        private void frmProjectCard_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            TabPagesTitleSave();

            CbrDataSourceLoad();

            UpdateTabPageInfo();

            if (tabControl.TabPages.Count == 0)
                btnConfig.Text = btnText[2]; //Добавить оборуд.

            #region Загрузка списка файлов

            listFile = FileServices.GetList((int)_project.IdNumber);
            listViewFiles.SmallImageList = listIcon;

            for (int i = 0; i < listFile.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();                                          //создаем строку
                int j = listViewFiles.Items.Add(lvi).Index;                                     //запоминаем индекс
                Image icon = ProjectFiles.GetIcon(listFile.ElementAt(i).Extension);                //получаем иконку для файла
                listIcon.Images.Add(icon);                                                      //добавляем иконку в список изображений
                lvi.ImageIndex = listIcon.Images.Count - 1;                                     //рисуем иконку рядом с именем файла

                lvi.Text = "  " + listFile.ElementAt(i).Name;                                   //имя
                listViewFiles.Items[j].SubItems.Add(listFile.ElementAt(i).Date.ToString());     //дата изменения
                listViewFiles.Items[j].SubItems.Add(listFile.ElementAt(i).Extension);           //тип
                listViewFiles.Items[j].SubItems.Add(listFile.ElementAt(i).Size + " кб");        //размер
                listViewFiles.Items[j].SubItems.Add(listFile.ElementAt(i).Author);              //кто прикрепил
            }

            #endregion

            #region Загрузка данных карточки

            try
            {
                if (_project.IdImplementer != null)
                {
                    _implementer = AuthServices.GetUserById((int)_project.IdImplementer);
                    txtImplementer.Text = _implementer.UserName;
                }
                if (_project.IdEditor != null)
                {
                    _editor = AuthServices.GetUserById((int)_project.IdEditor);
                    txtEditor.Text = _editor.UserName;
                }

                _manager = AuthServices.GetUserById((int)_project.IdManager);
                _stage = ProjectServices.GetStageById((int)_project.IdStage);
                _state = ProjectServices.GetStateById((int)_project.IdState);

                txtManager.Text = _manager.UserName;
                txtStage.Text = _stage.Stage;
                txtState.Text = _state.State;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion

            txtManager.Focus();
        }

        //открыть файл из списка - DoubleClick на списке файлов
        private void listViewFiles_DoubleClick(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedIndices.Count > 0)
            {
                int index = listViewFiles.SelectedIndices[0];                                                 //индекс выделенного элемента

                FileData fd = FileServices.GetById(listFile.ElementAt(index).Id);                      //скачать массив байтов (данные файла) из БД               
                string filename = tempFolder + fd.Name + fd.Extension;

                FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write); //создать и записать файл на жёсткий диск клиента
                fs.Write(fd.Data, 0, fd.Data.Length);
                fs.Flush();
                fs.Close();

                Process prc = new Process();
                prc.StartInfo.FileName = filename;
                prc.Start();
                prc.Close();
            }
        }

        //удаление файла из списка - кнопкой Delete
        private void listViewFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnSave.Enabled)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (listViewFiles.SelectedIndices.Count > 0)
                    {
                        int index = listViewFiles.SelectedIndices[0];       //индекс выделенного элемента

                        if((index - listFile.Count) >= 0)
                        {
                            listViewFiles.Items.RemoveAt(index);            //удалить элемент из просмотра
                            listFileInfo.RemoveAt(index - listFile.Count);  //удалить файл из списка
                        }
                        else
                        {
                            MessageBox.Show("Нельзя удалить файлы, прикреплённые ранее", "Информация",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        //нумерация строк в списке оборудования
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        //подсвечивание ячеек со значением "нет аналога"
        private void dgvAnalogCbr_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((string)e.Value == "нет аналога")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        //одновременная прокрутка двух таблиц списка оборудования
        private void dgvProjectCbr_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Name.Contains("Analog"))
            {
                dgvAnalogEquip.FirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex;
            }
            else
                dgvProjectEquip1.FirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex;
        }

        //связанное выделение двух таблиц списка оборудования
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.SelectedRows.Count > 0)
            {
                if (!dgv.Name.Contains("Analog")) //связанное выделение таблиц основого оборудования
                {
                    if (dgv.Name.Contains("ProjectCbr"))
                    {
                        if (dgvProjectEquip1.RowCount > 0)
                        {
                            dgvProjectEquip1.CurrentCell = dgvProjectEquip1.Rows[dgv.SelectedRows[0].Index].Cells[0];
                            dgvProjectEquip1.Rows[dgv.SelectedRows[0].Index].Selected = true;
                        }
                    }
                    else if (dgv.Name.Contains("ProjectEquip"))
                    {
                        if (dgvProjectCbr.SelectedRows.Count > 0)
                        {
                            dgvProjectCbr.CurrentCell = dgvProjectCbr.Rows[dgv.SelectedRows[0].Index].Cells[0];
                            dgvProjectCbr.Rows[dgv.SelectedRows[0].Index].Selected = true;
                        }
                    }
                }
                else //связанное выделение таблиц аналогов оборудования
                {
                    if (dgv.Name.Contains("AnalogCbr"))
                    {
                        if (dgvAnalogEquip.RowCount > 0)
                        {
                            dgvAnalogEquip.CurrentCell = dgvAnalogEquip.Rows[dgv.SelectedRows[0].Index].Cells[0];
                            dgvAnalogEquip.Rows[dgv.SelectedRows[0].Index].Selected = true;
                        }
                    }
                    else if (dgv.Name.Contains("AnalogEquip"))
                    {
                        if (dgvAnalogCbr.SelectedRows.Count > 0)
                        {
                            dgvAnalogCbr.CurrentCell = dgvAnalogCbr.Rows[dgv.SelectedRows[0].Index].Cells[0];
                            dgvAnalogCbr.Rows[dgv.SelectedRows[0].Index].Selected = true;
                        }
                    }
                }
            }
        }

        //активация режима редактирования проекта
        private void btnSave_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if(tabControl.Controls.Count > 0)
            {
                foreach (DataGridView dgv in this.tabControl.SelectedTab.Controls)
                {
                    if (dgv.Name.Contains("Project") || dgv.Name.Contains("Analog"))
                    {
                        if (!btn.Enabled)
                            dgv.ColumnHeadersDefaultCellStyle.BackColor = DefaultBackColor;
                        else
                        {
                            if (dgv.Name.Contains("Project"))
                                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
                            else
                                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.MintCream;
                        }
                    }
                }
            }
        }

        //редактирование состава (списка) оборудования
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            //if (btnSave.Enabled)
            //{
            //    using (frmEquipment frm = new frmEquipment(_project, tabControl.SelectedTab.Name, 1 /* редактирование существующего списка оборудования */))
            //    {
            //        MessageBox.Show("Изменения в базе данных при редактировании списка оборудования " +
            //                        "фиксируются без подтверждения.\r\n\r\nБудьте внимательны!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            bs_CbrPrj.DataSource = EquipServices.GetProjectCbr(_project, false);
            //            bs_CbrEquip.DataSource = EquipServices.GetAllEquipCbr(_project, false);
            //            bs_CbrAn.DataSource = EquipServices.GetProjectCbr(_project, true);
            //            bs_AnalogEquip.DataSource = EquipServices.GetAllEquipCbr(_project, true);
            //            bs_EquipNote.DataSource = EquipServices.GetAllProjectNote();

            //            UpdateTabPageInfo();
            //        }
            //    }
            //}
        }

        //переключение Базовое оборудование < - > Аналоги
        private void rbtn_ChangeChecked(object sender, EventArgs e)
        {
            TabPage tbp = tabControl.SelectedTab;            
            foreach(Control ctr in tbp.Controls)
            {
                if (ctr.Name.Contains("dgv"))
                {
                    if (ctr.Name.Contains("Project")) ctr.Visible = rbtnBase.Checked;
                    else
                    {
                        ctr.Visible = rbtnAnalog.Checked;
                    }
                }
            }
        }

        //вывод истории (текст изменений) проекта
        private void dataGridViewLog_SelectionChanged(object sender, EventArgs e)
        {
            txtLog.Text = ProjectServices.GetProjectNote(bs_ProjectLog.Current as Project);
        }

        //закрытие
        private void frmProjectCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.Delete(tempFolder, true);
        }

        #endregion

        #region Кнопки

        /* [ Редактировать ] */
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = btnAttachFile.Enabled = btnConfig.Enabled = true;
            txtNote.ReadOnly = false;
        }

        /* [ Сохранить ] */
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ProjectServices.Edit(bs_Project.Current as Project, frmLogin.Instance.UserInfo))
            {
                MessageBox.Show("Изменения успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }            
            else MessageBox.Show("Произошла ошибка обновления записей базы данных", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            if (listFileInfo.Count > 0)
                ProjectFiles.Attach((int)_project.IdNumber, frmLogin.Instance.UserInfo, listFileInfo);
        }

        /* [ Прикрепить ] */
        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            openFileDlg.InitialDirectory = Directory.GetCurrentDirectory();

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                #region Отображение списка файлов на форме             
                FileInfo fi = new FileInfo(openFileDlg.FileName);
                Image icon = ProjectFiles.GetIcon(Path.GetExtension(fi.FullName));

                listIcon.Images.Add(icon);
                long fsize = fi.Length / 1024;
                if (fsize == 0) fsize = 1;
                string fileName = fi.Name.Remove(fi.Name.LastIndexOf(@"."));

                ListViewItem lvi = new ListViewItem();
                int i = listViewFiles.Items.Add(lvi).Index;
                lvi.ImageIndex = listIcon.Images.Count - 1;

                lvi.Text = "  " + fileName;                                         //имя
                listViewFiles.Items[i].SubItems.Add(fi.LastWriteTime.ToString());    //дата изменения
                listViewFiles.Items[i].SubItems.Add(fi.Extension);                   //тип
                listViewFiles.Items[i].SubItems.Add(fsize.ToString() + " кб");       //размер
                #endregion

                listFileInfo.Add(fi); //добавить в список файлов
            }
        }

        /* [ Изменить состав оборудования ] */
        private void btnConfig_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;

            if (tabControl.Controls.Count > 0)
            {
                if (bt.Text.Contains(btnText[0]))
                {
                    using (frmEquipment frm = new frmEquipment(_project, tabControl.SelectedTab.Name, 1 /* редактирование существующего списка оборудования */))
                    {
                        MessageBox.Show("Изменения в базе данных при редактировании списка оборудования " +
                                        "фиксируются без подтверждения.\r\n\r\nБудьте внимательны!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            bs_CbrPrj.DataSource = EquipServices.GetProjectCbr(_project, false);
                            bs_CbrEquip.DataSource = EquipServices.GetAllEquipCbr(_project, false);
                            bs_CbrAn.DataSource = EquipServices.GetProjectCbr(_project, true);
                            bs_AnalogEquip.DataSource = EquipServices.GetAllEquipCbr(_project, true);
                            bs_EquipNote.DataSource = EquipServices.GetAllProjectNote();

                            UpdateTabPageInfo();
                        }
                    }
                }
            }
            else if (bt.Text.Contains(btnText[2]))
            {
                this.Hide();
                this.Close();
                using (frmEquipment frm = new frmEquipment(_project, string.Empty, 0 /*создание нового списка*/))
                {
                    frm.ShowDialog();
                }
            }
        }

        /* [ История проекта < - > Закрыть ] */
        private void btnProjectLog_Click(object sender, EventArgs e)
        {
            if (!dataGridViewLog.Visible)
            {
                dataGridViewLog.Enabled = true;
                dataGridViewLog.Visible = true;

                tabControl.Visible = false;
                rbtnBase.Visible = false;
                rbtnAnalog.Visible = false;
                lblConsist.Text = "Требования / Замечания / Изменения:";
                txtLog.Visible = true;

                btnProjectLog.Text = "Закрыть";
                btnProjectLog.Image = Properties.Resources.res_close;
                btnProjectLog.Size = new Size(76,25);
                btnProjectLog.Location = new Point(856, 13);
            }
            /* [ Закрыть ] */
            else
            {
                dataGridViewLog.Visible = false;
                dataGridViewLog.Enabled = false;

                tabControl.Visible = true;
                rbtnBase.Visible = true;
                rbtnAnalog.Visible = true;
                lblConsist.Text = "Состав оборудования:";
                txtLog.Visible = false;

                btnProjectLog.Text = "&История проекта";
                btnProjectLog.Image = Properties.Resources.res_history;
                btnProjectLog.Size = new Size(120, 25);
                btnProjectLog.Location = new Point(811, 13);
            }
        }

        #endregion

    }
}
