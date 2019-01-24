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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private bool _isLogout { get; set; }           //выход выполнен
        private Type type = typeof(Synectix.AppForm);  //тип класса

        #region События формы
        //загрузка
        private void frmMain_Load(object sender, EventArgs e)
        {
            tsLogin.Text = $"Вход выполнен: {frmLogin.Instance.UserInfo.UserName}";
            var sql = AuthServices.GetMenuItem(frmLogin.Instance.UserInfo.Login);

            //добавление элементов меню в зависимости от роли пользователя
            foreach (var obj in sql)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = "item" + obj.FormName;
                item.Tag = String.Concat(type.Namespace, obj.FormName); //Synectix.frmName
                item.Text = obj.FunctionName;
                item.Click += Item_Click;
                if (item.Name.Contains("TCOCreate"))
                {
                    item.Tag = string.Empty;
                    item.Text = "Новое &ТКП  " /*ТКП*/;
                    item.ShortcutKeyDisplayString = "Ctrl+T";
                    item.ShortcutKeys = ((Keys)((Keys.Control | Keys.T)));
                    itemCreate.DropDownItems.Insert(0, item);
                }
                else if (item.Name.Contains("ProjectCreate"))
                {
                    item.Text = "Новый &проект ";
                    item.ShortcutKeyDisplayString = "Ctrl + N";
                    item.ShortcutKeys = ((Keys)((Keys.Control | Keys.N)));
                    itemCreate.DropDownItems.Insert(0, item);
                }
                else if (item.Name.Contains("OrderCreate"))
                {
                    item.Tag = string.Empty;
                    item.Text = "Новый &Заказ  " /*ТКП*/;
                    item.ShortcutKeyDisplayString = "Ctrl+O";
                    item.ShortcutKeys = ((Keys)((Keys.Control | Keys.O)));
                    itemCreate.DropDownItems.Insert(1, item);
                }
                else if(item.Name.Contains("FreezeProject") || item.Name.Contains("WarmProject"))
                {
                    itemMainMenu.DropDownItems.Remove(item);
                }
                else
                {
                    itemMainMenu.DropDownItems.Add(item);
                }
            }
            if (itemCreate.DropDownItems.Count < 1)
                itemProjectMenu.DropDownItems.Remove(itemCreate);

            //добавление элемента меню "Сменить пароль"
            ToolStripMenuItem itemChangePassword = new ToolStripMenuItem();
            itemChangePassword.Name = "itemChangePassword";
            itemChangePassword.Text = "Сменить пароль";
            itemChangePassword.Click += ItemChangePassword_Click;
            itemMainMenu.DropDownItems.Add(itemChangePassword);

            //добавление разделителя
            ToolStripSeparator div = new ToolStripSeparator();
            itemMainMenu.DropDownItems.Add(div);

            //добавление элемента меню "Выход"
            ToolStripMenuItem itemLogOut = new ToolStripMenuItem();
            itemLogOut.Name = "itemLogOut";
            itemLogOut.Text = "Выход";
            itemLogOut.ShortcutKeyDisplayString = "Ctrl + Q";
            itemLogOut.ShortcutKeys = ((Keys)((Keys.Control | Keys.Q)));
            itemLogOut.Click += ItemLogOut_Click;
            itemMainMenu.DropDownItems.Add(itemLogOut);
        }

        //закрытие
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLogout)
            {
                if (e.CloseReason != CloseReason.UserClosing) return;
                else Application.Exit();
            }
        }
        #endregion

        #region меню "Меню" :)))

        //"Выход"
        private void ItemLogOut_Click(object sender, EventArgs e)
        {
            _isLogout = true;
            frmLogin.Instance.Show();
            this.Hide();
        }

        //"Сменить пароль"
        private void ItemChangePassword_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            using (frmChangePassword frm = new frmChangePassword(frmLogin.Instance.UserInfo))
            {
                frm.ShowDialog();
                item.Enabled = false;
            }
        }

        #endregion

        #region меню "Оборудование"
        //метод открытия формы "Оборудование"
        private void ShowEquipmentForm(string tabPageName)
        {
            using (frmEquipment frm = new frmEquipment(null, tabPageName, 0 /* создание нового списка оборудования */))
            {
                frm.ShowDialog();
            }
        }

        //Автоматические выключатели
        private void itemCurBreaker_Click(object sender, EventArgs e)
        {
            ShowEquipmentForm("tbpCurBreaker");
        }
        //Контакторы
        private void itemContactor_Click(object sender, EventArgs e)
        {
            ShowEquipmentForm("tbpContactor");
        }

        //Защита двигателя
        private void itemMotorProtect_Click(object sender, EventArgs e)
        {
            ShowEquipmentForm("tbpMotorProtect");
        }

        //Трансформаторы тока
        private void itemTransCur_Click(object sender, EventArgs e)
        {
            ShowEquipmentForm("tbpTransformerCurrent");
        }

        //Модульные автоматы
        private void itemModuleCurBr_Click(object sender, EventArgs e)
        {
            ShowEquipmentForm("tbpModuleCurBr");
        }

        #endregion

        #region меню "Проект"

        //"Список проектов"
        private void itemFindAll_Click(object sender, EventArgs e)
        {
            using (frmProjectFind frm = new frmProjectFind())
            {
                frm.ShowDialog();
            }
        }

        //"ТКП"
        private void itemFindTCO_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            using (frmProjectFind frmProject = new frmProjectFind(ProjectServices.GetByStageId(2 /*ТКП*/, 1 /*актуальный*/), item.Text))
            {
                frmProject.ShowDialog();
            }
        }

        //"Заказы"
        private void itemFindOrder_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            using (frmProjectFind frmProject = new frmProjectFind(ProjectServices.GetByStageId(3 /*Заказ*/, 1 /*актуальный*/), item.Text))
            {
                frmProject.ShowDialog();
            }
        }

        //"Архив - нереализованные"
        private void itemLostTKP_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            using (frmProjectFind frmProject = new frmProjectFind(ProjectServices.GetByStageId(2 /*ТКП*/, 2 /*архивный*/), item.Text))
            {
                frmProject.ShowDialog();
            }
        }

        //"Архив - реализованные"
        private void itemDoneOrder_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            using (frmProjectFind frmProject = new frmProjectFind(ProjectServices.GetByStageId(3 /*Заказ*/, 2 /*архивный*/), item.Text))
            {
                frmProject.ShowDialog();
            }
        }

        //"Архив - отложенные"
        private void itemFrozen_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            using (frmProjectFind frmProject = new frmProjectFind(ProjectServices.GetByStageId(0 /* любые */, 3 /*замороженный*/), item.Text))
            {
                frmProject.ShowDialog();
            }
        }

        #endregion

        #region меню "Конфигуратор"
        //"Выдвижной блок"
        private void itemBlock_Click(object sender, EventArgs e)
        {
            using (frmConfigBlock frm2 = new frmConfigBlock(null))
            {
                frm2.ShowDialog();
            }

        }
        #endregion

        #region меню "Справка"

        //"О программе"
        private void itemAbout_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if(item != null)
            {
                Type t = Type.GetType(item.Tag.ToString());
                Form frm = Activator.CreateInstance(t) as Form;
                if(frm != null)
                {
                    frm.ShowDialog();
                }
            }
        }

        #endregion

        #region автоматически созданные пункты меню
        //Автоматически созданные элементы меню
        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                if (item.Tag.ToString() != string.Empty)
                {
                    Type t = Type.GetType(item.Tag.ToString());
                    Form frm = Activator.CreateInstance(t) as Form;
                    if (frm != null)
                    {
                        if (frm.Name.Contains("User") || frm.Name.Contains("Role") || frm.Name.Contains("Function"))
                        {
                            frm.MdiParent = this;
                        }
                        frm.Show();
                    }
                }
                //"Добавить ТКП"
                else if (item.Name.Contains("TCOCreate"))
                {
                    using (frmProjectFind frmProject = new frmProjectFind(ProjectServices.GetByStageId(1 /*Инициализация*/, 1 /*актуальный*/), item.Text))
                    {
                        frmProject.ShowDialog();
                    }
                }
            }
        }
        #endregion

    }
}
