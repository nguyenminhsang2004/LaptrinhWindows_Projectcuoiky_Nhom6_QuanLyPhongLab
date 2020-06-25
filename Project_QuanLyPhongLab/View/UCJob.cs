using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_QuanLyPhongLab.Controller;
using Project_QuanLyPhongLab.Model;

namespace Project_QuanLyPhongLab.View
{
    public partial class UCJob : UserControl
    {
        private CONGVIEC job;
        public string linkurl = "";

        public CONGVIEC Job { get => job; set => job = value; }

        public UCJob(CONGVIEC cv)
        {
            InitializeComponent();
            this.Job = cv;
            showInfoJob();
        }

        private void showInfoJob()
        {
            this.txtID.Text = Job.ID.Trim();
            this.txtCTCV.Text = Job.TenCV.Trim();
            this.dtpCV.Value = Job.NgayHoanThanh.Value;
            this.linkurl = Job.TaiLieuCV.Trim();
            if (Job.CheckCV == 1)
                this.cbDone.Checked = true;
            else
                this.cbDone.Checked = false;
        }
        private event EventHandler edited;
        public event EventHandler Edited
        {
            add { edited += value; }
            remove { edited -= value; }
        }
        private event EventHandler deleted;
        public event EventHandler Deleted
        {
            add { deleted += value; }
            remove { deleted -= value; }
        }
        private event EventHandler check;
        public event EventHandler Check
        {
            add { check += value; }
            remove { check -= value; }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (deleted != null)
                deleted(this, new EventArgs());
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (edited != null)
                edited(this, new EventArgs());
        }

        private void llblTL_Click(object sender, EventArgs e)
        {
            if (this.linkurl.Length == 0)
            {
                MessageBox.Show(
                    "Không có link tài liệu",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            else if (!this.linkurl.Contains("https://"))
            {
                this.linkurl = "https://" + this.linkurl;
            }
            llblTL.LinkVisited = true;
            System.Diagnostics.Process.Start(linkurl);
        }

        private void cbDone_CheckedChanged(object sender, EventArgs e)
        {
            if (check != null)
                check(this, new EventArgs());
        }
    }
}
