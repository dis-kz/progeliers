namespace Synectix
{
    partial class frmReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSourceBase = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSourceAnalog = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport));
            this.bs_dtReport = new System.Windows.Forms.BindingSource(this.components);
            this.dsReport = new Synectix.dsReport();
            this.rpvCbr = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtTabAdapter = new Synectix.dsReportTableAdapters.dtTabAdapter();
            this.panel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.btnAnalog = new System.Windows.Forms.Button();
            this.btnBase = new System.Windows.Forms.Button();
            this.dsReportAnalog = new Synectix.dsReportAnalog();
            this.bs_dtReportAnalog = new System.Windows.Forms.BindingSource(this.components);
            this.dtTabAdapterAnalog = new Synectix.dsReportAnalogTableAdapters.dtTabAdapterAnalog();
            ((System.ComponentModel.ISupportInitialize)(this.bs_dtReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).BeginInit();
            this.panel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsReportAnalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_dtReportAnalog)).BeginInit();
            this.SuspendLayout();
            // 
            // bs_dtReport
            // 
            this.bs_dtReport.DataMember = "dtReport";
            this.bs_dtReport.DataSource = this.dsReport;
            // 
            // dsReport
            // 
            this.dsReport.DataSetName = "dsReport";
            this.dsReport.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpvCbr
            // 
            this.rpvCbr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.rpvCbr.BorderStyle = System.Windows.Forms.BorderStyle.None;

            reportDataSourceBase.Name = "dsReport";
            reportDataSourceBase.Value = this.bs_dtReport;
            reportDataSourceAnalog.Name = "dsReportAnalog";
            reportDataSourceAnalog.Value = this.bs_dtReportAnalog;
            this.rpvCbr.LocalReport.DataSources.Add(reportDataSourceBase);
            this.rpvCbr.LocalReport.DataSources.Add(reportDataSourceAnalog);

            this.rpvCbr.LocalReport.ReportEmbeddedResource = "Synectix.Report_CurrentBreaker.rdlc";
            this.rpvCbr.Location = new System.Drawing.Point(3, 3);
            this.rpvCbr.Name = "rpvCbr";
            this.rpvCbr.ServerReport.BearerToken = null;
            this.rpvCbr.ShowRefreshButton = false;
            this.rpvCbr.ShowStopButton = false;
            this.rpvCbr.ShowZoomControl = false;
            this.rpvCbr.Size = new System.Drawing.Size(1081, 375);
            this.rpvCbr.TabIndex = 3;
            // 
            // dtTabAdapter
            // 
            this.dtTabAdapter.ClearBeforeFill = true;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel.Controls.Add(this.buttonPanel);
            this.panel.Controls.Add(this.rpvCbr);
            this.panel.Location = new System.Drawing.Point(1, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1087, 381);
            this.panel.TabIndex = 1;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonPanel.Controls.Add(this.btnAnalog);
            this.buttonPanel.Controls.Add(this.btnBase);
            this.buttonPanel.Location = new System.Drawing.Point(594, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(491, 25);
            this.buttonPanel.TabIndex = 2;
            // 
            // btnAnalog
            // 
            this.btnAnalog.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAnalog.BackColor = System.Drawing.SystemColors.Control;
            this.btnAnalog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalog.FlatAppearance.BorderSize = 0;
            this.btnAnalog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAnalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAnalog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.btnAnalog.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalog.Image")));
            this.btnAnalog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalog.Location = new System.Drawing.Point(401, 1);
            this.btnAnalog.Name = "btnAnalog";
            this.btnAnalog.Size = new System.Drawing.Size(78, 23);
            this.btnAnalog.TabIndex = 1;
            this.btnAnalog.Text = "Аналоги";
            this.btnAnalog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnalog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnalog.UseVisualStyleBackColor = false;
            this.btnAnalog.Click += new System.EventHandler(this.btnAnalog_Click);
            // 
            // btnBase
            // 
            this.btnBase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBase.BackColor = System.Drawing.SystemColors.Control;
            this.btnBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBase.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBase.FlatAppearance.BorderSize = 0;
            this.btnBase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.btnBase.Image = ((System.Drawing.Image)(resources.GetObject("btnBase.Image")));
            this.btnBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBase.Location = new System.Drawing.Point(319, 1);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(76, 23);
            this.btnBase.TabIndex = 1;
            this.btnBase.Text = "Базовые";
            this.btnBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBase.UseVisualStyleBackColor = false;
            this.btnBase.Click += new System.EventHandler(this.btnBase_Click);
            // 
            // dsReportAnalog
            // 
            this.dsReportAnalog.DataSetName = "dsReportAnalog";
            this.dsReportAnalog.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bs_dtReportAnalog
            // 
            this.bs_dtReportAnalog.DataMember = "dtReportAnalog";
            this.bs_dtReportAnalog.DataSource = this.dsReportAnalog;
            // 
            // dtTabAdapterAnalog
            // 
            this.dtTabAdapterAnalog.ClearBeforeFill = true;
            // 
            // frmReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1089, 390);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Отчет";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.bs_dtReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsReport)).EndInit();
            this.panel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsReportAnalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs_dtReportAnalog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnBase;
        private System.Windows.Forms.Button btnAnalog;
        private System.Windows.Forms.Panel buttonPanel;
        private Microsoft.Reporting.WinForms.ReportViewer rpvCbr;
        private dsReport dsReport;
        private dsReportTableAdapters.dtTabAdapter dtTabAdapter;
        private System.Windows.Forms.BindingSource bs_dtReport;
        private dsReportAnalog dsReportAnalog;
        private System.Windows.Forms.BindingSource bs_dtReportAnalog;
        private dsReportAnalogTableAdapters.dtTabAdapterAnalog dtTabAdapterAnalog;
    }
}