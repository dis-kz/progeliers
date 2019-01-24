using Model;
using ServicesLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synectix
{
    public partial class frmConfigBlock : Form
    {
        ProjectCbr _currentBreaker;
        //ProjectCtr _currentTransform;

        Schema _schema;
        VerticalSize _verticalSize;
        BaseSize _height;
        BaseSize _width;
        Project _project;

        string _blockNameMask;
        string _functional;
        string[] typeEquip = { "[ Выкл-тель ] ", "[ Тр-р тока ] ", "[ Контактор ] " };
        Dictionary<int, int> dictBlockDgvRow = new Dictionary<int, int>();

        List<BlockEquipment> listBlockEquip = new List<BlockEquipment>();

        /* 
            0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 | 13 | 14 | 15 | 16 | 17 | 18 | 19 |
            ------------------------------------------------------------------------------------------
            Б | М | В | х | - | 1 | 6 | . | 1 | 5 | -  | 1  | H  | .  | 2  | -  | 0  | 0  | 1  | A  |
        */

        #region Конструктор

        public frmConfigBlock(Project project)
        {
            InitializeComponent();

            //подбор без привязки к проекту
            if (project == null)
            {
                _project = new Project();
                _project.IdNumber = 0;
                _project.Date = DateTime.Now;
            }
            //привязка к проекту
            else
            {
                _project = project;
            }
        }

        #endregion

        #region Методы

        //формирование строки наименования блока
        private string BuildBlockName(string text, int start, string subString)
        {
            char[] source = text.ToCharArray();         //исходный текст
            char[] insert = subString.ToCharArray();    //подстрока для замены

            for (int i = 0; i < insert.Length; i++)
            {
                source[i + start] = insert[i];
            }
            return text = new string(source);
        }

        //возвращение формы в исходное состояние
        private void ResetForm(string mode)
        {
            if (!mode.Contains("cbrDelete"))
            {
                foreach (Control ctr in this.Controls)
                {
                    if (ctr.GetType() == typeof(ComboBox))
                    {
                        ctr.ResetText();
                    }
                }

                listBlockEquip.Clear();
                lbxBlockEquip.Items.Clear();
                rbtnGeneral.Checked = true;
                btnNext.Enabled = false;

                txtResult.Text = _blockNameMask;
                txtResult.ForeColor = Color.Black;
            }
            else
            {
                cboSize.ResetText();
                cboShema.ResetText();

                txtResult.Text = BuildBlockName(txtResult.Text, 16, "XXX");
                txtResult.Text = BuildBlockName(txtResult.Text, 11, "XX");
                txtResult.Text = BuildBlockName(txtResult.Text, 14, "X");
                txtResult.Text = BuildBlockName(txtResult.Text, 19, "X");
            }

            panelBlock.BackColor = Color.WhiteSmoke;
            cboSize.Enabled = false;
            cboShema.Enabled = false;
            txtFeeder.Text = "";
        }

        #endregion

        #region События

        //загрузка формы
        private void frmConfigurator_Load(object sender, EventArgs e)
        {
            using (frmInputBox frm = new frmInputBox(1 /*введите номер проекта*/))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    Project pr = ProjectServices.GetByNumber(frm.GetTxtValue);

                    if (pr != null)
                        _project = pr;
                }
            }

            rbtnGeneral.Checked = true;
            _blockNameMask = txtResult.Text;

            bs_ProjectCbr.DataSource = ConfigServices.GetProjectCbr(_project, false);

            bs_cbrCCbrPrj.DataSource = EquipServices.GetAllCbCur();
            bs_disCCbrPrj.DataSource = EquipServices.GetAllDisCur();
            bs_disMCbrPrj.DataSource = EquipServices.GetAllDisModel();
            bs_icuLCbrPrj.DataSource = EquipServices.GetAllIcuLiteral();
            bs_seriaCbrPrj.DataSource = EquipServices.GetAllSeria();

            bs_Schema.DataSource = ConfigServices.GetAllSchema();
            bs_BaseHeight.DataSource = ConfigServices.GetBaseSizes("H");
            bs_BaseWidth.DataSource = ConfigServices.GetBaseSizes("B");

            foreach (Control ctr in this.Controls)
            {
                if (ctr.GetType() == typeof(ComboBox))
                {
                    ctr.ResetText();
                }
            }

            if (_project.IdNumber != 0)
                tsProjectNumber.Text = ProjectServices.GetProjectNumber(_project);
            else
                tsProjectNumber.Text = "тестовый проект";
        }

        //выбор элемента для переноса
        private void dgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            _currentBreaker = bs_ProjectCbr.Current as ProjectCbr;
            _currentBreaker.Title = ConfigServices.GetCbrTitle(bs_ProjectCbr.Current as ProjectCbr);

            dgvProjectCbr.DoDragDrop(_currentBreaker.Title, DragDropEffects.Copy);
        }

        //переносимый элемент в области списка
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //добавление элемента DragDrop
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            lbxBlockEquip.Items.Add((lbxBlockEquip.Items.Count+1) + "." + typeEquip[0] + e.Data.GetData(DataFormats.Text));
            object data = e.Data.GetData(DataFormats.StringFormat);

            #region Оборудование
            if(_currentBreaker != null)
            {
                #region /*связанные трансфмораторы тока*/
                foreach (ProjectCtr pctr in ConfigServices.GetBindedCurTrans(_currentBreaker))
                {
                    pctr.Title = ConfigServices.GetCtrTitile(pctr);
                    listBlockEquip.Add(new BlockEquipment() { IdEquip = pctr.IdProjectEquip, TypeEquip = typeEquip[1], Title = pctr.Title });
                    lbxBlockEquip.Items.Add((lbxBlockEquip.Items.Count + 1) + "." + typeEquip[1] + pctr.Title);
                }
                #endregion

                #region /*связанный контактор*/
                ProjectCnt pcnt = ConfigServices.GetBindedCont(_currentBreaker); 
                if ( pcnt != null)
                {
                    pcnt.Title = ConfigServices.GetCntTitle(pcnt);
                    if (pcnt.Title.Contains("нет"))
                        pcnt.Title = pcnt.Title.Replace("+ реле нет", "");
                    listBlockEquip.Add(new BlockEquipment() { IdEquip = pcnt.IdProjectEquip, TypeEquip = typeEquip[2], Title = pcnt.Title });
                    lbxBlockEquip.Items.Add((lbxBlockEquip.Items.Count + 1) + "." + typeEquip[2] + pcnt.Title);
                }
                #endregion

                listBlockEquip.Add(new BlockEquipment() { IdEquip = _currentBreaker.IdProjectEquip, TypeEquip = typeEquip[0], Title = _currentBreaker.Title });
            }
            #endregion

            txtResult.Text = BuildBlockName(txtResult.Text, 19, ConfigServices.GetManufLiter(_currentBreaker));
            txtFeeder.Text = _currentBreaker.ConNum; //наименование присоединения

            dgvProjectCbr.Rows.Remove(dgvProjectCbr.SelectedRows[0]); //убрать из списка добавленный автомат
            cboShema.Enabled = true;
        }

        //выбор схемы
        private void cboShema_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _schema = cboShema.SelectedItem as Schema;
            txtResult.Text = BuildBlockName(txtResult.Text, 16, _schema.Indexx);

            if (_currentBreaker != null)
            {
                cboSize.Enabled = true;
                cboSize.DataSource = ConfigServices.GetAllVertSizes(_currentBreaker, _schema);
                cboSize.ValueMember = "Id";
                cboSize.DisplayMember = "SizeName";
                cboSize.ResetText();
            }
        }

        //выбор вертикального размера
        private void cboSize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _verticalSize = cboSize.SelectedItem as VerticalSize;

            txtResult.Text = BuildBlockName(txtResult.Text, 11, _verticalSize.SizeName.Substring(0, 2)); //1H - целая часть верт.размера
            txtResult.Text = BuildBlockName(txtResult.Text, 14, _verticalSize.SizeName.Substring(2)); //.1 - дробная часть верт.размера

        }

        //выбор базовых размеров
        private void cboBaseH_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _height = cboBaseH.SelectedItem as BaseSize; //высота
            txtResult.Text = BuildBlockName(txtResult.Text, 5, _height.Value.Substring(0, 2));
        }
        private void cboBaseB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _width = cboBaseB.SelectedItem as BaseSize; //ширина
            txtResult.Text = BuildBlockName(txtResult.Text, 8, _width.Value.Substring(0, 2));
        }

        //удаление ошибочно добавленного выключателя
        private void listBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lbxBlockEquip.SelectedItem.ToString().Contains(typeEquip[0] /*выключатель*/))
                {
                    bs_ProjectCbr.DataSource = ConfigServices.GetProjectCbr(_project, false);
                    ResetForm("cbrDelete");
                }
                listBlockEquip.RemoveAt(lbxBlockEquip.SelectedIndex);
                lbxBlockEquip.Items.Remove(lbxBlockEquip.SelectedItem);
                if(lbxBlockEquip.Items.Count > 0)
                    lbxBlockEquip.SetSelected(lbxBlockEquip.Items.Count - 1, true);
            }
        }

        //полное наименование выдвижного блока
        private void txtResult_TextChanged(object sender, EventArgs e)
        {
            if (!txtResult.Text.Contains("X"))
            {
                txtResult.ForeColor = Color.FromArgb(155, 36, 24);
                panelBlock.BackColor = Color.FromArgb(189, 217, 242);

                /* ---- YES!---- */
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.res_sound_yes);
                player.Play();
                /* ------------ */

                btnNext.Enabled = true;
            }
        }

        //нумерация строк в DataGridView
        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                e.Value = e.RowIndex + 1;
            }
        }

        #endregion

        #region Кнопки

        /* [ Добавить ] */
        private void btnNext_Click(object sender, EventArgs e)
        {
            int[] blockParams = { _height.Id, _width.Id, _verticalSize.Id, _schema.Id, (int)_project.IdNumber };

            int idBlock = ConfigServices.InsertBlock(txtResult.Text, _functional, blockParams, listBlockEquip);

            if (idBlock > 0)
            {
                MessageBox.Show("Блок успешно добавлен в проект", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tsBlockCount.Text = ConfigServices.BlockCount(_project).ToString();

                dictBlockDgvRow.Add(dgvProjectBlock.Rows.Add("", txtFeeder.Text, txtResult.Text, ""), idBlock);
                tsBlockCount.Text = dgvProjectBlock.Rows.Count.ToString();

                ResetForm(string.Empty);
            }
            else
            {
                MessageBox.Show("Ошибка добавления записи в базу данных.\n\r" +
                                "Обратитесь в техническую поддержку");
            }
        }

        /* [ Радио-кнопки ] */
        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;

            if (rbtn.Checked)
            {
                if (rbtn.Name.Contains("MCC"))
                    _functional = "м";
                else
                    _functional = "п";
            }

            txtResult.Text = BuildBlockName(txtResult.Text, 3, _functional);
        }

        #endregion

        //состав блока в отдельном окне
        private void dgvProjectBlock_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if(dgv.Rows.Count > 0)
            {
                int idBlock = dictBlockDgvRow[dgv.SelectedRows[0].Index];
                string conNUm = dgv.SelectedRows[0].Cells[1].Value.ToString();
                string titleBlock = dgv.SelectedRows[0].Cells[2].Value.ToString();

                using (frmBlock frm = new frmBlock(titleBlock, conNUm, idBlock))
                {
                    frm.ShowDialog();
                }
            }
        }
    }
}
