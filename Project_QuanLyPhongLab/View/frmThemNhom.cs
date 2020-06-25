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

namespace Project_QuanLyPhongLab.View
{
    public partial class frmThemNhom : Form
    {
        private int number;
        private int close = 0;
        public frmThemNhom(int n)
        {
            InitializeComponent();
            this.number = n;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.number == 0)
            {
                if (this.txtSoTV.Text.Trim().Length == 0 || Convert.ToInt32(this.txtSoTV.Text.Trim()) < 2)
                    MessageBox.Show(
                        "Mời bạn nhập lại số thành viên",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                {
                    DialogResult = DialogResult.OK;
                    this.close = 1;
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.close = 1;
            }
        }

        private void frmThemNhom_Load(object sender, EventArgs e)
        {
            if (number == 0)
            {
                this.txtID.Text = ThanhVienControllers.getID() + 1 + "";
                this.txtID.Enabled = false;
            }
            else
                btnOK.Text = "Xóa nhóm";
        }

        private void frmThemNhom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == 0)
                DialogResult = DialogResult.Cancel;
        }
    }
}
