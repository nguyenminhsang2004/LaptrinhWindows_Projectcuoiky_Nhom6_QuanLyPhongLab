using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_QuanLyPhongLab.View
{
    public partial class frmMainGUI : Form
    {
        frmNguoiQuanLy frmQL;
        frmThanhVien frmTV;
        public frmMainGUI()
        {
            InitializeComponent();
        }

        private void mnuQL_Click(object sender, EventArgs e)
        {
            this.picMain.Visible = false;
            if (this.frmQL is null || this.frmQL.IsDisposed)
            {
                this.frmQL = new frmNguoiQuanLy();
                this.frmQL.MdiParent = this;
                this.frmQL.Show();
            }
            else
                this.frmQL.Select();
        }

        private void mnuTV_Click(object sender, EventArgs e)
        {
            this.picMain.Visible = false;
            if (this.frmTV is null || this.frmTV.IsDisposed)
            {
                this.frmTV = new frmThanhVien();
                this.frmTV.MdiParent = this;
                this.frmTV.Show();
            }
            else
                this.frmTV.Select();
        }

        private void frmMainGUI_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null) return;
            this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            if(this.ActiveMdiChild.Tag==null)
            {
                TabPage tp = new TabPage(this.ActiveMdiChild.Text);
                tp.Tag = this.ActiveMdiChild;
                tp.Parent = this.tabMain;
                this.tabMain.SelectedTab = tp;
                this.ActiveMdiChild.Tag = tp;
                this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
            ShowMain();
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedTab != null && this.tabMain.SelectedTab.Tag != null)
            {
                (this.tabMain.SelectedTab.Tag as Form).Select();
            }
        }

        private void frmMainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn thoát",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
        public void ShowMain()
        {
            if (tabMain.TabPages.Count == 0)
                this.picMain.Visible = true;
        }
    }
}
