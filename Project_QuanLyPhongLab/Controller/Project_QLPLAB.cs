using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_QuanLyPhongLab.Controller;
using Project_QuanLyPhongLab.Model;

namespace Project_QuanLyPhongLab.Controller
{
    public class Project_QLPLAB
    {
        public static int CheckTienDoJob(DUAN da)
        {
            int td = 0;
            List<CONGVIEC> lstCV = ThanhVienControllers.getJobListDA(da.ID.Trim());
            foreach (CONGVIEC cv in lstCV)
            {
                if (cv.CheckCV == 1)
                {
                    td++;
                }
            }
            int tdcv = (int)(((double)td / lstCV.Count()) * 100);
            if (tdcv > 0)
                return tdcv;
            else
                return 0;
        }
    }
}
