using Model;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Synectix
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(2000);
            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new frmSplashScreen());
        }

        private void ResetTextCtr()
        {
            txtLogin.Clear();
            txtPassword.Clear();
            txtLogin.Focus();
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnLogin.PerformClick();
            }
        }

        public User UserInfo { get; set; }
        
        //поле "экземпляр"
        private static frmLogin _instance;

        //свойство "экземпляр"
        public static frmLogin Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmLogin();
                return _instance;
            }
        }

        //кнопка "Войти"
        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (String.IsNullOrEmpty(txtLogin.Text) || String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogin.Focus();
            }
            else
            {
                string pswd = AuthServices.GetHash(txtPassword.Text);
                UserInfo = AuthServices.TryLogin(txtLogin.Text, pswd);

                if (UserInfo != null)
                {
                     //открыть главное окно программы
                    using(frmMain frm = new frmMain())
                    {
                        ResetTextCtr();
                        this.Hide();
                        frm.ShowDialog();
                    }
                }
                else
                {
                    lblError.ForeColor = Color.Red;
                    lblError.Text += " Отказ! Неправильные логин или пароль";

                    //очистить текстовые поля и вернуть курсор в поле "Имя пользователя"
                    ResetTextCtr();
                }
            }

        }

        //поле "экземпляр" = эта форма
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Activate();
            lblError.Text = "";
            _instance = this;
        }
    }
}
