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
    public partial class frmBlock : Form
    {
        int _idBlock;

        //конструктор
        public frmBlock(string blockName, string conNum, int idBlock)
        {
            InitializeComponent();

            _idBlock = idBlock;
            txtResult.Text = blockName;
            txtFeeder.Text = conNum;
        }

        //загрузка формы
        private void frmBlock_Load(object sender, EventArgs e)
        {
            List<BlockEquipment> listBlockEquip = ConfigServices.GetAllBlockEquip(_idBlock);

            foreach (BlockEquipment beq in listBlockEquip)
            {
                lbxBlockEquip.Items.Add((lbxBlockEquip.Items.Count + 1) + "." + beq.TypeEquip + beq.Title);
            }
        }

        /* [ Закрыть ] */
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
