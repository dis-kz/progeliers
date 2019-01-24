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
    public partial class frmFunctionRole : Form
    {
        public frmFunctionRole()
        {
            InitializeComponent();
        }

        //загрузка формы
        private void frmFunctionRole_Load(object sender, EventArgs e)
        {
            roleBindingSource.DataSource = AuthServices.GetAllRole();
            functionBindingSource.DataSource = AuthServices.GetAllFunction();

            Role role = cboRole.SelectedItem as Role;
            if(role != null)
            {
                functionRoleBindingSource.DataSource = AuthServices.GetAllFunctionRole(role);
            }
        }

        //выбор значения выпадающего списка
        private void cboRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Role role = cboRole.SelectedItem as Role;
            if(role != null)
            {
                functionRoleBindingSource.DataSource = AuthServices.GetAllFunctionRole(role);
            }
        }

        //открепить функцию роли пользователя
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(functionRoleBindingSource.DataSource != null)
            {
                Role role = cboRole.SelectedItem as Role;
                if(role != null)
                {
                    foreach(DataGridViewRow row in dataGridViewFunctionRole.SelectedRows)
                    {
                        FunctionRole fr = row.DataBoundItem as FunctionRole;
                        if( fr != null)
                        {
                            AuthServices.RemoveFunctionRole(fr);
                            functionRoleBindingSource.Remove(fr);
                        }
                    }
                }
            }
        }

        //прикрепить функцию роли пользователя
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (functionRoleBindingSource.DataSource != null)
            {
                Role role = cboRole.SelectedItem as Role;
                if( role != null)
                {
                    foreach(DataGridViewRow row in dataGridViewFunction.SelectedRows)
                    {
                        Function f = row.DataBoundItem as Function;
                        if (f != null)
                        {
                            AuthServices.AddFunctionRole(f, role);
                        }
                    }
                    functionRoleBindingSource.DataSource = AuthServices.GetAllFunctionRole(role);
                }
            }
        }

        //статическое поле "экземпляр"
        private static frmFunctionRole _instance;

        //свойство "экземпляр"
        public static frmFunctionRole Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmFunctionRole();
                return _instance;
            }
        }

        //закрытие формы
        private void frmFunctionRole_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmMain.OpenedMdi.Remove(frmFunctionRole.Instance.Name);
        }
    }
}
