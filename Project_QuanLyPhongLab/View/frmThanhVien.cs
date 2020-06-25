using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_QuanLyPhongLab.Controller;
using Project_QuanLyPhongLab.Model;
using Project_QuanLyPhongLab.View;

namespace Project_QuanLyPhongLab
{
    public partial class frmThanhVien : Form
    {
        List<string> lstr = new List<string>();
        string linkurl = "";
        string ID = "";
        public frmThanhVien()
        {
            InitializeComponent();
        }
        public void loadListTeam()
        {
            cboTeam.Items.Clear();
            foreach (NHOM item in ThanhVienControllers.getListNhom())
            {
                cboTeam.Items.Add(item);
            }
        }
        public void loadFullData(List<THANHVIEN> lstTV)
        {
            lvListTV.Items.Clear();
            lvListTV.Groups.Clear();
            
            foreach (NHOM it in ThanhVienControllers.getListNhom())
            {
                ListViewGroup lvg = new ListViewGroup("Nhóm " + it.ID);
                lvListTV.Groups.Add(lvg);
                foreach (THANHVIEN item in lstTV)
                {
                    List<string> lstr = ThanhVienControllers.getListNhomTV(item.ID.Trim());
                    foreach (string str in lstr)
                    {
                        if (string.Compare(str, it.ID + "", true) == 0)
                        {
                            ListViewItem lvi = new ListViewItem((lvListTV.Items.Count + 1) + "");
                            lvi.SubItems.Add(item.ID);
                            lvi.SubItems.Add(item.HoTen);
                            lvi.SubItems.Add(Convert.ToInt32(item.GioiTinh) == 1 ? "Nam" : "Nữ");
                            string[] arr = item.NgaySinh.Value.ToString().Split(' ');
                            lvi.SubItems.Add(arr[0]);
                            lvi.SubItems.Add(item.Phone);
                            lvi.SubItems.Add(item.Email);
                            lvi.SubItems.Add(str);
                            lvi.SubItems.Add(item.ThoiGianLam + "");
                            lvi.SubItems.Add(item.ThoiGianNghi + "");
                            lvi.SubItems.Add(item.Luong + "");
                            lvi.SubItems.Add(item.Thuong + "");

                            lvListTV.Items.Add(lvi);
                            lvi.Tag = item;
                            lvi.Group = lvg;
                            if (Convert.ToInt32(item.GioiTinh) == 1)
                                lvi.ImageIndex = 1;
                            else
                                lvi.ImageIndex = 0;
                        }
                    }
                }
            }
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            loadListTeam();
            loadFullData(ThanhVienControllers.getListTV());
        }

        private void cboTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            Focuss();
            cboDaAn.Items.Clear();
            if (cboTeam.SelectedIndex == -1) return;
            NHOM nhom = cboTeam.SelectedItem as NHOM;
            if (nhom != null)
            {
                ID = nhom.ID.Trim();
                loadData(ThanhVienControllers.getListTV(ThanhVienControllers.getListIDTV(nhom.ID)), nhom.ID);
                foreach(DUAN da in ThanhVienControllers.getListDA(nhom.ID.Trim()))
                {
                    cboDaAn.Items.Add(da);
                    cboDaAn.Tag = da;
                }
                loadListTeam();
            }
            else
                loadFullData(ThanhVienControllers.getListTV());
        }

        private void loadData(List<THANHVIEN> list,string ID)
        {
            lvListTV.Items.Clear();
            lvListTV.Groups.Clear();
            ListViewGroup lvg = new ListViewGroup("Nhóm " + ID);
            lvListTV.Groups.Add(lvg);
            foreach(THANHVIEN item in list)
            {
                ListViewItem lvi = new ListViewItem((lvListTV.Items.Count + 1) + "");
                lvi.SubItems.Add(item.ID);
                lvi.SubItems.Add(item.HoTen);
                lvi.SubItems.Add(Convert.ToInt32(item.GioiTinh) == 1 ? "Nam" : "Nữ");
                string[] arr = item.NgaySinh.Value.ToString().Split(' ');
                lvi.SubItems.Add(arr[0]);
                lvi.SubItems.Add(item.Phone);
                lvi.SubItems.Add(item.Email);
                lvi.SubItems.Add(ID);
                lvi.SubItems.Add(item.ThoiGianLam + "");
                lvi.SubItems.Add(item.ThoiGianNghi + "");
                lvi.SubItems.Add(item.Luong + "");
                lvi.SubItems.Add(item.Thuong + "");

                lvListTV.Items.Add(lvi);
                lvi.Tag = item;
                lvi.Group = lvg;
                if (Convert.ToInt32(item.GioiTinh) == 1)
                    lvi.ImageIndex = 1;
                else
                    lvi.ImageIndex = 0;
            }
        }

        private void lvListTV_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lvListTV.SelectedItems.Count == 0|| lvListTV.SelectedItems.Count == -1) return;
            cboTeam.Items.Clear();
            ListViewItem lvi = lvListTV.SelectedItems[0];
            THANHVIEN tv = lvi.Tag as THANHVIEN;
            this.txtID.Text = tv.ID.Trim();
            this.txtName.Text = tv.HoTen.Trim();
            if (Convert.ToInt32(tv.GioiTinh) == 1)
                this.radNam.Checked = true;
            else
                this.radNu.Checked = true;
            if (ThanhVienControllers.checkNT(txtID.Text.Trim()))
                cbTruongNhom.Checked = true;
            else
                cbTruongNhom.Checked = false;
            foreach (NHOM n in ThanhVienControllers.getListNhom(ThanhVienControllers.getIDNhom(tv.ID)))
            {
                cboTeam.Items.Add(n);
            }
            this.dtpBirthday.Value = tv.NgaySinh.Value;
            this.txtMail.Text = tv.Email.Trim();
            this.txtPhone.Text = tv.Phone.Trim();
            string[] from = tv.ThoiGianLam.Value.ToString().Split(':');
            this.numudHoursFrom.Value = Convert.ToDecimal(from[0]);
            this.numudMinuteFrom.Value = Convert.ToDecimal(from[1]);
            string[] to = tv.ThoiGianNghi.Value.ToString().Split(':');
            this.numudHoursTo.Value = Convert.ToDecimal(to[0]);
            this.numudMinuteTo.Value = Convert.ToDecimal(to[1]);
            this.txtLuong.Text = tv.Luong.Value.ToString();
            this.txtThuong.Text = tv.Thuong.Value.ToString();

            btnCheckTV.Visible = true;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (cboDaAn.Text.Trim().Length <= 0) return;
            lstr.Clear();
            lstr.Add(cboDaAn.Text.Trim());
            lstr.Add(txtName_DA.Text.Trim());
            frmCongViec frmCV = new frmCongViec(ThanhVienControllers.getJobListDA(cboDaAn.Text.Trim()),lstr);
            if(frmCV.ShowDialog()==DialogResult.OK)
            {
                loadDA(this.cboDaAn.Text.Trim());
            }
        }
        public void loadDA(string ID_DA)
        {
            DUAN da = ThanhVienControllers.getDA_ID(ID_DA);
            if (da == null) return;
            this.cboDaAn.Text = da.ID.Trim();
            this.txtName_DA.Text = da.TenDuAn.Trim();
            this.txtTeacher.Text = ThanhVienControllers.getNQL().HoTen.Trim();
            this.txtMoTa.Text = da.MoTa.Trim();
            this.linkurl = da.TaiLieuDA.Trim();
            int td = Project_QLPLAB.CheckTienDoJob(da);
            this.txtTienDo.Text = td + "%" + "";
            DUAN duan = ThanhVienControllers.getDA_ID(ID_DA);
            duan.CheckDA = td;
            ThanhVienControllers.updateDA(duan);
            
        }
        private void btnCheckTV_Click(object sender, EventArgs e)
        {
            lstr.Clear();
            lstr.Add(txtID.Text.Trim());
            lstr.Add(txtName.Text.Trim());
            lstr.Add(cboDaAn.Text.Trim());
            frmCongViec frmCV = new frmCongViec(ThanhVienControllers.getJobListCV(txtID.Text.Trim()), lstr);
            if (frmCV.ShowDialog() == DialogResult.OK)
            {
                loadDA(this.ID);
            }
        }

        private void cboTeam_TextChanged(object sender, EventArgs e)
        {
            loadData(ThanhVienControllers.getListTV(ThanhVienControllers.getListIDTV(cboTeam.Text.Trim())), cboTeam.Text.Trim());
        }
        public void Focuss()
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.txtLuong.Clear();
            this.txtMail.Clear();
            this.txtPhone.Clear();
            this.radNam.Checked = false;
            this.radNu.Checked = false;
            this.txtLuong.Clear();
            this.txtThuong.Clear();
            this.cboDaAn.Text = "";
            this.dtpBirthday.Value = DateTime.Now;
            this.numudHoursFrom.Value = 0;
            this.numudMinuteFrom.Value = 0;
            this.numudHoursTo.Value = 0;
            this.numudMinuteTo.Value = 0;
            this.txtName_DA.Clear();
            this.txtTeacher.Clear();
            this.txtTienDo.Clear();
            this.txtMoTa.Clear();
            btnCheckTV.Visible = false;
        }
        public bool CheckWorkTime(int FromHour,int FromMinute,int ToHour,int ToMinute)
        {
            int Minute = Math.Abs(FromMinute - ToMinute);
            int Hours = ToHour - FromHour;
            if (Hours * 60 + Minute >= 120)
                return true;
            else
                return false;
        }
        public bool CheckInfo()
        {
            bool falg = true;
            int sdt = 0;
            epShow.SetError(txtID, "");
            epShow.SetError(txtName, "");
            epShow.SetError(dtpBirthday, "");
            epShow.SetError(radNam, "");
            epShow.SetError(radNu, "");
            epShow.SetError(cbTruongNhom, "");
            epShow.SetError(txtPhone, "");
            epShow.SetError(numudHoursFrom, "");
            epShow.SetError(numudHoursTo, "");
            epShow.SetError(numudMinuteFrom, "");
            epShow.SetError(numudMinuteTo, "");
            if (lvListTV.SelectedItems.Count == 0) return false;
            ListViewItem lvi = lvListTV.SelectedItems[0];
            THANHVIEN tv = lvi.Tag as THANHVIEN;
            int gt = Convert.ToInt32(tv.GioiTinh);
            bool nt = ThanhVienControllers.checkNT(this.txtID.Text.Trim());
            if (string.Compare(tv.ID.Trim(), txtID.Text.Trim()) != 0)
            {
                epShow.SetError(txtID, "Không được thay đổi ID");
                falg = false;
            }
            else if ((nt==false && cbTruongNhom.Checked==true)||(nt == true && cbTruongNhom.Checked == false))
            {
                epShow.SetError(cbTruongNhom, "Không được thay đổi nhóm trưởng");
                falg = false;
            }
            if (string.Compare(tv.HoTen.Trim(), txtName.Text.Trim()) != 0)
            {
                epShow.SetError(txtName, "Không được thay đổi tên");
                falg = false;
            }
            if (tv.NgaySinh.Value!=dtpBirthday.Value)
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
            else if(int.TryParse(this.txtPhone.Text.Trim(),out sdt)==false)
            {
                epShow.SetError(txtPhone, "Nhập sai số điện thoại");
                falg = false;
            }
            if(!txtMail.Text.Contains("@student.hcmute.edu.vn"))
            {
                epShow.SetError(txtMail, "Nhập sai email");
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
            else if(numudHoursTo.Value < 0 || numudHoursTo.Value >= 24)
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvListTV.SelectedItems.Count == 0 || lvListTV.SelectedItems.Count == -1) return;
            ListViewItem lvi = lvListTV.SelectedItems[0];
            THANHVIEN tv = lvi.Tag as THANHVIEN;
            if (CheckInfo())
            {
                tv.Email = this.txtMail.Text.Trim();
                tv.Phone = this.txtPhone.Text.Trim();
                string TimeFrom = this.numudHoursFrom.Value + ":" + this.numudMinuteFrom.Value;
                string TimeTo = this.numudHoursTo.Value + ":" + this.numudMinuteTo.Value;
                tv.ThoiGianLam = TimeSpan.Parse(TimeFrom);
                tv.ThoiGianNghi = TimeSpan.Parse(TimeTo);
                if (ThanhVienControllers.Add_UpdateTV(tv))
                {
                    MessageBox.Show(
                        "Update thành công",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    loadFullData(ThanhVienControllers.getListTV());
                }
            }
        }

        private void LinkLB_Click(object sender, EventArgs e)
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

        private void cboDaAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDaAn.SelectedIndex == -1) return;
            loadDA((cboDaAn.SelectedItem as DUAN).ID.Trim());
        }
    }
}
