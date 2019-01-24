namespace Synectix
{
    partial class frmProjectFind
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectFind));
            this.gbxFilter = new System.Windows.Forms.GroupBox();
            this.btnCbrClear = new System.Windows.Forms.Button();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.projectStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pbxClearState = new System.Windows.Forms.PictureBox();
            this.pbxClearStage = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbxClearImp = new System.Windows.Forms.PictureBox();
            this.pbxClearNumber = new System.Windows.Forms.PictureBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.pbxClearMngr = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboImplementer = new System.Windows.Forms.ComboBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.cboStage = new System.Windows.Forms.ComboBox();
            this.projectStageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.cboManager = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFindNumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.projectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dgvcCmbNumber = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.projectNumberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvcCmbMnger = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcCmbImpter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcCmbEditor = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcTxtVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcTxtDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcCmbState = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvcCmbStage = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gbxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearImp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearMngr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectStageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumberBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxFilter
            // 
            this.gbxFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbxFilter.Controls.Add(this.btnCbrClear);
            this.gbxFilter.Controls.Add(this.cboState);
            this.gbxFilter.Controls.Add(this.pbxClearState);
            this.gbxFilter.Controls.Add(this.pbxClearStage);
            this.gbxFilter.Controls.Add(this.label3);
            this.gbxFilter.Controls.Add(this.pbxClearImp);
            this.gbxFilter.Controls.Add(this.pbxClearNumber);
            this.gbxFilter.Controls.Add(this.dtpDateFrom);
            this.gbxFilter.Controls.Add(this.pbxClearMngr);
            this.gbxFilter.Controls.Add(this.label6);
            this.gbxFilter.Controls.Add(this.label7);
            this.gbxFilter.Controls.Add(this.cboImplementer);
            this.gbxFilter.Controls.Add(this.label10);
            this.gbxFilter.Controls.Add(this.cboStage);
            this.gbxFilter.Controls.Add(this.dtpDateTo);
            this.gbxFilter.Controls.Add(this.cboManager);
            this.gbxFilter.Controls.Add(this.label9);
            this.gbxFilter.Controls.Add(this.label2);
            this.gbxFilter.Controls.Add(this.txtFindNumber);
            this.gbxFilter.Controls.Add(this.label8);
            this.gbxFilter.Controls.Add(this.label1);
            this.gbxFilter.Location = new System.Drawing.Point(12, 8);
            this.gbxFilter.Name = "gbxFilter";
            this.gbxFilter.Size = new System.Drawing.Size(192, 419);
            this.gbxFilter.TabIndex = 1;
            this.gbxFilter.TabStop = false;
            this.gbxFilter.Text = "Критерии поиска";
            // 
            // btnCbrClear
            // 
            this.btnCbrClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCbrClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCbrClear.FlatAppearance.BorderSize = 0;
            this.btnCbrClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnCbrClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCbrClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCbrClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.btnCbrClear.Image = global::Synectix.Properties.Resources.res_clear;
            this.btnCbrClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCbrClear.Location = new System.Drawing.Point(52, 247);
            this.btnCbrClear.Name = "btnCbrClear";
            this.btnCbrClear.Size = new System.Drawing.Size(128, 24);
            this.btnCbrClear.TabIndex = 18;
            this.btnCbrClear.Text = "Очистить все";
            this.btnCbrClear.UseVisualStyleBackColor = true;
            this.btnCbrClear.Click += new System.EventHandler(this.btnCbrClear_Click);
            // 
            // cboState
            // 
            this.cboState.DataSource = this.projectStateBindingSource;
            this.cboState.DisplayMember = "State";
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(32, 212);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(124, 21);
            this.cboState.TabIndex = 1;
            this.cboState.ValueMember = "Id";
            this.cboState.SelectionChangeCommitted += new System.EventHandler(this.cboState_SelectionChangeCommitted);
            // 
            // projectStateBindingSource
            // 
            this.projectStateBindingSource.DataSource = typeof(Model.ProjectState);
            // 
            // pbxClearState
            // 
            this.pbxClearState.Image = global::Synectix.Properties.Resources.res_clear;
            this.pbxClearState.Location = new System.Drawing.Point(161, 214);
            this.pbxClearState.Name = "pbxClearState";
            this.pbxClearState.Size = new System.Drawing.Size(16, 16);
            this.pbxClearState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxClearState.TabIndex = 22;
            this.pbxClearState.TabStop = false;
            this.pbxClearState.Click += new System.EventHandler(this.pbxClearState_Click);
            // 
            // pbxClearStage
            // 
            this.pbxClearStage.Image = global::Synectix.Properties.Resources.res_clear;
            this.pbxClearStage.Location = new System.Drawing.Point(161, 170);
            this.pbxClearStage.Name = "pbxClearStage";
            this.pbxClearStage.Size = new System.Drawing.Size(16, 16);
            this.pbxClearStage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxClearStage.TabIndex = 22;
            this.pbxClearStage.TabStop = false;
            this.pbxClearStage.Click += new System.EventHandler(this.pbxClearStage_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Состояние:";
            // 
            // pbxClearImp
            // 
            this.pbxClearImp.Image = global::Synectix.Properties.Resources.res_clear;
            this.pbxClearImp.Location = new System.Drawing.Point(160, 129);
            this.pbxClearImp.Name = "pbxClearImp";
            this.pbxClearImp.Size = new System.Drawing.Size(16, 16);
            this.pbxClearImp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxClearImp.TabIndex = 22;
            this.pbxClearImp.TabStop = false;
            this.pbxClearImp.Click += new System.EventHandler(this.pbxClearImp_Click);
            // 
            // pbxClearNumber
            // 
            this.pbxClearNumber.Image = global::Synectix.Properties.Resources.res_clear;
            this.pbxClearNumber.Location = new System.Drawing.Point(160, 48);
            this.pbxClearNumber.Name = "pbxClearNumber";
            this.pbxClearNumber.Size = new System.Drawing.Size(16, 16);
            this.pbxClearNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxClearNumber.TabIndex = 22;
            this.pbxClearNumber.TabStop = false;
            this.pbxClearNumber.Click += new System.EventHandler(this.pbxClearNumber_Click);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(43, 320);
            this.dtpDateFrom.MinDate = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(123, 20);
            this.dtpDateFrom.TabIndex = 4;
            this.dtpDateFrom.Value = new System.DateTime(2017, 12, 1, 0, 0, 0, 0);
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // pbxClearMngr
            // 
            this.pbxClearMngr.Image = global::Synectix.Properties.Resources.res_clear;
            this.pbxClearMngr.Location = new System.Drawing.Point(160, 88);
            this.pbxClearMngr.Name = "pbxClearMngr";
            this.pbxClearMngr.Size = new System.Drawing.Size(16, 16);
            this.pbxClearMngr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxClearMngr.TabIndex = 22;
            this.pbxClearMngr.TabStop = false;
            this.pbxClearMngr.Click += new System.EventHandler(this.pbxClearMngr_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(73, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Период:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "с:";
            // 
            // cboImplementer
            // 
            this.cboImplementer.DataSource = this.userBindingSource;
            this.cboImplementer.DisplayMember = "UserName";
            this.cboImplementer.FormattingEnabled = true;
            this.cboImplementer.Location = new System.Drawing.Point(31, 127);
            this.cboImplementer.Name = "cboImplementer";
            this.cboImplementer.Size = new System.Drawing.Size(123, 21);
            this.cboImplementer.TabIndex = 3;
            this.cboImplementer.ValueMember = "Id";
            this.cboImplementer.SelectionChangeCommitted += new System.EventHandler(this.cboImplementer_SelectionChangeCommitted);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Model.User);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "по:";
            // 
            // cboStage
            // 
            this.cboStage.DataSource = this.projectStageBindingSource;
            this.cboStage.DisplayMember = "Stage";
            this.cboStage.FormattingEnabled = true;
            this.cboStage.Location = new System.Drawing.Point(32, 168);
            this.cboStage.Name = "cboStage";
            this.cboStage.Size = new System.Drawing.Size(124, 21);
            this.cboStage.TabIndex = 6;
            this.cboStage.ValueMember = "Id";
            this.cboStage.SelectionChangeCommitted += new System.EventHandler(this.cboStage_SelectionChangeCommitted);
            // 
            // projectStageBindingSource
            // 
            this.projectStageBindingSource.DataSource = typeof(Model.ProjectStage);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Checked = false;
            this.dtpDateTo.Location = new System.Drawing.Point(43, 354);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(123, 20);
            this.dtpDateTo.TabIndex = 5;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // cboManager
            // 
            this.cboManager.DataSource = this.userBindingSource;
            this.cboManager.DisplayMember = "UserName";
            this.cboManager.FormattingEnabled = true;
            this.cboManager.Location = new System.Drawing.Point(31, 87);
            this.cboManager.Name = "cboManager";
            this.cboManager.Size = new System.Drawing.Size(124, 21);
            this.cboManager.TabIndex = 2;
            this.cboManager.ValueMember = "Id";
            this.cboManager.SelectionChangeCommitted += new System.EventHandler(this.cboManager_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Менеджер проекта:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Идентификатор:";
            // 
            // txtFindNumber
            // 
            this.txtFindNumber.Location = new System.Drawing.Point(32, 48);
            this.txtFindNumber.Name = "txtFindNumber";
            this.txtFindNumber.Size = new System.Drawing.Size(124, 20);
            this.txtFindNumber.TabIndex = 0;
            this.txtFindNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindNumber_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Исполнитель:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Этап:";
            // 
            // projectBindingSource
            // 
            this.projectBindingSource.DataSource = typeof(Model.Project);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeight = 30;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCmbNumber,
            this.dgvcCmbMnger,
            this.dgvcCmbImpter,
            this.dgvcCmbEditor,
            this.dgvcTxtVersion,
            this.dgvcTxtDate,
            this.dgvcCmbState,
            this.dgvcCmbStage});
            this.dataGridView.ContextMenuStrip = this.contextMenu;
            this.dataGridView.DataSource = this.projectBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(214, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(899, 415);
            this.dataGridView.TabIndex = 17;
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // dgvcCmbNumber
            // 
            this.dgvcCmbNumber.DataPropertyName = "IdNumber";
            this.dgvcCmbNumber.DataSource = this.projectNumberBindingSource;
            this.dgvcCmbNumber.DisplayMember = "Number";
            this.dgvcCmbNumber.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvcCmbNumber.HeaderText = "Идентификатор";
            this.dgvcCmbNumber.Name = "dgvcCmbNumber";
            this.dgvcCmbNumber.ReadOnly = true;
            this.dgvcCmbNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcCmbNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcCmbNumber.ValueMember = "Id";
            // 
            // projectNumberBindingSource
            // 
            this.projectNumberBindingSource.DataSource = typeof(Model.ProjectNumber);
            // 
            // dgvcCmbMnger
            // 
            this.dgvcCmbMnger.DataPropertyName = "IdManager";
            this.dgvcCmbMnger.DataSource = this.userBindingSource;
            this.dgvcCmbMnger.DisplayMember = "UserName";
            this.dgvcCmbMnger.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvcCmbMnger.HeaderText = "Менеджер";
            this.dgvcCmbMnger.Name = "dgvcCmbMnger";
            this.dgvcCmbMnger.ReadOnly = true;
            this.dgvcCmbMnger.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcCmbMnger.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcCmbMnger.ValueMember = "Id";
            this.dgvcCmbMnger.Width = 120;
            // 
            // dgvcCmbImpter
            // 
            this.dgvcCmbImpter.DataPropertyName = "IdImplementer";
            this.dgvcCmbImpter.DataSource = this.userBindingSource;
            this.dgvcCmbImpter.DisplayMember = "UserName";
            this.dgvcCmbImpter.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvcCmbImpter.HeaderText = "Исполнитель";
            this.dgvcCmbImpter.Name = "dgvcCmbImpter";
            this.dgvcCmbImpter.ReadOnly = true;
            this.dgvcCmbImpter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcCmbImpter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcCmbImpter.ValueMember = "Id";
            this.dgvcCmbImpter.Width = 120;
            // 
            // dgvcCmbEditor
            // 
            this.dgvcCmbEditor.DataPropertyName = "IdEditor";
            this.dgvcCmbEditor.DataSource = this.userBindingSource;
            this.dgvcCmbEditor.DisplayMember = "UserName";
            this.dgvcCmbEditor.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvcCmbEditor.HeaderText = "Редактор";
            this.dgvcCmbEditor.Name = "dgvcCmbEditor";
            this.dgvcCmbEditor.ReadOnly = true;
            this.dgvcCmbEditor.ValueMember = "Id";
            this.dgvcCmbEditor.Width = 120;
            // 
            // dgvcTxtVersion
            // 
            this.dgvcTxtVersion.DataPropertyName = "Version";
            this.dgvcTxtVersion.HeaderText = "Редакция";
            this.dgvcTxtVersion.Name = "dgvcTxtVersion";
            this.dgvcTxtVersion.ReadOnly = true;
            this.dgvcTxtVersion.Width = 65;
            // 
            // dgvcTxtDate
            // 
            this.dgvcTxtDate.DataPropertyName = "Date";
            this.dgvcTxtDate.HeaderText = "Дата";
            this.dgvcTxtDate.Name = "dgvcTxtDate";
            this.dgvcTxtDate.ReadOnly = true;
            this.dgvcTxtDate.Width = 135;
            // 
            // dgvcCmbState
            // 
            this.dgvcCmbState.DataPropertyName = "IdState";
            this.dgvcCmbState.DataSource = this.projectStateBindingSource;
            this.dgvcCmbState.DisplayMember = "State";
            this.dgvcCmbState.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvcCmbState.HeaderText = "Состояние";
            this.dgvcCmbState.Name = "dgvcCmbState";
            this.dgvcCmbState.ReadOnly = true;
            this.dgvcCmbState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcCmbState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcCmbState.ValueMember = "Id";
            this.dgvcCmbState.Width = 110;
            // 
            // dgvcCmbStage
            // 
            this.dgvcCmbStage.DataPropertyName = "IdStage";
            this.dgvcCmbStage.DataSource = this.projectStageBindingSource;
            this.dgvcCmbStage.DisplayMember = "Stage";
            this.dgvcCmbStage.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dgvcCmbStage.HeaderText = "Этап";
            this.dgvcCmbStage.Name = "dgvcCmbStage";
            this.dgvcCmbStage.ReadOnly = true;
            this.dgvcCmbStage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvcCmbStage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvcCmbStage.ValueMember = "Id";
            this.dgvcCmbStage.Width = 105;
            // 
            // contextMenu
            // 
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(153, 26);
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenu_Opening);
            // 
            // frmProjectFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1125, 438);
            this.Controls.Add(this.gbxFilter);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "frmProjectFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Список проектов";
            this.Load += new System.EventHandler(this.frmProjectFind_Load);
            this.gbxFilter.ResumeLayout(false);
            this.gbxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearImp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClearMngr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectStageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectNumberBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFilter;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFindNumber;
        private System.Windows.Forms.ComboBox cboImplementer;
        private System.Windows.Forms.ComboBox cboManager;
        private System.Windows.Forms.BindingSource projectBindingSource;
        private System.Windows.Forms.ComboBox cboStage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.BindingSource projectStateBindingSource;
        private System.Windows.Forms.BindingSource projectStageBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn managerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn implementerDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.PictureBox pbxClearStage;
        private System.Windows.Forms.PictureBox pbxClearImp;
        private System.Windows.Forms.PictureBox pbxClearState;
        private System.Windows.Forms.PictureBox pbxClearMngr;
        private System.Windows.Forms.PictureBox pbxClearNumber;
        private System.Windows.Forms.Button btnCbrClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTxtId;
        private System.Windows.Forms.BindingSource projectNumberBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCmbNumber;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCmbMnger;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCmbImpter;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCmbEditor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTxtVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcTxtDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCmbState;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvcCmbStage;
    }
}