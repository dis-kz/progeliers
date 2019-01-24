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
    public partial class frmChangePassword : Form
    {
        User _user;
        string newPswd = "";
        string confirmPswd = "";

        public frmChangePassword(User user)
        {
            InitializeComponent();
            this._user = user;
        }

        /*переход по нажатию Enter*/
        private void txtCurrentPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                txtNewPassword.Focus();
            }
        }
        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtConfirmPassword.Focus();
            }
        }
        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSave.PerformClick();
            }
        }

        /*------------------------*/
        //кнопка "Сохранить"
        private void btnSave_Click(object sender, EventArgs e)
        {
            newPswd = AuthServices.GetHash(txtNewPassword.Text);
            confirmPswd = AuthServices.GetHash(txtConfirmPassword.Text);

            if (AuthServices.GetHash(txtCurrentPassword.Text) != _user.Password)
            {
                MessageBox.Show("Неверный текущий пароль!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(newPswd != confirmPswd)
            {
                MessageBox.Show("Пароли не совпадают!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            if (AuthServices.ChangePassword(newPswd, _user))
            {
                MessageBox.Show("Пароль успешно изменен.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка сохранения пароля!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
