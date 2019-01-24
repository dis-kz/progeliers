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
    public partial class frmRole : Form
    {
        bool IsNew = false;

        public frmRole()
        {
            InitializeComponent();
        }

        //загрузка формы
        private void frmRole_Load(object sender, EventArgs e)
        {
            roleBindingSource.DataSource =  AuthServices.GetAllRole();
        }

        //добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Role role = new Role();
            roleBindingSource.Add(role);
            roleBindingSource.MoveLast();
            IsNew = true;
        }

        //удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (roleBindingSource.Current == null)
                return;
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AuthServices.DeleteRole(roleBindingSource.Current as Role);
                roleBindingSource.RemoveCurrent();
            }
        }

        //сохранить
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                roleBindingSource.EndEdit();

                /*------------------------------------------------
                                    Внимание!   
                   Сохраняется только последняя изменённая запись!
                  ------------------------------------------------*/

                if (IsNew) AuthServices.InsertRole(roleBindingSource.Current as Role);
                else AuthServices.UpdateRole(roleBindingSource.Current as Role);

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
        private static frmRole _instance;

        //свойство "экземпляр"
        public static frmRole Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmRole();
                return _instance;
            }
        }

        //закрытие формы
        private void frmRole_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmMain.OpenedMdi.Remove(frmRole.Instance.Name);
        }
    }
}
