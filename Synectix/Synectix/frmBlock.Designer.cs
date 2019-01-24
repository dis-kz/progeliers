namespace Synectix
{
    partial class frmBlock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBlock = new System.Windows.Forms.Panel();
            this.lbBlock3 = new System.Windows.Forms.Label();
            this.lbBlock2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lbxBlockDocs = new System.Windows.Forms.ListBox();
            this.txtFeeder = new System.Windows.Forms.TextBox();
            this.lbxBlockEquip = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbBlock1 = new System.Windows.Forms.Label();
            this.panelBlock.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBlock
            // 
            this.panelBlock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBlock.Controls.Add(this.lbBlock3);
            this.panelBlock.Controls.Add(this.lbBlock2);
            this.panelBlock.Controls.Add(this.txtResult);
            this.panelBlock.Controls.Add(this.lbxBlockDocs);
            this.panelBlock.Controls.Add(this.txtFeeder);
            this.panelBlock.Controls.Add(this.lbxBlockEquip);
            this.panelBlock.Controls.Add(this.btnClose);
            this.panelBlock.Controls.Add(this.lbBlock1);
            this.panelBlock.Location = new System.Drawing.Point(0, 0);
            this.panelBlock.Name = "panelBlock";
            this.panelBlock.Size = new System.Drawing.Size(405, 578);
            this.panelBlock.TabIndex = 0;
            // 
            // lbBlock3
            // 
            this.lbBlock3.AutoSize = true;
            this.lbBlock3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlock3.Location = new System.Drawing.Point(15, 320);
            this.lbBlock3.Name = "lbBlock3";
            this.lbBlock3.Size = new System.Drawing.Size(176, 13);
            this.lbBlock3.TabIndex = 55;
            this.lbBlock3.Text = "Конструкторская документация:";
            // 
            // lbBlock2
            // 
            this.lbBlock2.AutoSize = true;
            this.lbBlock2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlock2.Location = new System.Drawing.Point(15, 71);
            this.lbBlock2.Name = "lbBlock2";
            this.lbBlock2.Size = new System.Drawing.Size(136, 13);
            this.lbBlock2.TabIndex = 55;
            this.lbBlock2.Text = "Основное оборудование:";
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtResult.ForeColor = System.Drawing.Color.Black;
            this.txtResult.Location = new System.Drawing.Point(144, 15);
            this.txtResult.MaxLength = 20;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(243, 27);
            this.txtResult.TabIndex = 3;
            this.txtResult.Text = "БМВx-XX.XX-XX.X-XXXX";
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbxBlockDocs
            // 
            this.lbxBlockDocs.AllowDrop = true;
            this.lbxBlockDocs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxBlockDocs.FormattingEnabled = true;
            this.lbxBlockDocs.ItemHeight = 14;
            this.lbxBlockDocs.Location = new System.Drawing.Point(17, 336);
            this.lbxBlockDocs.Name = "lbxBlockDocs";
            this.lbxBlockDocs.Size = new System.Drawing.Size(370, 200);
            this.lbxBlockDocs.TabIndex = 2;
            // 
            // txtFeeder
            // 
            this.txtFeeder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFeeder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.txtFeeder.Location = new System.Drawing.Point(335, 48);
            this.txtFeeder.Name = "txtFeeder";
            this.txtFeeder.Size = new System.Drawing.Size(52, 23);
            this.txtFeeder.TabIndex = 4;
            this.txtFeeder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbxBlockEquip
            // 
            this.lbxBlockEquip.AllowDrop = true;
            this.lbxBlockEquip.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbxBlockEquip.FormattingEnabled = true;
            this.lbxBlockEquip.HorizontalScrollbar = true;
            this.lbxBlockEquip.ItemHeight = 14;
            this.lbxBlockEquip.Location = new System.Drawing.Point(17, 88);
            this.lbxBlockEquip.Name = "lbxBlockEquip";
            this.lbxBlockEquip.Size = new System.Drawing.Size(370, 228);
            this.lbxBlockEquip.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.btnClose.Image = global::Synectix.Properties.Resources.res_close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(309, 545);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 21);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Закрыть:";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbBlock1
            // 
            this.lbBlock1.AutoSize = true;
            this.lbBlock1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbBlock1.Location = new System.Drawing.Point(239, 53);
            this.lbBlock1.Name = "lbBlock1";
            this.lbBlock1.Size = new System.Drawing.Size(90, 13);
            this.lbBlock1.TabIndex = 54;
            this.lbBlock1.Text = "Присоединение:";
            // 
            // frmBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(405, 578);
            this.ControlBox = false;
            this.Controls.Add(this.panelBlock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBlock";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Состав оборудования блока";
            this.Load += new System.EventHandler(this.frmBlock_Load);
            this.panelBlock.ResumeLayout(false);
            this.panelBlock.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBlock;
        private System.Windows.Forms.Label lbBlock3;
        private System.Windows.Forms.Label lbBlock2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ListBox lbxBlockDocs;
        private System.Windows.Forms.TextBox txtFeeder;
        private System.Windows.Forms.ListBox lbxBlockEquip;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbBlock1;
    }
}