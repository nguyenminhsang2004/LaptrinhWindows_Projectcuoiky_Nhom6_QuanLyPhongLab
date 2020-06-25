using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_QuanLyPhongLab.Model;
using Project_QuanLyPhongLab.View;
using System.Data.Entity.Migrations;

namespace Project_QuanLyPhongLab.Controller
{
    public class JobControllers
    {
        public static PHANCONG getJober(string IDJob)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var item = (from pc in _context.PHANCONGs
                            where (string.Compare(pc.MaCV, IDJob) == 0)
                            select pc).SingleOrDefault();
                return item;
            }
        }
        public static CONGVIEC getJob(string IDJob)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var item = (from cv in _context.CONGVIECs
                            where string.Compare(cv.ID, IDJob) == 0
                            select cv).SingleOrDefault();
                return item;
            }
        }
        public static bool deleteJob(CONGVIEC job)
        {
            bool falg = false;
            using (var _context = new QUANLYPHONGLABEntities())
            {

                var dbpc = (from pc in _context.PHANCONGs
                            where string.Compare(pc.MaCV, job.ID) == 0
                            select pc).SingleOrDefault();
                var dbcv = (from cv in _context.CONGVIECs
                            where string.Compare(cv.ID, job.ID) == 0
                            select cv).SingleOrDefault();
                if (dbpc != null && dbcv != null)
                {
                    _context.PHANCONGs.Remove(dbpc);
                    _context.CONGVIECs.Remove(dbcv);
                    _context.SaveChanges();
                    falg = true;
                }
                return falg;
            }

        }
        public static bool updeteJob(CONGVIEC job)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                _context.CONGVIECs.AddOrUpdate(job);
                _context.SaveChanges();
                return true;
            }
        }
        public static string getIDTeamDA(string ID)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var dbID = (from da in _context.DUANs
                            where string.Compare(da.ID, ID) == 0
                            select da.Nhom).SingleOrDefault();
                return dbID;
            }
        }
        public static string getIDTeamNS(string ID)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var dbID = (from ns in _context.NHANSUs
                            where string.Compare(ns.MaThanhVien, ID) == 0
                            select ns.MaNhom).SingleOrDefault();
                return dbID;
            }
        }
        public static CONGVIEC getIDLastJob(string ID_DA)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var dbID = (from cv in _context.CONGVIECs
                            where string.Compare(cv.MaDA,ID_DA)==0
                            select cv).ToList();
                if(dbID.Count>0)
                    return dbID[dbID.Count - 1];
                return new CONGVIEC();
            }
        }
        public static bool addJob(CONGVIEC job)
        {
            try
            {
                using (var _context = new QUANLYPHONGLABEntities())
                {
                    _context.CONGVIECs.Add(job);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
    }
}
