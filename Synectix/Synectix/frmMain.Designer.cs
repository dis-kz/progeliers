namespace Synectix
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.itemMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemProjectMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFind = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFindAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.itemFindTCO = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFindOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.itemArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLostTKP = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDoneOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFrozen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEquipMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCurBreaker = new System.Windows.Forms.ToolStripMenuItem();
            this.itemContactor = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMotorProtect = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTransformer = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTransMeasure = new System.Windows.Forms.ToolStripMenuItem();
            this.itemTransCur = new System.Windows.Forms.ToolStripMenuItem();
            this.itemModule = new System.Windows.Forms.ToolStripMenuItem();
            this.itemModuleCurBr = new System.Windows.Forms.ToolStripMenuItem();
            this.itemConfigMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemBlock = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCarcase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.itemDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.itemHelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLogin});
            this.statusStrip.Location = new System.Drawing.Point(0, 256);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(537, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tsLogin
            // 
            this.tsLogin.Name = "tsLogin";
            this.tsLogin.Size = new System.Drawing.Size(102, 17);
            this.tsLogin.Text = "Вход выполнен: ?";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMainMenu,
            this.itemProjectMenu,
            this.itemEquipMenu,
            this.itemConfigMenu,
            this.itemHelpMenu});
            this.mainMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(537, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // itemMainMenu
            // 
            this.itemMainMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.itemMainMenu.Image = global::Synectix.Properties.Resources.res_menu1;
            this.itemMainMenu.Name = "itemMainMenu";
            this.itemMainMenu.Size = new System.Drawing.Size(67, 20);
            this.itemMainMenu.Text = " &Меню";
            // 
            // itemProjectMenu
            // 
            this.itemProjectMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCreate,
            this.itemFind,
            this.toolStripMenuItem1,
            this.itemArchive});
            this.itemProjectMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.itemProjectMenu.Image = global::Synectix.Properties.Resources.res_project;
            this.itemProjectMenu.Name = "itemProjectMenu";
            this.itemProjectMenu.Size = new System.Drawing.Size(75, 20);
            this.itemProjectMenu.Text = " &Проект";
            // 
            // itemCreate
            // 
            this.itemCreate.Name = "itemCreate";
            this.itemCreate.Size = new System.Drawing.Size(152, 22);
            this.itemCreate.Text = "&Создать";
            // 
            // itemFind
            // 
            this.itemFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemFindAll,
            this.toolStripMenuItem2,
            this.itemFindTCO,
            this.itemFindOrder});
            this.itemFind.Name = "itemFind";
            this.itemFind.ShortcutKeyDisplayString = "";
            this.itemFind.Size = new System.Drawing.Size(152, 22);
            this.itemFind.Tag = "";
            this.itemFind.Text = "&Найти";
            this.itemFind.Click += new System.EventHandler(this.Item_Click);
            // 
            // itemFindAll
            // 
            this.itemFindAll.Name = "itemFindAll";
            this.itemFindAll.ShortcutKeyDisplayString = "Alt+F";
            this.itemFindAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.itemFindAll.Size = new System.Drawing.Size(195, 22);
            this.itemFindAll.Tag = "Synectix.frmProjectFind";
            this.itemFindAll.Text = "Список проектов";
            this.itemFindAll.Click += new System.EventHandler(this.itemFindAll_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(192, 6);
            // 
            // itemFindTCO
            // 
            this.itemFindTCO.Name = "itemFindTCO";
            this.itemFindTCO.ShortcutKeyDisplayString = "Alt+T";
            this.itemFindTCO.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.T)));
            this.itemFindTCO.Size = new System.Drawing.Size(195, 22);
            this.itemFindTCO.Text = "ТКП";
            this.itemFindTCO.Click += new System.EventHandler(this.itemFindTCO_Click);
            // 
            // itemFindOrder
            // 
            this.itemFindOrder.Name = "itemFindOrder";
            this.itemFindOrder.ShortcutKeyDisplayString = "Alt+O";
            this.itemFindOrder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.itemFindOrder.Size = new System.Drawing.Size(195, 22);
            this.itemFindOrder.Text = "Заказ";
            this.itemFindOrder.Click += new System.EventHandler(this.itemFindOrder_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // itemArchive
            // 
            this.itemArchive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemLostTKP,
            this.itemDoneOrder,
            this.itemFrozen});
            this.itemArchive.Name = "itemArchive";
            this.itemArchive.Size = new System.Drawing.Size(152, 22);
            this.itemArchive.Text = "&Архив";
            // 
            // itemLostTKP
            // 
            this.itemLostTKP.Name = "itemLostTKP";
            this.itemLostTKP.Size = new System.Drawing.Size(166, 22);
            this.itemLostTKP.Text = "Нереализованные";
            this.itemLostTKP.Click += new System.EventHandler(this.itemLostTKP_Click);
            // 
            // itemDoneOrder
            // 
            this.itemDoneOrder.Name = "itemDoneOrder";
            this.itemDoneOrder.Size = new System.Drawing.Size(166, 22);
            this.itemDoneOrder.Text = "Реализованные";
            this.itemDoneOrder.Click += new System.EventHandler(this.itemDoneOrder_Click);
            // 
            // itemFrozen
            // 
            this.itemFrozen.Name = "itemFrozen";
            this.itemFrozen.Size = new System.Drawing.Size(166, 22);
            this.itemFrozen.Text = "Замороженные";
            this.itemFrozen.Click += new System.EventHandler(this.itemFrozen_Click);
            // 
            // itemEquipMenu
            // 
            this.itemEquipMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemCurBreaker,
            this.itemContactor,
            this.itemMotorProtect,
            this.itemTransformer,
            this.itemModule});
            this.itemEquipMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.itemEquipMenu.Image = global::Synectix.Properties.Resources.res_equip;
            this.itemEquipMenu.Name = "itemEquipMenu";
            this.itemEquipMenu.ShowShortcutKeys = false;
            this.itemEquipMenu.Size = new System.Drawing.Size(113, 20);
            this.itemEquipMenu.Text = " &Оборудование";
            // 
            // itemCurBreaker
            // 
            this.itemCurBreaker.Name = "itemCurBreaker";
            this.itemCurBreaker.ShortcutKeyDisplayString = "     Alt+D";
            this.itemCurBreaker.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.itemCurBreaker.Size = new System.Drawing.Size(282, 22);
            this.itemCurBreaker.Tag = "";
            this.itemCurBreaker.Text = "Автоматические выключатели";
            this.itemCurBreaker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.itemCurBreaker.Click += new System.EventHandler(this.itemCurBreaker_Click);
            // 
            // itemContactor
            // 
            this.itemContactor.Name = "itemContactor";
            this.itemContactor.ShortcutKeyDisplayString = "Alt+R";
            this.itemContactor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.itemContactor.Size = new System.Drawing.Size(282, 22);
            this.itemContactor.Text = "Контакторы";
            this.itemContactor.Click += new System.EventHandler(this.itemContactor_Click);
            // 
            // itemMotorProtect
            // 
            this.itemMotorProtect.Name = "itemMotorProtect";
            this.itemMotorProtect.ShortcutKeyDisplayString = "Alt+M";
            this.itemMotorProtect.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.itemMotorProtect.Size = new System.Drawing.Size(282, 22);
            this.itemMotorProtect.Text = "Защита двигателя";
            this.itemMotorProtect.Click += new System.EventHandler(this.itemMotorProtect_Click);
            // 
            // itemTransformer
            // 
            this.itemTransformer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemTransMeasure});
            this.itemTransformer.Name = "itemTransformer";
            this.itemTransformer.Size = new System.Drawing.Size(282, 22);
            this.itemTransformer.Text = "Трансформаторы";
            // 
            // itemTransMeasure
            // 
            this.itemTransMeasure.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemTransCur});
            this.itemTransMeasure.Name = "itemTransMeasure";
            this.itemTransMeasure.Size = new System.Drawing.Size(153, 22);
            this.itemTransMeasure.Text = "измерительные";
            // 
            // itemTransCur
            // 
            this.itemTransCur.Name = "itemTransCur";
            this.itemTransCur.Size = new System.Drawing.Size(98, 22);
            this.itemTransCur.Text = "тока";
            this.itemTransCur.Click += new System.EventHandler(this.itemTransCur_Click);
            // 
            // itemModule
            // 
            this.itemModule.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemModuleCurBr});
            this.itemModule.Name = "itemModule";
            this.itemModule.Size = new System.Drawing.Size(282, 22);
            this.itemModule.Text = "Модульное оборудование";
            // 
            // itemModuleCurBr
            // 
            this.itemModuleCurBr.Name = "itemModuleCurBr";
            this.itemModuleCurBr.Size = new System.Drawing.Size(179, 22);
            this.itemModuleCurBr.Text = "автом.выключатели";
            this.itemModuleCurBr.Click += new System.EventHandler(this.itemModuleCurBr_Click);
            // 
            // itemConfigMenu
            // 
            this.itemConfigMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemBlock,
            this.itemCarcase,
            this.toolStripMenuItem3,
            this.itemDocs});
            this.itemConfigMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.itemConfigMenu.Image = global::Synectix.Properties.Resources.res_cube;
            this.itemConfigMenu.Name = "itemConfigMenu";
            this.itemConfigMenu.Size = new System.Drawing.Size(112, 20);
            this.itemConfigMenu.Text = " &Конфигуратор";
            // 
            // itemBlock
            // 
            this.itemBlock.Name = "itemBlock";
            this.itemBlock.ShortcutKeyDisplayString = "Alt+B";
            this.itemBlock.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.itemBlock.Size = new System.Drawing.Size(194, 22);
            this.itemBlock.Tag = "";
            this.itemBlock.Text = "Выдвижной блок";
            this.itemBlock.Click += new System.EventHandler(this.itemBlock_Click);
            // 
            // itemCarcase
            // 
            this.itemCarcase.Name = "itemCarcase";
            this.itemCarcase.ShortcutKeyDisplayString = "Alt+C";
            this.itemCarcase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.itemCarcase.Size = new System.Drawing.Size(194, 22);
            this.itemCarcase.Text = "Шкаф";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(191, 6);
            // 
            // itemDocs
            // 
            this.itemDocs.Name = "itemDocs";
            this.itemDocs.Size = new System.Drawing.Size(194, 22);
            this.itemDocs.Text = "Документация";
            // 
            // itemHelpMenu
            // 
            this.itemHelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAbout});
            this.itemHelpMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(36)))), ((int)(((byte)(24)))));
            this.itemHelpMenu.Image = global::Synectix.Properties.Resources.res_help;
            this.itemHelpMenu.Name = "itemHelpMenu";
            this.itemHelpMenu.Size = new System.Drawing.Size(81, 20);
            this.itemHelpMenu.Text = " &Справка";
            // 
            // itemAbout
            // 
            this.itemAbout.Name = "itemAbout";
            this.itemAbout.ShortcutKeyDisplayString = " ";
            this.itemAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.itemAbout.Size = new System.Drawing.Size(148, 22);
            this.itemAbout.Tag = "Synectix.frmAbout";
            this.itemAbout.Text = "О программе";
            this.itemAbout.Click += new System.EventHandler(this.itemAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 278);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Главное окно";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsLogin;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem itemMainMenu;
        private System.Windows.Forms.ToolStripMenuItem itemHelpMenu;
        private System.Windows.Forms.ToolStripMenuItem itemProjectMenu;
        private System.Windows.Forms.ToolStripMenuItem itemEquipMenu;
        private System.Windows.Forms.ToolStripMenuItem itemCurBreaker;
        private System.Windows.Forms.ToolStripMenuItem itemContactor;
        private System.Windows.Forms.ToolStripMenuItem itemTransformer;
        private System.Windows.Forms.ToolStripMenuItem itemTransMeasure;
        private System.Windows.Forms.ToolStripMenuItem itemTransCur;
        private System.Windows.Forms.ToolStripMenuItem itemModule;
        private System.Windows.Forms.ToolStripMenuItem itemModuleCurBr;
        private System.Windows.Forms.ToolStripMenuItem itemAbout;
        private System.Windows.Forms.ToolStripMenuItem itemArchive;
        private System.Windows.Forms.ToolStripMenuItem itemLostTKP;
        private System.Windows.Forms.ToolStripMenuItem itemDoneOrder;
        private System.Windows.Forms.ToolStripMenuItem itemFind;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem itemCreate;
        private System.Windows.Forms.ToolStripMenuItem itemFindAll;
        private System.Windows.Forms.ToolStripMenuItem itemFindTCO;
        private System.Windows.Forms.ToolStripMenuItem itemFindOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem itemFrozen;
        private System.Windows.Forms.ToolStripMenuItem itemMotorProtect;
        private System.Windows.Forms.ToolStripMenuItem itemConfigMenu;
        private System.Windows.Forms.ToolStripMenuItem itemBlock;
        private System.Windows.Forms.ToolStripMenuItem itemCarcase;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem itemDocs;
    }
}