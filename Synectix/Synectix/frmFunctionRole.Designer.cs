namespace Synectix
{
    partial class frmFunctionRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFunctionRole));
            this.dataGridViewFunction = new System.Windows.Forms.DataGridView();
            this.functionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.functionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewFunctionRole = new System.Windows.Forms.DataGridView();
            this.functionIdDataGridViewComboBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.functionRoleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.roleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunctionRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionRoleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFunction
            // 
            this.dataGridViewFunction.AllowUserToAddRows = false;
            this.dataGridViewFunction.AllowUserToDeleteRows = false;
            this.dataGridViewFunction.AutoGenerateColumns = false;
            this.dataGridViewFunction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFunction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.functionNameDataGridViewTextBoxColumn});
            this.dataGridViewFunction.DataSource = this.functionBindingSource;
            this.dataGridViewFunction.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewFunction.Name = "dataGridViewFunction";
            this.dataGridViewFunction.Size = new System.Drawing.Size(264, 327);
            this.dataGridViewFunction.TabIndex = 0;
            // 
            // functionNameDataGridViewTextBoxColumn
            // 
            this.functionNameDataGridViewTextBoxColumn.DataPropertyName = "FunctionName";
            this.functionNameDataGridViewTextBoxColumn.HeaderText = "Список функций";
            this.functionNameDataGridViewTextBoxColumn.Name = "functionNameDataGridViewTextBoxColumn";
            this.functionNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // functionBindingSource
            // 
            this.functionBindingSource.DataSource = typeof(Model.Function);
            // 
            // dataGridViewFunctionRole
            // 
            this.dataGridViewFunctionRole.AllowUserToAddRows = false;
            this.dataGridViewFunctionRole.AllowUserToDeleteRows = false;
            this.dataGridViewFunctionRole.AutoGenerateColumns = false;
            this.dataGridViewFunctionRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFunctionRole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.functionIdDataGridViewComboBoxColumn});
            this.dataGridViewFunctionRole.DataSource = this.functionRoleBindingSource;
            this.dataGridViewFunctionRole.Location = new System.Drawing.Point(356, 50);
            this.dataGridViewFunctionRole.Name = "dataGridViewFunctionRole";
            this.dataGridViewFunctionRole.Size = new System.Drawing.Size(264, 327);
            this.dataGridViewFunctionRole.TabIndex = 0;
            // 
            // functionIdDataGridViewComboBoxColumn
            // 
            this.functionIdDataGridViewComboBoxColumn.DataPropertyName = "FunctionId";
            this.functionIdDataGridViewComboBoxColumn.DataSource = this.functionBindingSource;
            this.functionIdDataGridViewComboBoxColumn.DisplayMember = "FunctionName";
            this.functionIdDataGridViewComboBoxColumn.HeaderText = "Добавленные функции";
            this.functionIdDataGridViewComboBoxColumn.Name = "functionIdDataGridViewComboBoxColumn";
            this.functionIdDataGridViewComboBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.functionIdDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.functionIdDataGridViewComboBoxColumn.ValueMember = "Id";
            this.functionIdDataGridViewComboBoxColumn.Width = 200;
            // 
            // functionRoleBindingSource
            // 
            this.functionRoleBindingSource.DataSource = typeof(Model.FunctionRole);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.btnRemove.Image = global::Synectix.Properties.Resources.res_left;
            this.btnRemove.Location = new System.Drawing.Point(284, 193);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(29, 50);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.btnAdd.Image = global::Synectix.Properties.Resources.res_right;
            this.btnAdd.Location = new System.Drawing.Point(319, 193);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 50);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Роль пользователя";
            // 
            // cboRole
            // 
            this.cboRole.DataSource = this.roleBindingSource;
            this.cboRole.DisplayMember = "RoleName";
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(136, 15);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(140, 21);
            this.cboRole.TabIndex = 3;
            this.cboRole.ValueMember = "RoleId";
            this.cboRole.SelectionChangeCommitted += new System.EventHandler(this.cboRole_SelectionChangeCommitted);
            // 
            // roleBindingSource
            // 
            this.roleBindingSource.DataSource = typeof(Model.Role);
            // 
            // frmFunctionRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(632, 389);
            this.Controls.Add(this.cboRole);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dataGridViewFunctionRole);
            this.Controls.Add(this.dataGridViewFunction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFunctionRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Аутентификация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFunctionRole_FormClosing);
            this.Load += new System.EventHandler(this.frmFunctionRole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFunctionRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.functionRoleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFunction;
        private System.Windows.Forms.DataGridView dataGridViewFunctionRole;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.BindingSource functionBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn functionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource roleBindingSource;
        private System.Windows.Forms.BindingSource functionRoleBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn functionIdDataGridViewComboBoxColumn;
    }
}