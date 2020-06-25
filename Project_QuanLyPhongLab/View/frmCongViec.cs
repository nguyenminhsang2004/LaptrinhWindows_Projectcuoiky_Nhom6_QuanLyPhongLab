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
    public partial class frmCongViec : Form
    {
        List<CONGVIEC> lstCV = new List<CONGVIEC>();
        List<string> lst = new List<string>();
        List<string> addJob = new List<string>();
        public frmCongViec(List<CONGVIEC> dsCV,List<string> lstr)
        {
            InitializeComponent();
            lstCV = dsCV;
            lst = lstr;
        }

        private void frmCongViec_Load(object sender, EventArgs e)
        {
            showInfoJob(lstCV);
        }

        private void showInfoJob(List<CONGVIEC> listJob)
        {
            flpnJob.Controls.Clear();
            this.txtID.Text = lst[0].Trim();
            this.txtName.Text = lst[1].Trim();
            foreach (CONGVIEC cv in listJob)
            {
                UCJob job = new UCJob(cv);
                job.Edited += Job_Edited;
                job.Deleted += Job_Deleted;
                job.Check += Job_Check;
                flpnJob.Controls.Add(job);
            }
        }

        private void Job_Check(object sender, EventArgs e)
        {
            UCJob job = sender as UCJob;
            CONGVIEC cv = JobControllers.getJob(job.Job.ID);
            if (cv.CheckCV == 0)
                cv.CheckCV = 1;
            else
                cv.CheckCV = 0;
            JobControllers.updeteJob(cv);
        }
        
        private void Job_Deleted(object sender, EventArgs e)
        {           
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc muốn xóa",
                "Thông báo",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if(dr==DialogResult.OK)
            {
                UCJob job = sender as UCJob;
                if (!JobControllers.deleteJob(JobControllers.getJob(job.Job.ID)))
                {
                    MessageBox.Show(
                            "Delete thất bại",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                flpnJob.Controls.Remove(job);
            }           
        }

        private void Job_Edited(object sender, EventArgs e)
        {
            UCJob job = sender as UCJob;
            CONGVIEC cv = JobControllers.getJob(job.Job.ID);
            addJob.Clear();
            addJob.Add(getDA().ID.Trim());
            addJob.Add(cv.ID.Trim());
            addJob.Add(cv.NgayHoanThanh.ToString());
            frmThemCongViec frmTCV = new frmThemCongViec(addJob);
            if (frmTCV.ShowDialog() == DialogResult.OK)
            {
                cv.TenCV = frmTCV.txtName.Text.Trim();
                cv.NgayHoanThanh = frmTCV.dtpHT.Value;
                if (frmTCV.txtLink.Text.Length > 0) 
                    cv.TaiLieuCV = frmTCV.txtLink.Text.Trim();
                DialogResult dr = MessageBox.Show(
                    "Bạn có chắc muốn sửa",
                    "Thông báo",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    if (!JobControllers.updeteJob(cv))
                    {
                        MessageBox.Show(
                            "Update thất bại",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    //flpnJob.Controls.Remove(job);
                    //flpnJob.Controls.Add(new UCJob(JobControllers.getJob(job.Job.ID)));
                    showInfoJob(ThanhVienControllers.getJobListDA(getDA().ID.Trim()));
                }
            }
        }
        public string getIDTeam()
        {
            int temp = 0;
            if (int.TryParse(this.lst[0].Trim(), out temp) == false)
            {
                return JobControllers.getIDTeamDA(this.lst[0].Trim());
            }
            else
            {
                return JobControllers.getIDTeamNS(this.lst[0].Trim());
            }
        }
        public DUAN getDA()
        {
            int temp = 0;
            if (int.TryParse(this.lst[0].Trim(), out temp) == false)
            {
                return ThanhVienControllers.getDA_ID(this.lst[0].Trim());
                //return ThanhVienControllers.getDA(JobControllers.getIDTeamDA(this.lst[0].Trim()));
            }
            else
            {
                return ThanhVienControllers.getDA_ID(this.lst[2].Trim());
                //return ThanhVienControllers.getDA(JobControllers.getIDTeamDA(this.lst[0].Trim()));
            }
        }
        public string taoIDCV()
        {
            if (JobControllers.getIDLastJob(getDA().ID.Trim()).ID != null)
            {
                string ID = "";
                string[] arr = JobControllers.getIDLastJob(getDA().ID.Trim()).ID.Split('_');
                int ID2 = Convert.ToInt32(arr[0].Substring(2)) + 1;
                if (ID2 < 10)
                    ID = "CV" + "0" + ID2 + arr[1] + "";
                else
                    ID = "CV" + ID2 + "_" + arr[1] + "";
                return ID;
            }
            else
            {
                return "CV01_" + getDA().ID.Substring(2);
            }
        }
        private void btnAddJob_Click(object sender, EventArgs e)
        {
            addJob.Clear();
            if (getDA() == null)
            {
                MessageBox.Show(
                    "Bạn chưa chọn dự án!!!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            addJob.Add(getDA().ID.Trim());
            addJob.Add(taoIDCV().Trim());
            addJob.Add(DateTime.Now.ToString());
            frmThemCongViec frmAddJob = new frmThemCongViec(addJob);
            if(frmAddJob.ShowDialog()==DialogResult.OK)
            {
                CONGVIEC cv = new CONGVIEC {
                    ID = taoIDCV().Trim(),
                    TenCV = frmAddJob.txtName.Text.Trim(),
                    NgayHoanThanh = frmAddJob.dtpHT.Value,
                    TaiLieuCV = frmAddJob.txtLink.Text.Trim(),
                    CheckCV = 0,
                    MaDA = getDA().ID.Trim()
                };
                if (JobControllers.addJob(cv)==false)
                {
                    MessageBox.Show(
                            "Add công việc thất bại",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    return;
                }
                showInfoJob(ThanhVienControllers.getJobListDA(getDA().ID.Trim()));
            }
        }

        private void frmCongViec_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult=DialogResult.OK;
        }
    }
}
