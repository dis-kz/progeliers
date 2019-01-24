using Model;
using ServicesLayer;
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
    public partial class frmEquipment : Form
    {
        #region Поля данных формы
        int _mode;
        /* 0 - создание нового списка оборудования
         * 1 - редактирование существующего списка
         * 2 - редактирование списка оборудования в выдвижном блоке */

        //для вкладки "Выключатели"
        Manufacturer manufacturer;
        DisCurrent disCurrent;
        CbCurrent cbCurrent;
        IcuValue icuValue;
        DisType disType;
        DisModel disModel;
        Project _project;

        //для вкладки "Защита двигателя"
        NumericParam motorPowerMtPr;
        StringParam hasRelayMtPr;
        StringParam coordTypeMtPr;
        StringParam coilMtPr;

        //для вкладки "Пускорегулирующая аппаратура
        NumericParam contCurCont;
        StringParam coordTypeCont;
        StringParam coilCont;

        #endregion

        #region Конструктор

        public frmEquipment(Project project, string tabPageName, int mode)
        {
            InitializeComponent();
            foreach (TabPage tbp in this.tabControl.TabPages)
            {
                //если нужно открыть конкретную вкладку
                if (tbp.Name == tabPageName)
                {
                    tabControl.SelectedTab = tbp;
                }
            }
            //подбор без привязки к проекту
            if (project == null)
            {
                _project = new Project();
                _project.IdNumber = 0;
                _project.Date = DateTime.Now;
                bs_Project.DataSource = _project;
            }
            //привязка к проекту
            else
            {
                _project = project;
                bs_Project.DataSource = _project;
            }
            _mode = mode;
        }

        #endregion

        #region Методы

        //отрисовка формы в режиме редактирования состава оборудования
        private void LoadFormInEditMode()
        {
            //foreach (TabPage tbp in tabControl.TabPages)
            //{
            //    if (!tbp.Name.Equals(tabControl.SelectedTab.Name))
            //        tabControl.TabPages.Remove(tbp);
            //}
            bs_CbrPrj.DataSource = EquipServices.GetProjectCbr(_project, false);
            bs_CbrEquip.DataSource = EquipServices.GetAllEquipCbr(_project, false);
            bs_EquipNote.DataSource = EquipServices.GetAllProjectNote();

            bs_AnalogEquip.DataSource = EquipServices.GetAllEquipCbr(_project, true);
            bs_CbrAn.DataSource = EquipServices.GetProjectCbr(_project, true);

            itemReplaceInProject.Visible = true;
            this.Text = "Редактирование состава обоорудования";
            this.btnAnalog.Enabled = true;
            tsAnalogText.Text = "Кол-во аналогов: ";
            tsAnalogCount.Text = bs_AnalogEquip.Count.ToString();
        }

        //загрузка источников для Current Breaker
        private void CbrDataSourceLoad()
        {
            //источники для таблицы поиска
            bs_manfCbr.DataSource = EquipServices.GetAllManuf();
            bs_disCCbr.DataSource = EquipServices.GetAllDisCur();
            bs_cbrCCbr.DataSource = EquipServices.GetAllCbCur();
            bs_icuVCbr.DataSource = EquipServices.GetAllIcu();
            bs_icuLCbr.DataSource = EquipServices.GetAllIcuLiteral();
            bs_disTCbr.DataSource = EquipServices.GetAllDisType();
            bs_disMCbr.DataSource = EquipServices.GetAllDisModel();
            bs_seriaCbr.DataSource = EquipServices.GetAllSeria();
            bs_poleCbr.DataSource = EquipServices.GetAllPoleNumber();
            bs_voltCbr.DataSource = EquipServices.GetAllVoltage();

            //источники для таблицы выбранных
            bs_manfCbrPrj.DataSource = EquipServices.GetAllManuf();
            bs_disCCbrPrj.DataSource = EquipServices.GetAllDisCur();
            bs_cbrCCbrPrj.DataSource = EquipServices.GetAllCbCur();
            bs_icuVCbrPrj.DataSource = EquipServices.GetAllIcu();
            bs_icuLCbrPrj.DataSource = EquipServices.GetAllIcuLiteral();
            bs_disTCbrPrj.DataSource = EquipServices.GetAllDisType();
            bs_disMCbrPrj.DataSource = EquipServices.GetAllDisModel();
            bs_seriaCbrPrj.DataSource = EquipServices.GetAllSeria();
            bs_poleCbrPrj.DataSource = EquipServices.GetAllPoleNumber();
            bs_voltCbrPrj.DataSource = EquipServices.GetAllVoltage();

            //источники для аналогов
            bs_manfCbrAn.DataSource = EquipServices.GetAllManuf();
            bs_disCCbrAn.DataSource = EquipServices.GetAllDisCur();
            bs_cbrCCbrAn.DataSource = EquipServices.GetAllCbCur();
            bs_icuVCbrAn.DataSource = EquipServices.GetAllIcu();
            bs_icuLCbrAn.DataSource = EquipServices.GetAllIcuLiteral();
            bs_disTCbrAn.DataSource = EquipServices.GetAllDisType();
            bs_disMCbrAn.DataSource = EquipServices.GetAllDisModel();
            bs_seriaCbrAn.DataSource = EquipServices.GetAllSeria();
            bs_poleCbrAn.DataSource = EquipServices.GetAllPoleNumber();
            bs_voltCbrAn.DataSource = EquipServices.GetAllVoltage();

            //номер проекта
            bs_ProjectNum.DataSource = ProjectServices.GetAllProjectNum();

            //обозначения выключателей
            bs_EquipNote.DataSource = EquipServices.GetAllProjectNote();

            ComboResetText(gbxFilterCbr);
        }

        //загрузка источников для MotorProtect
        private void MtPrDataSourceLoad()
        {
            bs_mtPowMtPr.DataSource = EquipServices.GetAllMotorPow();
            bs_mtCurMtPr.DataSource = EquipServices.GetAllMotorCur();
            bs_contCurMtPr.DataSource = EquipServices.GetAllContCur();
            bs_relayMtPr.DataSource = EquipServices.GetHasRealy();
            bs_coilMtPr.DataSource = EquipServices.GetCoilType();
            bs_typeMtPr.DataSource = EquipServices.GetCoordType();
            bs_manfMtPr.DataSource = EquipServices.GetAllManuf();
            bs_seriaMtPr.DataSource = EquipServices.GetAllSeria();
            bs_CbrMtPr.DataSource = EquipServices.GetAllCbr();

            ComboResetText(gbxFilterMtPr);
        }

        //загрузка источников для Contactor
        private void ContDataSourceLoad()
        {
            bs_manfCont.DataSource = EquipServices.GetAllManuf();
            bs_seriaCont.DataSource = EquipServices.GetAllSeria();
            bs_contCurCont.DataSource = EquipServices.GetAllContCur();
            bs_coilCont.DataSource = EquipServices.GetCoilType();
            bs_coordTypeCont.DataSource = EquipServices.GetCoordType();

            ComboResetText(gbxFilterCont);
        }

        //поиск выключателей в базе
        private void SearchCbr(DataGridViewColumn dgvCol)
        {            
            object[] filters = new object[6]; //формирование фильтра
            if (manufacturer != null) filters[0] = manufacturer.Id;
            if (disCurrent != null) filters[1] = disCurrent.Id;
            if (cbCurrent != null) filters[2] = cbCurrent.Id;
            if (icuValue != null) filters[3] = icuValue.Id;
            if (disType != null) filters[4] = disType.Id;
            if (disModel != null) filters[5] = disModel.Id;
           
            bs_Cbr.DataSource = EquipServices.GetCbrByParams(filters); //найти с указанным фильтром

            if (dgvCol != null) dgvCol.DefaultCellStyle.BackColor = Color.FromArgb(253, 255, 216 /*светло-жёлтый*/); //выделить цветом
        }

        //Вывод списка аналогов
        void AnalogDataSourceLoad(Color color, string count)
        {
            bs_AnalogEquip.DataSource = EquipServices.GetAllEquipCbr(_project, true);
            bs_CbrAn.DataSource = EquipServices.GetProjectCbr(_project, true);

            btnAnalog.Enabled = true;
            tsAnalogCount.ForeColor = color;

            if (String.IsNullOrEmpty(count))
                bs_CbrAn.Count.ToString();
            else
                tsAnalogCount.Text = count;

        }

        //поиск контакторов в базе
        private void SearchContByParams(DataGridViewColumn dgvCol)
        {
            TabPage activeTab = tabControl.SelectedTab;
            object[] filters = new object[5]; //формирование фильтра

            if (activeTab.Name.Contains("Motor"))
            {
                if (motorPowerMtPr != null) filters[0] = motorPowerMtPr.Id;
                if (hasRelayMtPr != null) filters[1] = hasRelayMtPr.Id;
                if (coordTypeMtPr != null) filters[2] = coordTypeMtPr.Id;
                if (coilMtPr != null) filters[3] = coilMtPr.Id;

                bs_MtPr.DataSource = EquipServices.GetContByParams(filters);
            }
            else if (activeTab.Name.Contains("Contactor"))
            {
                if (coordTypeCont != null) filters[2] = coordTypeCont.Id;
                if (coilCont != null) filters[3] = coilCont.Id;
                if (contCurCont != null) filters[4] = contCurCont.Id;

                bs_Cont.DataSource = EquipServices.GetContByParams(filters);

            }
            if (dgvCol != null) dgvCol.DefaultCellStyle.BackColor = Color.FromArgb(253, 255, 216 /*светло-жёлтый*/); //выделить цветом
        }

        //очистка текста "по умолчанию" в comboBox
        private void ComboResetText(GroupBox gbx)
        {
            foreach (Control ctr in gbx.Controls)
            {
                if (ctr.GetType() == typeof(ComboBox))
                {
                    ctr.ResetText();
                }
            }
        }

        //удаление оборудования из проекта
        public static void RemoveFromProject(BindingSource bsBase, BindingSource bsAnalog, Project probject)
        {
            if (bsBase != null)
            {
                bsAnalog.DataSource = EquipServices.DisattachAnalog(bsBase.Current as ProjectEquipment, probject, false); //связанные аналоги
                bsBase.DataSource = EquipServices.DisattachBase(bsBase.Current as ProjectEquipment, probject); //базовые
            }
            else
            {
                bsAnalog.DataSource = EquipServices.DisattachAnalog(bsAnalog.Current as ProjectEquipment, probject, true); ; //только аналоги
            }
        }

        #endregion

        #region События

        //загрузка формы
        private void frmEquipment_Load(object sender, EventArgs e)
        {
            if(_mode == 1 /* редактирование существующего списка */)
            {
                LoadFormInEditMode();
            }

            CbrDataSourceLoad();  //выключатели
            ContDataSourceLoad(); //контакторы
            MtPrDataSourceLoad(); //защита двигателя

            if (_project.IdNumber != 0)
                tsProjectNumber.Text = ProjectServices.GetProjectNumber(_project);
            else
                tsProjectNumber.Text = "Подбор оборудования";
        }

        //закрытие формы
        private void frmEquipment_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            EquipServices.RemoveTemp(EquipServices.GetAllTempEquip());
        }

        //нажатие клавиш в области dataGridViewProject
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Name.Contains("Project"))
            {
                if (e.KeyCode == Keys.Delete) //удалить
                {
                    RemoveFromProject(bs_CbrEquip, bs_AnalogEquip, _project);

                    bs_CbrPrj.DataSource = EquipServices.GetProjectCbr(_project, false);
                    bs_CbrAn.DataSource = EquipServices.GetProjectCbr(_project, true);
                    tsAnalogCount.Text = "0";
                }
                if(e.KeyCode == Keys.F2)
                {
                    itemEdit_Project.PerformClick();
                }
            }
            else if (dgv.Name.Contains("Analog"))
            {
                if (e.KeyCode == Keys.Delete) //удалить
                {
                    RemoveFromProject(null, bs_AnalogEquip, _project);
                    bs_CbrAn.DataSource = EquipServices.GetProjectCbr(_project, true);
                }
            }

        }

        //активация вкладки tabControl
        private void tbp_Enter(object sender, EventArgs e)
        {
            TabPage tbp = sender as TabPage;

            foreach(Control ctr in tbp.Controls)
            {
                if (ctr.Name.Contains("gbx"))
                {
                    ComboResetText((GroupBox)ctr);
                }
            }
        }

        //нумерация строк в datagridView
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
            if (e.ColumnIndex == 1)
            {
                if ((string)e.Value == "нет аналога")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
        }

        //связанное выделение таблиц dataGridView
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if(dgv.SelectedRows.Count > 0)
            {
                if (!dgv.Name.Contains("Analog")) //связанное выделение таблиц основого оборудования
                {
                    if (dgv.Name.Contains("ProjectCbr"))
                    {
                        if (dgvProjectEquip.RowCount > 0)
                        {
                            dgvProjectEquip.CurrentCell = dgvProjectEquip.Rows[dgv.SelectedRows[0].Index].Cells[0];
                            dgvProjectEquip.Rows[dgv.SelectedRows[0].Index].Selected = true;
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

        //прокрутка связанных таблиц
        private void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Name.Contains("Analog"))
            {
                dgvAnalogEquip.FirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex;
            }
            else
                dgvProjectEquip.FirstDisplayedScrollingRowIndex = dgv.FirstDisplayedScrollingRowIndex;
        }

        #endregion

        #region Кнопки

        #region /*   Выключатели   */

        /* [ Отчёт ] */
        private void btnReport_Click(object sender, EventArgs e)
        {
            using (frmReport frm = new frmReport(_project as Project))
            {
                frm.ShowDialog();
            }
        }

        /* [ Показать | Скрыть аналоги ] */
        private void btnAnalog_Click(object sender, EventArgs e)
        {
            if (!dgvAnalogCbr.Visible)
            {
                dgvAnalogCbr.Visible = dgvAnalogEquip.Visible = true;

                dataGridViewCbrSearch.Visible = false;
                btnAnalog.Text = "Скрыть аналоги";
                btnAnalog.Image = Properties.Resources.res_hide;
                lbResult.Text = "Аналоги:";
            }
            else
            {
                dgvAnalogCbr.Visible = dgvAnalogEquip.Visible = false;

                dataGridViewCbrSearch.Visible = true;
                btnAnalog.Text = "Показать аналоги";
                btnAnalog.Image = Properties.Resources.res_show;
                lbResult.Text = "Результат поиска:";
            }
        }

        /* [ Очистить все ] */
        private void btnCbrClear_Click(object sender, EventArgs e)
        {
            CbrDataSourceLoad();
            cboCbrDisModel.Enabled = false;

            foreach (DataGridViewColumn column in dataGridViewCbrSearch.Columns)
            {
                column.DefaultCellStyle.BackColor = Color.White;
            }

            manufacturer = null;
            disCurrent = null;
            cbCurrent = null;
            icuValue = null;
            disType = null;
            disModel = null;

            SearchCbr(null);

            foreach (Control ctr in gbxFilterCbr.Controls)
            {
                if (ctr.GetType() == typeof(ComboBox))
                {
                    ctr.ResetText();
                }
            }
        }

        #endregion

        #region/*  Защита двигателя  */

        /* [ Очистить все ] */

        private void btnMtPrClear_Click(object sender, EventArgs e)
        {
            MtPrDataSourceLoad();

            foreach (DataGridViewColumn column in dataGridViewMtPr.Columns)
            {
                column.DefaultCellStyle.BackColor = Color.White;
            }

            motorPowerMtPr = null;
            hasRelayMtPr = null;
            coordTypeMtPr = null;
            coilMtPr = null;

            SearchContByParams(null);

            foreach (Control ctr in gbxFilterMtPr.Controls)
            {
                if (ctr.GetType() == typeof(ComboBox))
                {
                    ctr.ResetText();
                }
            }
        }

        #endregion

        #region /* Пускорегулирующая аппаратура */

        private void btnContClear_Click(object sender, EventArgs e)
        {
            //MtPrDataSourceLoad();

            foreach (DataGridViewColumn column in dataGridViewCont.Columns)
            {
                column.DefaultCellStyle.BackColor = Color.White;
            }

            contCurCont = null;
            coordTypeCont = null;
            coilCont = null;

            SearchContByParams(null);

            foreach (Control ctr in gbxFilterCont.Controls)
            {
                if (ctr.GetType() == typeof(ComboBox))
                {
                    ctr.ResetText();
                }
            }
        }

        #endregion

        #endregion

        #region Контекстные меню 
        //Редактировать (наименование присоединения)
        private void itemEdit_Click(object sender, EventArgs e)
        {
            using (frmInputBox frm = new frmInputBox(_project, 1 /*добавление или редактирование*/))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    bs_EquipNote.DataSource = EquipServices.UpdateTable(bs_CbrEquip.Current as ProjectEquipment, frm.GetTxtValue);
                    bs_CbrEquip.DataSource = EquipServices.GetAllEquipCbr(_project, false);
                    bs_AnalogEquip.DataSource = EquipServices.GetAllEquipCbr(_project, true);
                }
            }
        }

        //Добавить в проект
        private void itemAdd_Click(object sender, EventArgs e)
        {
            string _connectionNumber;

            using (frmInputBox frm = new frmInputBox(_project, 1 /*добавление или редактирование*/))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    _connectionNumber = frm.GetTxtValue;

                    switch (tabControl.SelectedTab.Name)
                    {
                        case "tbpCurBreaker":
                            InsertCbr(_connectionNumber);
                            break;

                        case "tbpContactor":
                            break;

                        case "tbpMotorProtect":
                            break;

                        case "tbpTransformerCurrent":
                            break;

                        case "tbpModulCurBr":
                            break;

                        default:
                            break;
                    }
                }
                else return;
            }
        }

        //Заменить в проекте
        private void itemReplace_Click(object sender, EventArgs e)
        {
            string connectionNumber;

            using (frmInputBox frm = new frmInputBox(_project, 2 /*замена*/))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    connectionNumber = frm.GetTxtValue;
                    ProjectEquipment pe = EquipServices.ReplaceProjectCbr(_project, connectionNumber, bs_Cbr.Current as CurrentBreaker);

                    bs_CbrPrj.DataSource = EquipServices.GetProjectCbr(_project, false);

                    if (EquipServices.GetCbrAnalog(pe, bs_Cbr.Current as CurrentBreaker))
                    {
                        AnalogDataSourceLoad(DefaultForeColor, bs_CbrAn.Count.ToString());
                    }
                    else
                    {
                        AnalogDataSourceLoad(Color.Red, "не найдено");
                    }
                }
                else return;
            }
        }
        #endregion

        #region Поиск по критериям

        #region /*   Выключатели   */

        //производитель
        private void cboCbrManufact_SelectionChangeCommitted(object sender, EventArgs e)
        {
            manufacturer = cboCbrManufact.SelectedItem as Manufacturer;

            if (manufacturer != null)
            {
                SearchCbr(dgvcCmbManf);
                bs_disCCbr.DataSource = EquipServices.GetAllDisCur(manufacturer.Id);
                cboCbrDisCur.ResetText();
                cboCbrDisModel.Enabled = true;

                if (disType != null)
                {
                    bs_disMCbr.DataSource = EquipServices.GetAllDisModel(manufacturer.Id, disType.Id);
                    cboCbrDisModel.ResetText();
                }
                else
                {
                    bs_disMCbr.DataSource = EquipServices.GetAllDisModel(manufacturer.Id);
                    cboCbrDisModel.ResetText();
                }
            }
        }

        //ток расцепителя
        private void cboCbrDisCur_SelectionChangeCommitted(object sender, EventArgs e)
        {
            disCurrent = cboCbrDisCur.SelectedItem as DisCurrent;

            if (disCurrent != null)
            {
                SearchCbr(dgvcCmbDisCur);
                bs_cbrCCbr.DataSource = EquipServices.GetAllCbCur(disCurrent.Id);
                bs_disTCbr.DataSource = EquipServices.GetAllDisType(disCurrent.Id);
                cboCbrCbCur.ResetText();
                cboCbrDisType.ResetText();
            }
        }

        //ток выключателя
        private void cboCbrCbCur_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbCurrent = cboCbrCbCur.SelectedItem as CbCurrent;

            if (cbCurrent != null)
            {
                SearchCbr(dgvcCmbCbCur);
                bs_icuVCbr.DataSource = EquipServices.GetAllIcu(cbCurrent.Id);
                cboCbrIcu.ResetText();
            }
        }

        //отключающая способность
        private void cboCbrIcu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            icuValue = cboCbrIcu.SelectedItem as IcuValue;

            if (icuValue != null)
            {
                SearchCbr(dgvcCmbIcuVal);
            }
        }

        //тип расцепителя
        private void cboCbrDisType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            disType = cboCbrDisType.SelectedItem as DisType;

            if (disType != null)
            {
                SearchCbr(dgvcCmbDisTyp);
            }
            if (manufacturer != null)
            {
                bs_disMCbr.DataSource = EquipServices.GetAllDisModel(manufacturer.Id, disType.Id);
                cboCbrDisModel.ResetText();
            }
        }

        //модель расцепителя
        private void cboCbrDisModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            disModel = cboCbrDisModel.SelectedItem as DisModel;
            if (disModel != null)
            {
                SearchCbr(dgvcCmbDisMod);
            }
        }

        #endregion

        #region /*  Защита двигателя  */

        //мощность двигателя
        private void cboMtPrPower_SelectionChangeCommitted(object sender, EventArgs e)
        {
            motorPowerMtPr = cboMtPrPower.SelectedItem as NumericParam;
            SearchContByParams(dgvcCmbPowMtPr);
        }

        //наличие теплового реле
        private void cboMtPrRelay_SelectionChangeCommitted(object sender, EventArgs e)
        {
            hasRelayMtPr = cboMtPrRelay.SelectedItem as StringParam;
            SearchContByParams(dgvcCmbRelayMtPr);
        }

        //тип координации
        private void cboMtPrType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            coordTypeMtPr = cboMtPrType.SelectedItem as StringParam;
            SearchContByParams(dgvcCmbTypeCordMtPr);
        }

        //ток управления
        private void cboMtPrCoil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            coilMtPr = cboCoilMtPr.SelectedItem as StringParam;
            SearchContByParams(dgvcCmbCoilMtPr);
        }

        #endregion

        #region /* Пускорегулирующая аппаратура */

        //номинальный ток контактора
        private void cboContCur_SelectionChangeCommitted(object sender, EventArgs e)
        {
            contCurCont = cboContCur.SelectedItem as NumericParam;
            SearchContByParams(dgvcCmbCurCont);
        }
        //тип координации
        private void cboContType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            coordTypeCont = cboCoordTypeCont.SelectedItem as StringParam;
            SearchContByParams(dgvcCmbCoordTypeCont);
        }
        //ток управления
        private void cboContCoil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            coilCont = cboCoilCont.SelectedItem as StringParam;
            SearchContByParams(dgvcCmbCoilCont);
        }

        #endregion

        #endregion

        #region Очистка критериев поиска

        #region /*   Выключатели   */

        //производитель
        private void pbxClearManuf_Click(object sender, EventArgs e)
        {
            dgvcCmbManf.DefaultCellStyle.BackColor = Color.White;
            bs_manfCbr.DataSource = EquipServices.GetAllManuf();

            manufacturer = null;
            disModel = null;
            bs_disMCbr.DataSource = EquipServices.GetAllDisModel();
            cboCbrDisModel.ResetText();
            cboCbrDisModel.Enabled = false;
            cboCbrManufact.ResetText();

            if (disCurrent == null)
            {
                bs_disCCbr.DataSource = EquipServices.GetAllDisCur();
                cboCbrDisCur.ResetText();
            }
            SearchCbr(null);
        }

        //ток расцепителя
        private void pbxClearDisCur_Click(object sender, EventArgs e)
        {
            dgvcCmbDisCur.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            if (manufacturer == null) bs_disCCbr.DataSource = EquipServices.GetAllDisCur();

            disCurrent = null;
            cboCbrDisCur.ResetText();

            if (cbCurrent == null)
            {
                bs_cbrCCbr.DataSource = EquipServices.GetAllCbCur();
                cboCbrCbCur.ResetText();
            }
            if (disType == null)
            {
                bs_disTCbr.DataSource = EquipServices.GetAllDisType();
                cboCbrDisType.ResetText();
            }
            SearchCbr(null);
        }

        //ток выключателя
        private void pbxClearCbrCur_Click(object sender, EventArgs e)
        {
            dgvcCmbCbCur.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            if (disCurrent == null) bs_cbrCCbr.DataSource = EquipServices.GetAllCbCur();

            cbCurrent = null;
            cboCbrCbCur.ResetText();
            if (icuValue == null)
            {
                bs_icuVCbr.DataSource = EquipServices.GetAllIcu();
                cboCbrIcu.ResetText();
            }
            SearchCbr(null);
        }

        //отключающая способность
        private void pbxClearIcu_Click(object sender, EventArgs e)
        {
            dgvcCmbIcuVal.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            if (cbCurrent == null) bs_icuVCbr.DataSource = EquipServices.GetAllIcu();

            icuValue = null;
            cboCbrIcu.ResetText();
            SearchCbr(null);
        }

        //тип расцепителя
        private void pbxClearDisType_Click(object sender, EventArgs e)
        {
            dgvcCmbDisTyp.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            if (disCurrent == null) bs_disTCbr.DataSource = EquipServices.GetAllDisType();

            disType = null;
            cboCbrDisType.ResetText();

            if (disModel == null)
            {
                if (manufacturer == null)
                {
                    bs_disMCbr.DataSource = EquipServices.GetAllDisModel();
                    cboCbrDisModel.ResetText();
                }
                else
                {
                    bs_disMCbr.DataSource = EquipServices.GetAllDisModel(manufacturer.Id);
                    cboCbrDisModel.ResetText();
                }
            }
            SearchCbr(null);
        }

        //модель расцепителя
        private void pbxClearDisModel_Click(object sender, EventArgs e)
        {
            dgvcCmbDisMod.DefaultCellStyle.BackColor = System.Drawing.Color.White;

            if (manufacturer == null) bs_disMCbr.DataSource = EquipServices.GetAllDisModel();
            disModel = null;
            cboCbrDisModel.ResetText();
            SearchCbr(null);
        }

        #endregion

        #region /*  Защита двигателя  */

        //мощность двигателя
        private void pbxClearMtPrPower_Click(object sender, EventArgs e)
        {
            dgvcCmbPowMtPr.DefaultCellStyle.BackColor = Color.White;
            bs_mtPowMtPr.DataSource = EquipServices.GetAllMotorPow();
            motorPowerMtPr = null;
            cboMtPrPower.ResetText();
            SearchContByParams(null);
        }

        //тепловое реле
        private void pbxClearMtPrRelay_Click(object sender, EventArgs e)
        {
            dgvcCmbRelayMtPr.DefaultCellStyle.BackColor = Color.White;
            bs_relayMtPr.DataSource = EquipServices.GetHasRealy();
            hasRelayMtPr = null;
            cboMtPrRelay.ResetText();
            SearchContByParams(null);
        }

        //тип координации
        private void pbxClearMtPrType_Click(object sender, EventArgs e)
        {
            dgvcCmbRelayMtPr.DefaultCellStyle.BackColor = Color.White;
            bs_typeMtPr.DataSource = EquipServices.GetCoordType();
            coordTypeMtPr = null;
            cboMtPrType.ResetText();
            SearchContByParams(null);
        }

        //ток управления
        private void pbxClearMtPrCoil_Click(object sender, EventArgs e)
        {
            dgvcCmbCoilMtPr.DefaultCellStyle.BackColor = Color.White;
            bs_coilMtPr.DataSource = EquipServices.GetCoilType();
            coilMtPr = null;
            cboCoilMtPr.ResetText();
            SearchContByParams(null);
        }

        #endregion

        #region /* Пускорегулирующая аппаратура */

        //номинальный ток
        private void pbxClearContCur_Click(object sender, EventArgs e)
        {
            dgvcCmbCurCont.DefaultCellStyle.BackColor = Color.White;
            bs_contCurCont.DataSource = EquipServices.GetAllContCur();
            contCurCont = null;
            cboContCur.ResetText();
            SearchContByParams(null);
        }

        //тип координации
        private void pbxClearContType_Click(object sender, EventArgs e)
        {
            dgvcCmbTypeCoordCont.DefaultCellStyle.BackColor = Color.White;
            bs_coordTypeCont.DataSource = EquipServices.GetCoordType();
            coordTypeCont = null;
            cboCoordTypeCont.ResetText();
            SearchContByParams(null);
        }

        //тип управления
        private void pbxClearContCoil_Click(object sender, EventArgs e)
        {
            dgvcCmbCoilCont.DefaultCellStyle.BackColor = Color.White;
            bs_coilCont.DataSource = EquipServices.GetCoilType();
            coilCont = null;
            cboCoilCont.ResetText();
            SearchContByParams(null);
        }

        #endregion

        #endregion


        //добавление выключателя в проект
        private void InsertCbr(string connectionNumber)
        {
            ProjectEquipment pe = EquipServices.AttachCbr(_project, bs_Cbr.Current as CurrentBreaker, connectionNumber);
            bs_CbrPrj.DataSource = EquipServices.GetProjectCbr(_project, false);
            bs_CbrEquip.DataSource = EquipServices.GetAllEquipCbr(_project, false);
            bs_EquipNote.DataSource = EquipServices.GetAllProjectNote();

            if (EquipServices.GetCbrAnalog(pe, bs_Cbr.Current as CurrentBreaker))
            {
                AnalogDataSourceLoad(DefaultForeColor, string.Empty);
            }
            else
            {
                AnalogDataSourceLoad(Color.Red, "не найдено");
            }
        }

        //добавление контактора в проект
        private void InsertCnt(string connectionNumber)
        {
            ProjectEquipment pe = EquipServices.AttachContactor(_project, bs_Cont.Current as Contactor, connectionNumber);
            bs_ContPrj.DataSource = EquipServices.GetAllProjectCont(_project, false);
        }
    }
}
