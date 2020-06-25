using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_QuanLyPhongLab.View;
using Project_QuanLyPhongLab.Model;
using Project_QuanLyPhongLab.Controller;

namespace Project_QuanLyPhongLab
{
    public partial class frmNguoiQuanLy : Form
    {
        List<THANHVIEN> listSearch = new List<THANHVIEN>();
        List<THANHVIEN> dsTV = new List<THANHVIEN>();

        public frmNguoiQuanLy()
        {
            InitializeComponent();
        }
        public void showInfo()
        {
            NGUOIQUANLY nql = ThanhVienControllers.getNQL();
            this.txtID.Text = nql.ID.Trim();
            this.txtName.Text = nql.HoTen.Trim();
            this.radNam.Checked = true ? nql.GioiTinh == true : this.radNu.Checked = true;
            this.dtpBirthday.Value = nql.NgaySinh.Value;
            this.txtPhone.Text = nql.Phone.Trim();
            this.txtEmail.Text = nql.Email.Trim();
            string[] from = nql.ThoiGianLam.Value.ToString().Split(':');
            string[] to = nql.ThoiGianNghi.Value.ToString().Split(':');
            numudHoursFrom.Value = Convert.ToDecimal(from[0]);
            numudMinuteFrom.Value = Convert.ToDecimal(from[1]);
            numudHoursTo.Value = Convert.ToDecimal(to[0]);
            numudMinuteTo.Value = Convert.ToDecimal(to[1]);
        }
        public void showListTV(List<THANHVIEN> dsTV)
        {
            lvListTV.Items.Clear();
            if (dsTV.Count == 0) return;
            foreach (THANHVIEN item in dsTV)
            {
                ListViewItem lvi = new ListViewItem((lvListTV.Items.Count + 1) + "");
                lvi.SubItems.Add(item.ID);
                lvi.SubItems.Add(item.HoTen);
                lvi.SubItems.Add(Convert.ToInt32(item.GioiTinh) == 1 ? "Nam" : "Nữ");
                lvi.SubItems.Add(item.Phone);
                lvi.SubItems.Add((int)item.Luong + "");
                lvi.SubItems.Add((int)item.Thuong + "");
                lvi.SubItems.Add((int)item.Luong + (int)item.Thuong + "");
                lvListTV.Items.Add(lvi);
                lvi.Tag = item;
            }
        }
        public void showListTeam()
        {
            lvTeam.Items.Clear();
            foreach (NHOM item in ThanhVienControllers.getListNhom())
            {
                ListViewItem lvi = new ListViewItem("Nhóm "+item.ID);
                lvi.SubItems.Add(ThanhVienControllers.CountTV(item.ID.Trim()) + "");
                lvTeam.Items.Add(lvi);
                lvi.Tag = item;
            }
            
        }
        public void showDuAn()
        {
            lvDuan.Items.Clear();
            foreach (DUAN da in ThanhVienControllers.getListDA())
            {
                ListViewItem lvi = new ListViewItem(da.ID);
                lvi.SubItems.Add(da.TenDuAn);
                lvi.SubItems.Add("Nhóm " + da.Nhom);
                lvi.SubItems.Add(da.CheckDA + "%");
                lvDuan.Items.Add(lvi);
                lvi.Tag = da;
            }
        }
        private void frmGiangVien_Load(object sender, EventArgs e)
        {
            showInfo();
            showListTV(ThanhVienControllers.getListTV());
            showListTeam();
            showDuAn();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {            
            lvListTV.Items.Clear();
            showListTV(ThanhVienControllers.Find(this.txtSearchID.Text));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmInData frmData = new frmInData();
            frmData.ShowDialog();
        }
        public bool CheckInfo()
        {
            bool falg = true;
            int sdt = 0;
            CheckError();
            NGUOIQUANLY nql = ThanhVienControllers.getNQL();
            int gt = Convert.ToInt32(nql.GioiTinh.Value);
            if (string.Compare(nql.ID.Trim(), txtID.Text.Trim()) != 0)
            {
                epShow.SetError(txtID, "Không được thay đổi ID");
                falg = false;
            }
            if (string.Compare(nql.HoTen.Trim(), txtName.Text.Trim()) != 0)
            {
                epShow.SetError(txtName, "Không được thay đổi tên");
                falg = false;
            }
            if (nql.NgaySinh.Value != dtpBirthday.Value)
            {
                epShow.SetError(dtpBirthday, "Không được thay đổi ngày sinh");
                falg = false;
            }
            if ((gt == 1 && radNam.Checked == false) || (gt == 0 && radNam.Checked == true))
            {
                epShow.SetError(radNam, "Không được thay đổi giới tính");
                falg = false;
            }
            else if ((gt == 0 && radNu.Checked == false) || (gt == 1 && radNu.Checked == true))
            {
                epShow.SetError(radNu, "Không được thay đổi giới tính");
                falg = false;
            }
            if (this.txtPhone.Text.Trim().Length != 10)
            {
                epShow.SetError(txtPhone, "Số điện thoại phải đủ 10 số");
                falg = false;
            }
            else if (int.TryParse(this.txtPhone.Text.Trim(), out sdt) == false)
            {
                epShow.SetError(txtPhone, "Nhập sai số điện thoại");
                falg = false;
            }
            if (!txtEmail.Text.Contains("@hcmute.edu.vn"))
            {
                epShow.SetError(txtEmail, "Nhập sai email");
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

        private void CheckError()
        {
            epShow.SetError(txtID, "");
            epShow.SetError(txtName, "");
            epShow.SetError(dtpBirthday, "");
            epShow.SetError(radNam, "");
            epShow.SetError(radNu, "");
            epShow.SetError(txtPhone, "");
            epShow.SetError(numudHoursFrom, "");
            epShow.SetError(numudHoursTo, "");
            epShow.SetError(numudMinuteFrom, "");
            epShow.SetError(numudMinuteTo, "");
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn sửa",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                NGUOIQUANLY nql = ThanhVienControllers.getNQL();
                if (CheckInfo())
                {
                    nql.Email = this.txtEmail.Text.Trim();
                    nql.Phone = this.txtPhone.Text.Trim();
                    string TimeFrom = this.numudHoursFrom.Value + ":" + this.numudMinuteFrom.Value;
                    string TimeTo = this.numudHoursTo.Value + ":" + this.numudMinuteTo.Value;
                    nql.ThoiGianLam = TimeSpan.Parse(TimeFrom);
                    nql.ThoiGianNghi = TimeSpan.Parse(TimeTo);
                    if (ThanhVienControllers.UpdateNQL(nql))
                    {                    
                        MessageBox.Show(
                            "Update thành công",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        showInfo();
                    }
                    
                }
                showInfo();
            }
        }

        private void btnUpdateNV_Click(object sender, EventArgs e)
        {
            if (lvListTV.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Bạn đã chọn nhân viên ???",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                return;
            }
            ListViewItem lvi = lvListTV.SelectedItems[0];
            THANHVIEN tv = lvi.Tag as THANHVIEN;
            frmThemSinhVien frmEdit = new frmThemSinhVien(1);
            frmEdit.txtID.Text = tv.ID.Trim();
            frmEdit.txtName.Text = tv.HoTen.Trim();
            frmEdit.txtAddress.Text = tv.DiaChi.Trim();
            frmEdit.txtEmail.Text = tv.Email.Trim();
            frmEdit.txtLuong.Text = tv.Luong.ToString().Trim();
            frmEdit.txtThuong.Text = tv.Thuong.ToString().Trim();
            string[] from = tv.ThoiGianLam.Value.ToString().Split(':');
            string[] to = tv.ThoiGianNghi.Value.ToString().Split(':');
            frmEdit.numudHoursFrom.Value = Convert.ToDecimal(from[0]);
            frmEdit.numudMinuteFrom.Value = Convert.ToDecimal(from[1]);
            frmEdit.numudHoursTo.Value = Convert.ToDecimal(to[0]);
            frmEdit.numudMinuteTo.Value = Convert.ToDecimal(to[1]);
            frmEdit.dtpBirthday.Value = tv.NgaySinh.Value;
            frmEdit.txtPhone.Text = tv.Phone.Trim();
            if (Convert.ToInt32(tv.GioiTinh.Trim()) == 1)
                frmEdit.radNam.Checked = true;
            else
                frmEdit.radNu.Checked = true;
            frmEdit.cbNT.Checked = ThanhVienControllers.checkNT(tv.ID.Trim());
            foreach(NHOM n in ThanhVienControllers.getListNhom(ThanhVienControllers.getListNhomTV(tv.ID.Trim())))
            {
                frmEdit.cboTeam.Items.Add(n);
            }
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                tv.ID = frmEdit.txtID.Text.Trim();
                tv.HoTen = frmEdit.txtName.Text.Trim();
                tv.NgaySinh = frmEdit.dtpBirthday.Value;
                if (frmEdit.radNam.Checked == true)
                    tv.GioiTinh = 1 + "";
                else
                    tv.GioiTinh = 0 + "";
                tv.Phone = frmEdit.txtPhone.Text.Trim();
                tv.Email = frmEdit.txtEmail.Text.Trim();
                tv.DiaChi = frmEdit.txtAddress.Text.Trim();
                tv.Luong = Convert.ToDouble(frmEdit.txtLuong.Text.Trim());
                tv.Thuong = Convert.ToDouble(frmEdit.txtThuong.Text.Trim());
                string TimeFrom = frmEdit.numudHoursFrom.Value + ":" + frmEdit.numudMinuteFrom.Value;
                string TimeTo = frmEdit.numudHoursTo.Value + ":" + frmEdit.numudMinuteTo.Value;
                tv.ThoiGianLam = TimeSpan.Parse(TimeFrom);
                tv.ThoiGianNghi = TimeSpan.Parse(TimeTo);
                int t = ThanhVienControllers.getID_NT(frmEdit.cboTeam.Text);
                NHANSU nsnt = ThanhVienControllers.getNS(t + "", (frmEdit.cboTeam.SelectedItem as NHOM).ID.Trim());
                List<NHANSU> listns = ThanhVienControllers.getAllNS(frmEdit.cboTeam.Text);           
                if (frmEdit.cbNT.Checked)
                {
                    foreach (NHANSU ns in listns)
                    {
                        ns.MaNhom = frmEdit.cboTeam.Text;
                        ns.MaNT = tv.ID.Trim();
                        ThanhVienControllers.Add_Update_NS(ns);
                    }
                    NHANSU item = ThanhVienControllers.getNS(tv.ID.Trim(), frmEdit.cboTeam.Text);
                    item.MaNhom = frmEdit.cboTeam.Text;
                    item.MaThanhVien = tv.ID;
                    item.MaNT = null;
                    ThanhVienControllers.Add_Update_NS(item);
                    THANHVIEN oldTV = ThanhVienControllers.getTV(nsnt.MaThanhVien.Trim());
                    oldTV.Luong = 5000000;
                    ThanhVienControllers.Add_UpdateTV(oldTV);
                }
                if (ThanhVienControllers.Add_UpdateTV(tv))
                {
                    MessageBox.Show(
                        "Update thành công",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    showListTV(ThanhVienControllers.getListTV());
                    showListTeam();
                }
            }
        }

        private void mnuAddTV_Click(object sender, EventArgs e)
        {
            frmThemSinhVien frmAdd = new frmThemSinhVien(0);
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                THANHVIEN tv = new THANHVIEN();
                tv.ID = ThanhVienControllers.getIDLastTV() + "";
                tv.HoTen = frmAdd.txtName.Text.Trim();
                tv.NgaySinh = frmAdd.dtpBirthday.Value;
                if (frmAdd.radNam.Checked == true)
                    tv.GioiTinh = 1 + "";
                else
                    tv.GioiTinh = 0 + "";
                tv.Phone = frmAdd.txtPhone.Text.Trim();
                tv.Email = frmAdd.txtEmail.Text.Trim();
                tv.DiaChi = frmAdd.txtAddress.Text.Trim();
                tv.Luong = Convert.ToDouble(frmAdd.txtLuong.Text.Trim());
                tv.Thuong = 0;
                string TimeFrom = frmAdd.numudHoursFrom.Value + ":" + frmAdd.numudMinuteFrom.Value;
                string TimeTo = frmAdd.numudHoursTo.Value + ":" + frmAdd.numudMinuteTo.Value;
                tv.ThoiGianLam = TimeSpan.Parse(TimeFrom);
                tv.ThoiGianNghi = TimeSpan.Parse(TimeTo);
                NHANSU ns = new NHANSU();
                ns.MaThanhVien = tv.ID.Trim();
                int t = ThanhVienControllers.getID_NT((frmAdd.cboTeam.SelectedItem as NHOM).ID.Trim());
                if (t != 0)
                    ns.MaNT = t + "";
                else
                    ns.MaNT = null;
                ns.MaNhom = frmAdd.cboTeam.SelectedItem.ToString().Trim();
                if (ThanhVienControllers.Add_UpdateTV(tv) && ThanhVienControllers.Add_Update_NS(ns))
                {
                    MessageBox.Show(
                        "Add thành công",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    showListTV(ThanhVienControllers.getListTV());
                    showListTeam();
                }
            }
        }

        private void mnuDeleteTV_Click(object sender, EventArgs e)
        {
            btnDeleteNV.PerformClick();
        }

        private void btnDeleteNV_Click(object sender, EventArgs e)
        {
            if (lvListTV.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Bạn đã chọn nhân viên ???",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                return;
            }
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn xóa",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                ListViewItem lvi = lvListTV.SelectedItems[0];
                THANHVIEN tv = lvi.Tag as THANHVIEN;
                if (ThanhVienControllers.Delete_TV(tv))
                {
                    MessageBox.Show(
                        "Xóa thành công",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    showListTeam();
                    lvListTV.Items.Remove(lvi);
                }

            }
        }

        private void mnuAddNhom_Click(object sender, EventArgs e)
        {
            frmThemNhom frmAddTeam = new frmThemNhom(0);
            if (frmAddTeam.ShowDialog() == DialogResult.OK)
            {
                NHOM team = new NHOM
                {
                    ID = ThanhVienControllers.getID() + 1 + "",
                    SoThanhVien = Convert.ToInt32(frmAddTeam.txtSoTV.Text.Trim())
                };
                if (ThanhVienControllers.AddTeam(team))
                {
                    MessageBox.Show(
                        "Add nhóm thành công",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    showListTeam();
                }
            }
        }

        private void mnuDeleteNhom_Click(object sender, EventArgs e)
        {
            if (lvTeam.SelectedItems.Count == 0) return;
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn xóa",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                ListViewItem lvi = lvTeam.SelectedItems[0];
                NHOM n = lvi.Tag as NHOM;
                if (ThanhVienControllers.DeleteTeam(n))
                {
                    MessageBox.Show(
                            "Xóa thành công",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    showListTeam();
                }
            }
        }

        private void mnuAddDuAn_Click(object sender, EventArgs e)
        {
            frmThemDuAn frmAdd = new frmThemDuAn(1);
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                DUAN da = new DUAN();
                da.ID = frmAdd.txtID.Text.Trim();
                da.TenDuAn = frmAdd.txtName.Text.Trim();
                da.MoTa = frmAdd.rtxtMoTa.Text.Trim();
                da.MaNQL = frmAdd.txtIDQL.Text.Trim();
                da.NgayHoanThanh = frmAdd.dtpHoanThanh.Value;
                da.TaiLieuDA = frmAdd.txtTaiLieu.Text.Trim();
                da.Nhom = frmAdd.cboTeam.SelectedItem.ToString().Trim();
                da.CheckDA = Convert.ToInt32(frmAdd.txtCheck.Text.Trim().Substring(0,frmAdd.txtCheck.Text.Length - 1));
                if (ThanhVienControllers.add_Update_DA(da))
                {
                    MessageBox.Show(
                        "Thêm dự án mới thành công",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    showDuAn();
                }
            }
        }
        private void lvDuan_DoubleClick(object sender, EventArgs e)
        {            
            if (lvDuan.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                                "Bạn đã chọn dự án ???",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Question);
                return;
            }
            ListViewItem lvi = lvDuan.SelectedItems[0];
            DUAN da = ThanhVienControllers.getDA_ID((lvi.Tag as DUAN).ID.Trim());
            frmThemDuAn frm = new frmThemDuAn(0);
            frm.txtID.Text = da.ID;
            frm.txtName.Text = da.TenDuAn;
            frm.txtIDQL.Text = ThanhVienControllers.getNQL().ID;
            frm.txtTaiLieu.Text = da.TaiLieuDA;
            frm.rtxtMoTa.Text = da.MoTa;
            frm.dtpHoanThanh.Value = da.NgayHoanThanh.Value;
            frm.cboTeam.Text = da.Nhom;
            frm.txtCheck.Text = da.CheckDA + "%";
            DialogResult dialog = frm.ShowDialog();
            if (dialog == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                if (dialog == DialogResult.Yes)
                {
                    DialogResult dr = MessageBox.Show(
                                    "Bạn có chắc muốn xóa",
                                    "Thông báo",
                                    MessageBoxButtons.OKCancel,
                                    MessageBoxIcon.Error);
                    if (dr == DialogResult.OK)
                    {
                        if (ThanhVienControllers.delete_DA(da))
                        {
                            MessageBox.Show(
                                    "Delete thành công",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            showDuAn();
                            return;
                        }
                    }
                }
                if(dialog==DialogResult.No)
                {
                    DialogResult dr = MessageBox.Show(
                                "Bạn có chắc muốn sửa",
                                "Thông báo",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Error);
                    if (dr == DialogResult.OK)
                    {
                        da.TenDuAn = frm.txtName.Text.Trim();
                        da.MoTa = frm.rtxtMoTa.Text.Trim();
                        da.TaiLieuDA = frm.txtTaiLieu.Text.Trim();
                        da.NgayHoanThanh = frm.dtpHoanThanh.Value;
                        da.Nhom = frm.cboTeam.Text.Trim();
                        if (ThanhVienControllers.add_Update_DA(da))
                        {
                            MessageBox.Show(
                                    "Update thành công",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            showDuAn();

                            return;
                        }
                    }
                }
            }
        }
        private void lvTeam_DoubleClick(object sender, EventArgs e)
        {
            if (lvTeam.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Bạn đã chọn nhóm ???",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                return;
            }
            ListViewItem lvi = new ListViewItem();
            NHOM team = lvTeam.SelectedItems[0].Tag as NHOM;
            frmThemNhom frm = new frmThemNhom(1);
            frm.txtID.Text = team.ID;
            frm.txtSoTV.Text = team.SoThanhVien + "";
            DialogResult dialog = frm.ShowDialog();
            if (dialog == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc muốn xóa",
                    "Thông báo",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (ThanhVienControllers.DeleteTeam(team))
                    {
                        MessageBox.Show(
                                "Xóa thành công",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        showListTeam();
                    }
                }
            }

        }
    }
}
