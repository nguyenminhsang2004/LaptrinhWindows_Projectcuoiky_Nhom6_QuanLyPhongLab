using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using Project_QuanLyPhongLab.Model;

namespace Project_QuanLyPhongLab.View
{
    public partial class frmInData : Form
    {
        string connectionString = @"Data Source=MINHSANG-NGUYEN\SA;Initial Catalog=QUANLYPHONGLAB;Integrated Security=True";
        public frmInData()
        {
            InitializeComponent();
        }
        SqlConnection conn = null;
        private void frmInData_Load(object sender, EventArgs e)
        {
            if (conn == null)
                conn = new SqlConnection(connectionString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(
                "SELECT ID,HoTen,CONVERT(VARCHAR(10),NgaySinh,103)NgaySinh,GioiTinh,Phone,Luong,Thuong " +
                "FROM dbo.THANHVIEN", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "THANHVIEN");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Project_QuanLyPhongLab.ReportNhanVien.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            for (int i = 0; i < ds.Tables["THANHVIEN"].Rows.Count; i++)
            {
                DataRow row = ds.Tables["THANHVIEN"].Rows[i];
                row.BeginEdit();
                if (Convert.ToInt32(row["GioiTinh"]) == 1)
                    row["GioiTinh"] = "Nam";
                else
                    row["GioiTinh"] = "Nữ";
                row.EndEdit();
            }
            rds.Value = ds.Tables[0];
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }  
    }
}
