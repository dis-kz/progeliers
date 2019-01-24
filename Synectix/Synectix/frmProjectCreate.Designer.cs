namespace Synectix
{
    partial class frmProjectCreate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectCreate));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProjectDescription = new System.Windows.Forms.TextBox();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtProjectNumber = new System.Windows.Forms.TextBox();
            this.projectNumberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtSpecialRequire = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBindFile = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.chdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cndSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.txtManager = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumberBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Идентификатор:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Описание объекта:";
            // 
            // txtProjectDescription
            // 
            this.txtProjectDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Description", true));
            this.txtProjectDescription.Location = new System.Drawing.Point(216, 31);
            this.txtProjectDescription.Multiline = true;
            this.txtProjectDescription.Name = "txtProjectDescription";
            this.txtProjectDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProjectDescription.Size = new System.Drawing.Size(311, 63);
            this.txtProjectDescription.TabIndex = 1;
            this.txtProjectDescription.TextChanged += new System.EventHandler(this.txtProjectDescription_TextChanged);
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(Model.Project);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Инициатор:";
            // 
            // txtProjectNumber
            // 
            this.txtProjectNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectNumberBindingSource, "Number", true));
            this.txtProjectNumber.Location = new System.Drawing.Point(15, 31);
            this.txtProjectNumber.MaxLength = 30;
            this.txtProjectNumber.Name = "txtProjectNumber";
            this.txtProjectNumber.Size = new System.Drawing.Size(192, 20);
            this.txtProjectNumber.TabIndex = 0;
            this.txtProjectNumber.TextChanged += new System.EventHandler(this.txtProjectNumber_TextChanged);
            // 
            // projectNumberBindingSource
            // 
            this.projectNumberBindingSource.DataSource = typeof(Model.ProjectNumber);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Особые требования:";
            // 
            // txtSpecialRequire
            // 
            this.txtSpecialRequire.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.projectBindingSource, "Note", true));
            this.txtSpecialRequire.Location = new System.Drawing.Point(15, 116);
            this.txtSpecialRequire.Multiline = true;
            this.txtSpecialRequire.Name = "txtSpecialRequire";
            this.txtSpecialRequire.Size = new System.Drawing.Size(512, 63);
            this.txtSpecialRequire.TabIndex = 2;
            this.txtSpecialRequire.TextChanged += new System.EventHandler(this.txtSpecialRequire_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(397, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 25);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить и выйти";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBindFile
            // 
            this.btnBindFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBindFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBindFile.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBindFile.FlatAppearance.BorderSize = 0;
            this.btnBindFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnBindFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBindFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBindFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.btnBindFile.Image = ((System.Drawing.Image)(resources.GetObject("btnBindFile.Image")));
            this.btnBindFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBindFile.Location = new System.Drawing.Point(298, 345);
            this.btnBindFile.Name = "btnBindFile";
            this.btnBindFile.Size = new System.Drawing.Size(93, 25);
            this.btnBindFile.TabIndex = 3;
            this.btnBindFile.Text = "Прикрепить";
            this.btnBindFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBindFile.UseVisualStyleBackColor = true;
            this.btnBindFile.Click += new System.EventHandler(this.btnBindFile_Click);
            // 
            // listViewFiles
            // 
            this.listViewFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listViewFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdName,
            this.chdDateTime,
            this.chdType,
            this.cndSize});
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.Location = new System.Drawing.Point(15, 201);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(512, 138);
            this.listViewFiles.TabIndex = 10;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.Details;
            this.listViewFiles.DoubleClick += new System.EventHandler(this.listViewFiles_DoubleClick);
            this.listViewFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listFiles_KeyDown);
            // 
            // chdName
            // 
            this.chdName.Text = "Имя файла";
            this.chdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chdName.Width = 195;
            // 
            // chdDateTime
            // 
            this.chdDateTime.Text = "Дата изменения";
            this.chdDateTime.Width = 140;
            // 
            // chdType
            // 
            this.chdType.Text = "Тип";
            this.chdType.Width = 50;
            // 
            // cndSize
            // 
            this.cndSize.Text = "Размер";
            this.cndSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cndSize.Width = 100;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Прикреплённые файлы:";
            // 
            // txtManager
            // 
            this.txtManager.BackColor = System.Drawing.SystemColors.Window;
            this.txtManager.Location = new System.Drawing.Point(15, 74);
            this.txtManager.MaxLength = 30;
            this.txtManager.Name = "txtManager";
            this.txtManager.ReadOnly = true;
            this.txtManager.Size = new System.Drawing.Size(192, 20);
            this.txtManager.TabIndex = 12;
            // 
            // frmProjectCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(542, 378);
            this.Controls.Add(this.txtManager);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProjectNumber);
            this.Controls.Add(this.btnBindFile);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSpecialRequire);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProjectDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listViewFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(558, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(558, 417);
            this.Name = "frmProjectCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Инициализация проекта";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProjectCreate_FormClosing);
            this.Load += new System.EventHandler(this.frmProjectCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumberBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProjectDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProjectNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSpecialRequire;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.Button btnBindFile;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader chdName;
        private System.Windows.Forms.ColumnHeader chdType;
        private System.Windows.Forms.ColumnHeader cndSize;
        private System.Windows.Forms.ColumnHeader chdDateTime;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.BindingSource projectNumberBindingSource;
    }
}