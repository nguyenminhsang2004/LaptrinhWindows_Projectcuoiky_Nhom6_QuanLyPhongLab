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

namespace Project_QuanLyPhongLab.View
{
    public partial class frmThemCongViec : Form
    {
        List<string> data = new List<string>();
        public CONGVIEC job=new CONGVIEC();
        public frmThemCongViec(List<string> lst)
        {
            InitializeComponent();
            this.data = lst;
        }
        public bool Check()
        {
            epThongbao.SetError(this.txtID_DA, "");
            epThongbao.SetError(this.txtID, "");
            epThongbao.SetError(this.txtName, "");
            bool falg = true;
            if (string.Compare(data[0],this.txtID_DA.Text.Trim())!=0)
            {
                epThongbao.SetError(this.txtID_DA, "Mã dự án không được thay đổi");
                falg = false;
            }
            if (string.Compare(data[1], this.txtID.Text.Trim()) != 0)
            {
                epThongbao.SetError(this.txtID, "Mã công việc không được thay đổi");
                falg = false;
            }
            if (this.txtName.Text.Trim().Length==0)
            {
                epThongbao.SetError(this.txtName, "Bạn chưa nhập tên");
                falg = false;
            }
            return falg;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if(Check())
                DialogResult = DialogResult.OK;
        }

        private void frmThemCongViec_Load(object sender, EventArgs e)
        {
            this.txtID_DA.Text = data[0].Trim();
            this.txtID.Text = data[1].Trim();
            this.dtpHT.Value = DateTime.Parse(data[2]);
        }
    }
}
