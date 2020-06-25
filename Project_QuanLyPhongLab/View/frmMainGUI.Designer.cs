namespace Project_QuanLyPhongLab.View
{
    partial class frmMainGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainGUI));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFuntion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQL = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTV = new System.Windows.Forms.ToolStripMenuItem();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMain.Location = new System.Drawing.Point(0, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(935, 26);
            this.tabMain.TabIndex = 1;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFuntion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(935, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFuntion
            // 
            this.mnuFuntion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuQL,
            this.mnuTV});
            this.mnuFuntion.Name = "mnuFuntion";
            this.mnuFuntion.Size = new System.Drawing.Size(77, 20);
            this.mnuFuntion.Text = "&Chức năng";
            // 
            // mnuQL
            // 
            this.mnuQL.Name = "mnuQL";
            this.mnuQL.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuQL.Size = new System.Drawing.Size(172, 22);
            this.mnuQL.Text = "Quản lý";
            this.mnuQL.Click += new System.EventHandler(this.mnuQL_Click);
            // 
            // mnuTV
            // 
            this.mnuTV.Name = "mnuTV";
            this.mnuTV.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.mnuTV.Size = new System.Drawing.Size(172, 22);
            this.mnuTV.Text = "Thành viên";
            this.mnuTV.Click += new System.EventHandler(this.mnuTV_Click);
            // 
            // picMain
            // 
            this.picMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picMain.Image = global::Project_QuanLyPhongLab.Properties.Resources.LabManagerment;
            this.picMain.Location = new System.Drawing.Point(0, 50);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(935, 415);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMain.TabIndex = 4;
            this.picMain.TabStop = false;
            // 
            // frmMainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 465);
            this.Controls.Add(this.picMain);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMainGUI";
            this.Text = "Quàn lý phòng LAB";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainGUI_FormClosing);
            this.MdiChildActivate += new System.EventHandler(this.frmMainGUI_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFuntion;
        private System.Windows.Forms.ToolStripMenuItem mnuQL;
        private System.Windows.Forms.ToolStripMenuItem mnuTV;
        private System.Windows.Forms.PictureBox picMain;
    }
}