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
    public partial class frmProjectFind : Form
    {
        //поля класса формы
        string _mode = "";
        private int _idManager, _idImplementer, _idState, _idStage;

        #region Конструкторы формы

        //из пункта меню "Найти"
        public frmProjectFind(/*int openingFilter*/)
        {
            InitializeComponent();
            projectBindingSource.DataSource = ProjectServices.GetAllProject();
            projectNumberBindingSource.DataSource = ProjectServices.GetAllProjectNum();
        }

        //из других пунктов меню (с фильтрами)
        public frmProjectFind(List<Project> byStageOrByState, string formMode)
        {
            InitializeComponent();
            projectNumberBindingSource.DataSource = ProjectServices.GetAllProjectNum();
            projectBindingSource.DataSource = byStageOrByState;
            _mode = formMode;

            switch (_mode)
            {
                case "Новое &ТКП  ":
                    gbxFilter.Enabled = false;
                    this.Text = "Создание ТКП";
                    break;

                default:
                    this.Text += ": " + _mode;
                    break;
            }
        }
        #endregion

        #region Методы

        //очистка фильтров
        private void ClearFilter(Control ctr)
        {
            ctr.ResetText();
        }
        private void ClearFilter(Control ctr, ref int _id)
        {
            ctr.ResetText();
            _id = 0;
            Find();
        }

        //поиск
        private void Find()
        {
            ProjectNumber pridobject = new ProjectNumber();
            pridobject.Number = txtFindNumber.Text;
            projectBindingSource.DataSource = ProjectServices.GetAllProject(ProjectServices.GetProjectNumberId(pridobject), _idState,
                                 _idManager, _idImplementer, dtpDateFrom.Value.ToString(),
                                 dtpDateTo.Value.ToString(), _idStage);
        }

        //открытие карточки проекта
        private void OpenProjectCard()
        {
            using (frmProjectCard frm = new frmProjectCard(projectBindingSource.Current as Project))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    projectBindingSource.DataSource = ProjectServices.GetAllProject();
                    projectStageBindingSource.DataSource = ProjectServices.GetAllProjectStage();
                    projectStateBindingSource.DataSource = ProjectServices.GetAllProjectState();

                    projectBindingSource.MoveLast();
                    dataGridView.SelectedRows[0].Selected = false;
                    dataGridView.Rows[dataGridView.Rows.Count - 1].Selected = true;
                    dtpDateTo.Value = DateTime.Now;
                }
            }
        }

        #endregion

        #region События формы

        //загрузка
        private void frmProjectFind_Load(object sender, EventArgs e)
        {
            //загрузка связанных источников
            projectStageBindingSource.DataSource = ProjectServices.GetAllProjectStage();
            projectStateBindingSource.DataSource = ProjectServices.GetAllProjectState();
            userBindingSource.DataSource = AuthServices.GetAllUser();

            //загрузка источников выпадающих списков
            cboManager.DataSource = ProjectServices.GetAllEmployees("Manager");
            cboImplementer.DataSource = ProjectServices.GetAllEmployees("Engineer");

            foreach (Control ctr in gbxFilter.Controls)
            {
                if (ctr.GetType() == typeof(ComboBox))
                {
                    ClearFilter(ctr);
                }
            }

            //формирование контекстного меню
            var sql = AuthServices.GetMenuItem(frmLogin.Instance.UserInfo.Login);

            //добавление элементов меню в зависимости от роли пользователя
            foreach (var obj in sql)
            {
                if (obj.FormName.Contains("Freeze")|| obj.FormName.Contains("Warm"))
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = "item" + obj.FormName;
                    item.Tag = string.Empty;
                    item.Text = obj.FunctionName.Replace(" проект", "");

                    if (item.Name.Contains("Freeze")) item.Image = Properties.Resources.res_freeze;
                    else item.Image = Properties.Resources.res_warm;

                    item.Click += ItemFreeze_Click;
                    contextMenu.Items.Add(item);
                    contextMenu.Items[item.Name].Enabled = false;
                }
                else if (obj.FormName.Contains("TCOCreate"))
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Name = "item" + obj.FormName;
                    item.Tag = string.Empty;
                    item.Text = obj.FunctionName;
                    item.Image = Properties.Resources.res_add;

                    item.Click += ItemCreateTCO_Click;
                    contextMenu.Items.Add(item);
                }
            }
        }

        //вызов контекстного меню
        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            Project temp = projectBindingSource.Current as Project;

            if (contextMenu.Items.Contains(contextMenu.Items["itemFreezeProject"]))
            {
                if ((int)temp.IdState == 1)
                {
                    contextMenu.Items["itemFreezeProject"].Enabled = true;
                    contextMenu.Items["itemWarmProject"].Enabled = false;
                }
                else if ((int)temp.IdState == 3)
                {
                    contextMenu.Items["itemFreezeProject"].Enabled = false;
                    contextMenu.Items["itemWarmProject"].Enabled = true;
                }
            }
        }

        //контекстное меню "Создать ТКП"
        private void ItemCreateTCO_Click(object sender, EventArgs e)
        {
            /* [ Добавить ТКП ] */
            if (_mode.Contains("Новое &ТКП  "))
            {
                if (ProjectServices.AddTCO(projectBindingSource.Current as Project, frmLogin.Instance.UserInfo, 2 /* ТКП */))
                {
                    Project project = projectBindingSource.Current as Project;

                    if (MessageBox.Show("Для проекта № " + project.IdNumber + " добавлено ТКП. \r\n\r\nПерейти к выбору оборудования?", "Технико-коммерческое предложение",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (frmEquipment frm = new frmEquipment(project, string.Empty, 0 /* создание нового списка оборудования */))
                        {
                            this.Hide();
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        projectBindingSource.DataSource = ProjectServices.GetByStageId(1/*Инициализация*/, 1 /*актуальный*/);
                        return;
                    }
                }
                else //ошибка добавления ТКП в БД (изменения состояния проекта)
                {
                    MessageBox.Show("Ошибка записи в базу данных. \r\n Обратитесь к специалистам технической поддержки");
                }
            }
        }

        //контекстное меню "Заморозить/заморозить"
        private void ItemFreeze_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Project pr = projectBindingSource.Current as Project;
            string number = ProjectServices.GetProjectNumber(pr);

            if (item.Name.Contains("Freeze"))
            {
                if (ProjectServices.FreezeWarm(pr, frmLogin.Instance.UserInfo, 3 /*замороженный*/))
                {
                    MessageBox.Show($"Проект № {number} заморожен","Информация",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    projectBindingSource.MoveNext();
                    projectBindingSource.MovePrevious();
                }
                else
                    MessageBox.Show("Ошибка изменения состояния проекта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }              
            else 
            {
                if (ProjectServices.FreezeWarm(pr, frmLogin.Instance.UserInfo, 1 /*актуальный*/))
                {
                    MessageBox.Show($"Проект № {number} разморожен", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    projectBindingSource.MoveNext();
                    projectBindingSource.MovePrevious();
                }
                else
                    MessageBox.Show("Ошибка изменения состояния проекта");
            }                
        }

        //двойной клик по datagridView
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            /* [ Открыть проект ] */
            OpenProjectCard();
        }

        //нажатие Enter txtIdProject
        private void txtFindNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                Find();
            }           
        }

        #endregion

        #region Фильтры поиска

        private void cboManager_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _idManager = Int32.Parse(cboManager.SelectedValue.ToString());
            Find();
        }
        private void cboImplementer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _idImplementer = Int32.Parse(cboImplementer.SelectedValue.ToString());
            Find();
        }
        private void cboState_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _idState = Int32.Parse(cboState.SelectedValue.ToString());
            Find();
        }
        private void cboStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _idStage = Int32.Parse(cboStage.SelectedValue.ToString());
            Find();
        }
        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            Find();
        }
        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            Find();
        }

        #endregion

        #region  Очистка полей фильтра 
        // -- Number
        private void pbxClearNumber_Click(object sender, EventArgs e)
        {
            ClearFilter(txtFindNumber);
        }

        // --State
        private void pbxClearState_Click(object sender, EventArgs e)
        {
            ClearFilter(cboState, ref _idState);
        }
        // -- Manager
        private void pbxClearMngr_Click(object sender, EventArgs e)
        {
            ClearFilter(cboManager, ref _idManager);
        }

        // -- Implementer
        private void pbxClearImp_Click(object sender, EventArgs e)
        {
            ClearFilter(cboImplementer, ref _idImplementer);
        }

        // -- Stage
        private void pbxClearStage_Click(object sender, EventArgs e)
        {
            ClearFilter(cboStage, ref _idStage);
        }

        #endregion

        #region Кнопки формы

        /* [ Поиск ] */
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //фильтрация списка проектов
            Find();
        }

        /* [ Очистить все ] */
        private void btnCbrClear_Click(object sender, EventArgs e)
        {
            _idManager = 0; 
            _idImplementer = 0; 
            _idState = 0; 
            _idStage = 0;

            ClearFilter(txtFindNumber);

            foreach (Control ctr in gbxFilter.Controls)
            {
                if (ctr.GetType() == typeof(ComboBox))
                {
                    ctr.ResetText();
                }
            }
            Find();
        }

        #endregion
    }
}
