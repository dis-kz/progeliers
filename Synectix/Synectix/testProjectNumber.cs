using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using ServicesLayer;

namespace Synectix
{
    public partial class testProjectNumber : Form
    {
        public testProjectNumber()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number;

            using (frmInputBox frm = new frmInputBox(1))
            {
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    number = frm.GetTxtValue;

                    Project pr = ProjectServices.GetByNumber(number);

                    if (pr != null)
                        textBox1.Text = pr.Description;
                    else
                        textBox1.ResetText();
                }
            }
        }
    }
}
