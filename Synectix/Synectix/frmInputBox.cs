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
    public partial class frmInputBox : Form
    {
        public string GetTxtValue
        {
            get
            {
                return txtValue.Text.ToUpper();
            }
        }

        Project _project;
        int _mode;

        public frmInputBox(int mode)
        {
            InitializeComponent();
            _mode = mode;
        }

        public frmInputBox(Project project, int mode)
        {
            InitializeComponent();
            _project = project;
            _mode = mode;
        }

        private void frmInputBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(txtValue.Text))
                {
                    if (_mode == 1 /*добавление или редактирование*/)
                    {
                        if(EquipServices.CheckDuplicate(_project, txtValue.Text))
                        {
                            MessageBox.Show("Присоединение " + txtValue.Text + " уже существует в списке\r\n Повторение не допускается.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtValue.Focus();
                            txtValue.SelectAll();
                            e.Cancel = true;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо заполнить поле ввода!");
                    txtValue.Focus();
                    e.Cancel = true;
                }
            }
        }

        //загрузка
        private void frmInputBox_Load(object sender, EventArgs e)
        {
            switch (_mode)
            {
                case 1:
                    this.Text = "Введите номер проекта";
                    break;

                case 2:
                    this.Text = "Обозначение присоединения";
                    break;

                default:
                    break;
            }
        }
    }
}
