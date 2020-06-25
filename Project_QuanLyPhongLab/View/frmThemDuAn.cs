using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_QuanLyPhongLab.Model;
using Project_QuanLyPhongLab.Controller;

namespace Project_QuanLyPhongLab.View
{
    public partial class frmThemDuAn : Form
    {
        private int number;
        private int close = 0;
        public frmThemDuAn(int n)
        {
            InitializeComponent();
            this.number = n;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Checks())
            {
                DialogResult = DialogResult.OK;
                this.close = 1;
            }
        }
        public void showListTeam()
        {
            cboTeam.Items.Clear();
            foreach (NHOM item in ThanhVienControllers.getListNhom())
            {
                cboTeam.Items.Add(item);
                cboTeam.Tag = item;
            }

        }
        public bool Checks()
        {
            epShow.SetError(txtName, "");
            epShow.SetError(txtTaiLieu, "");
            epShow.SetError(rtxtMoTa, "");
            epShow.SetError(cboTeam, "");
            epShow.SetError(dtpHoanThanh, "");
            bool falg = true;
            if (this.txtName.Text.Trim().Length == 0)
            {
                epShow.SetError(txtName, "Bạn chưa nhập tên dự án");
                falg = false;
            }
            if (this.txtTaiLieu.Text.Trim().Length == 0)
            {
                epShow.SetError(txtTaiLieu, "Bạn chưa nhập tài liệu dự án");
                falg = false;
            }
            if (this.rtxtMoTa.Text.Trim().Length == 0)
            {
                epShow.SetError(rtxtMoTa, "Bạn chưa nhập mô tả chi tiết dự án");
                falg = false;
            }
            if(this.cboTeam.Text.Trim().Length==0)
            {
                epShow.SetError(cboTeam, "Bạn chưa chọn nhóm thực hiện dự án");
                falg = false;
            }
            if (dtpHoanThanh.Value == DateTime.Now)
            {
                epShow.SetError(dtpHoanThanh, "Thời gian không hợp lệ");
                falg = false;
            }
            return falg;
        }
        private void frmThemDuAn_Load(object sender, EventArgs e)
        {
            this.txtID.Enabled = false;
            this.txtIDQL.Enabled = false;
            if (number == 1)
            {
                showListTeam();
                string[] MS = ThanhVienControllers.getIDlastDA().Split('A');
                if ((Convert.ToInt32(MS[1]) + 1) >= 10)
                    this.txtID.Text = "DA" + (Convert.ToInt32(MS[1]) + 1) + "";
                else
                    this.txtID.Text = "DA0" + (Convert.ToInt32(MS[1]) + 1) + "";
                this.txtIDQL.Text = ThanhVienControllers.getNQL().ID.Trim();
                this.txtCheck.Text = "0%";
                this.btnUpdate.Visible = false;
                this.btnDelete.Visible = false;
            }
            else
            {
                this.btnOk.Visible = false;
                showListTeam();
            }
        }
        
        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.close = 1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Checks())
            {
                DialogResult = DialogResult.No;
                this.close = 1;
            }
        }

        private void frmThemDuAn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 0)
                DialogResult = DialogResult.Cancel;
        }
    }
}
