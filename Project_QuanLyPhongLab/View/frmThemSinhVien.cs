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
    public partial class frmThemSinhVien : Form
    {
        public int falg;
        public frmThemSinhVien(int n)
        {
            InitializeComponent();
            this.falg = n;
        }
        private void frmThemSinhVien_Load(object sender, EventArgs e)
        {
            if (this.falg == 1)
            {
                this.txtID.Enabled = false;
                this.txtName.Enabled = false;
                this.txtEmail.Enabled = false;
                this.radNam.Enabled = false;
                this.radNu.Enabled = false;
                this.dtpBirthday.Enabled = false;
                this.txtThuong.Enabled = true;
            }
            else
            {
                this.txtID.Text = ThanhVienControllers.getIDLastTV() + "";
                this.txtEmail.Text = ThanhVienControllers.getIDLastTV() + "@student.hcmute.edu.vn";
                this.txtThuong.Text = 0 + "";
                this.txtEmail.Enabled = false;
                this.txtID.Enabled = false;
                this.txtThuong.Enabled = false;
                showListTeam();
            } 
        }

        private void showListTeam()
        {
            cboTeam.Items.Clear();
            foreach (NHOM item in ThanhVienControllers.getListNhom())
            {
                cboTeam.Items.Add(item);
                cboTeam.Tag = item;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.falg == 1 && CheckInfo()) 
                DialogResult = DialogResult.OK;
            else if (CheckInfo() && CheckTuoi(this.dtpBirthday.Value)&&CheckNT())
                DialogResult = DialogResult.OK;
        }
        public bool CheckInfo()
        {
            bool falg = true;
            int sdt = 0;
            epShow.SetError(txtName, "");
            epShow.SetError(radNam, "");
            epShow.SetError(radNu, "");
            epShow.SetError(txtPhone, "");
            epShow.SetError(txtAddress, "");
            epShow.SetError(txtThuong, "");
            epShow.SetError(txtLuong, "");
            epShow.SetError(cboTeam, "");
            epShow.SetError(numudHoursFrom, "");
            epShow.SetError(numudHoursTo, "");
            epShow.SetError(numudMinuteFrom, "");
            epShow.SetError(numudMinuteTo, "");
            if (this.txtName.Text.Trim().Length == 0)
            {
                epShow.SetError(txtName, "Bạn chưa nhập tên");
                falg = false;
            }
            if(radNam.Checked==false&&radNu.Checked==false)
            {
                epShow.SetError(radNam, "Bạn chưa chọn giới tính");
                epShow.SetError(radNu, "Bạn chưa chọn giới tính");
                falg = false;
            }
            if (this.txtAddress.Text.Trim().Length == 0)
            {
                epShow.SetError(txtAddress, "Bạn chưa nhập địa chỉ");
                falg = false;
            }
            if (this.txtLuong.Text.Trim().Length == 0)
            {
                epShow.SetError(txtLuong, "Bạn chưa nhập lương");
                falg = false;
            }
            else if (int.TryParse(this.txtLuong.Text.Trim(),out sdt) == false)
            {
                epShow.SetError(txtLuong, "Bạn nhập sai lương");
                falg = false;
            }
            if (this.txtThuong.Text.Trim().Length == 0)
            {
                epShow.SetError(txtThuong, "Bạn chưa nhập thưởng");
                falg = false;
            }
            if (this.cboTeam.SelectedIndex == -1)
            {
                epShow.SetError(cboTeam, "Bạn chưa chọn nhóm");
                falg = false;
            }
            if (this.txtPhone.Text.Trim().Length == 0)
            {
                epShow.SetError(txtPhone, "Bạn chưa nhập số điện thoại");
                falg = false;
            }
            else if (this.txtPhone.Text.Trim().Length != 10)
            {
                epShow.SetError(txtPhone, "Số điện thoại phải đủ 10 số");
                falg = false;
            }
            else if (int.TryParse(this.txtPhone.Text.Trim(), out sdt) == false)
            {
                epShow.SetError(txtPhone, "Nhập sai số điện thoại");
                falg = false;
            }
            if (numudHoursFrom.Value < 0 || numudHoursFrom.Value >= 24)
            {
                epShow.SetError(numudHoursFrom, "Thời gian làm không hợp lệ");
                falg = false;
            }
            else if (numudMinuteFrom.Value < 0 || numudMinuteFrom.Value >= 60)
            {
                epShow.SetError(numudMinuteFrom, "Thời gian làm không hợp lệ");
                falg = false;
            }
            else if (numudHoursTo.Value < 0 || numudHoursTo.Value >= 24)
            {
                epShow.SetError(numudHoursTo, "Thời gian nghỉ không hợp lệ");
                falg = false;
            }
            else if (numudMinuteTo.Value < 0 || numudMinuteTo.Value >= 60)
            {
                epShow.SetError(numudMinuteTo, "Thời gian nghỉ không hợp lệ");
                falg = false;
            }
            else if (numudHoursFrom.Value < 8 || numudHoursFrom.Value >= 23)
            {
                epShow.SetError(numudHoursFrom, "Thời gian làm bạn chọn sai với quy định");
                falg = false;
            }
            else if (numudHoursTo.Value < 10 || numudHoursTo.Value >= 23)
            {
                epShow.SetError(numudHoursTo, "Thời gian nghỉ bạn chọn sai với quy định");
                falg = false;
            }
            else if (numudHoursTo.Value < numudHoursFrom.Value)
            {
                epShow.SetError(numudHoursTo, "Thời gian nghỉ bạn chọn sớm hơn thời gian làm");
                epShow.SetError(numudMinuteTo, "Thời gian nghỉ bạn chọn sớm hơn thời gian làm");
                falg = false;
            }
            else if (!CheckWorkTime((int)numudHoursFrom.Value, (int)numudMinuteFrom.Value, (int)numudHoursTo.Value, (int)numudMinuteTo.Value))
            {
                epShow.SetError(numudHoursTo, "Thời gian làm tối thiểu 2 giờ");
                epShow.SetError(numudMinuteTo, "Thời gian làm tối thiểu 2 giờ");
                falg = false;
            }
            return falg;

        }
        public bool CheckWorkTime(int FromHour, int FromMinute, int ToHour, int ToMinute)
        {
            int Minute = Math.Abs(FromMinute - ToMinute);
            int Hours = ToHour - FromHour;
            if (Hours * 60 + Minute >= 60)
                return true;
            else
                return false;
        }
        public bool CheckTuoi(DateTime dt)
        {
            epShow.SetError(dtpBirthday, "");
            bool falg = true;
            int tuoi = DateTime.Now.Year - dt.Year;
            if (tuoi < 18)
            {
                epShow.SetError(dtpBirthday, "Bạn phải đủ 18 tuổi");
                falg = false;
            }
            else if (dt.Month < DateTime.Now.Month && tuoi <= 18)
            {
                epShow.SetError(dtpBirthday, "Bạn phải đủ 18 tuổi");
                falg = false;
            }
            else if (dt.Day <= DateTime.Now.Day && dt.Month <= DateTime.Now.Month && tuoi <= 18)
            {
                epShow.SetError(dtpBirthday, "Bạn phải đủ 18 tuổi");
                falg = false;
            }
            return falg;
        }
        public bool CheckNT()
        {
            epShow.SetError(cbNT, "");
            if (!ThanhVienControllers.checkNT((cboTeam.Tag as NHOM).ID.Trim())&&cbNT.Checked==true)
            {
                epShow.SetError(cbNT, "Nhóm đã có nhóm trưởng");
                return false;
            }
            return true;
        }

        private void btnShowLT_Click(object sender, EventArgs e)
        {
            showListTeam();
        }
    }
}
