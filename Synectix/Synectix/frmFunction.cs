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
    public partial class frmFunction : Form
    {
        bool IsNew = false;

        public frmFunction()
        {
            InitializeComponent();
        }

        //загрузка формы
        private void frmFunction_Load(object sender, EventArgs e)
        {
            functionBindingSource.DataSource = AuthServices.GetAllFunction();

            List<AppForm> list = new List<AppForm>();
            list.Add(new AppForm() { Id = ".frmRole", FormName = "Роль пользователя" });
            list.Add(new AppForm() { Id = ".frmUser", FormName = "Список пользователей" });
            list.Add(new AppForm() { Id = ".frmFunction", FormName = "Функции программы" });
            list.Add(new AppForm() { Id = ".frmFunctionRole", FormName = "Аутентификация" });
            list.Add(new AppForm() { Id = ".frmProjectCreate", FormName = "Создать проект" });
            list.Add(new AppForm() { Id = "TCOCreate", FormName = "Создать ТКП" });
            list.Add(new AppForm() { Id = "OrderCreate", FormName = "Создать заказ" });
            list.Add(new AppForm() { Id = "FreezeProject", FormName = "Заморозить проект" });
            list.Add(new AppForm() { Id = "WarmProject", FormName = "Разморозить проект" });

            formNameDataGridViewComboBoxColumn.DataSource = list;
            formNameDataGridViewComboBoxColumn.ValueMember = "Id";
            formNameDataGridViewComboBoxColumn.DisplayMember = "FormName";
        }

        //добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Function function = new Function();
            functionBindingSource.Add(function);
            functionBindingSource.MoveLast();
            IsNew = true;
        }

        //удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (functionBindingSource.Current == null)
                return;
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AuthServices.DeleteFunction(functionBindingSource.Current as Function);
                functionBindingSource.RemoveCurrent();
            }
        }

        //сохранить
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                functionBindingSource.EndEdit();

                /*------------------------------------------------
                                    Внимание!   
                   Сохраняется только последняя изменённая запись!
                  ------------------------------------------------*/

                if (IsNew) AuthServices.InsertFunction(functionBindingSource.Current as Function);
                else AuthServices.UpdateFunction(functionBindingSource.Current as Function);

                dataGridView.Refresh();
                IsNew = false;
                MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //статическое поле "экземпляр"
        private static frmFunction _instance;

        //свойство "экземпляр"
        public static frmFunction Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmFunction();
                return _instance;
            }
        }

        //закрытие формы
        private void frmFunction_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmMain.OpenedMdi.Remove(frmFunction.Instance.Name);
        }
    }
}
