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
    public partial class frmUser : Form
    {
        bool IsNew = false;

        public frmUser()
        {
            InitializeComponent();
        }

        //загрузка формы
        private void frmUser_Load(object sender, EventArgs e)
        {
            userBindingSource.DataSource = AuthServices.GetAllUser();
            roleBindingSource.DataSource = AuthServices.GetAllRole();
        }

        //добавить нового пользователя
        private void btnAdd_Click(object sender, EventArgs e)
        {
            User user = new User();
            userBindingSource.Add(user);
            userBindingSource.MoveLast();
            IsNew = true;
        }

        //Сохранить изменения
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                userBindingSource.EndEdit();

                /*------------------------------------------------
                                    Внимание!   
                   Сохраняется только последняя изменённая запись!
                  ------------------------------------------------*/

                if (IsNew) AuthServices.InsertUser(userBindingSource.Current as User);
                else AuthServices.UpdateUser(userBindingSource.Current as User);

                dataGridView.Refresh();
                IsNew = false;
                MessageBox.Show("Данные успешно сохранены", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        //удалить пользователя
        private void btnDelete_Click(object sender, EventArgs e)
        {
            User currentUser = userBindingSource.Current as User;

            try
            {
                if (currentUser == null)
                    return;
                if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (AuthServices.UserProject(currentUser))
                    {
                        MessageBox.Show("Невозможно удалить пользователя, \r\n" +
                                        "поскольку существуют связанные с ним проекты!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    AuthServices.DeleteUser(currentUser);
                    userBindingSource.RemoveCurrent();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //статическое поле "экземпляр"
        private static  frmUser _instance;
        
        //свойство "экземпляр"
        public static frmUser Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmUser();
                return _instance;
            }
        }

        //закрытие формы
        private void frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            //frmMain.OpenedMdi.Remove(frmUser.Instance.Name);
        }
    }
}
