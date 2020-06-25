using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_QuanLyPhongLab.Model;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Windows.Forms;

namespace Project_QuanLyPhongLab.Controller
{
    public class ThanhVienControllers
    {
        public static List<NHOM> getListNhom()
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var listNhom = _context.NHOMs.ToList();
                return listNhom;
            }
        }
        public static List<NHOM> getListNhom(List<string> lstr)
        {
            List<NHOM> ln = new List<NHOM>();
            using (var _context = new QUANLYPHONGLABEntities())
            {
                foreach(string str in lstr)
                {
                    var listNhom = (from n in _context.NHOMs
                                    where string.Compare(n.ID, str) == 0
                                    select n).ToList();
                    ln.Add(listNhom[0]);
                }
            }
            return ln;
        }
        public static List<string> getListNhomTV(string MaTV)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var listNhom = (from ns in _context.NHANSUs
                                where string.Compare(ns.MaThanhVien, MaTV) == 0
                                select ns.MaNhom).ToList();
                return listNhom;
            }
        }
        public static List<THANHVIEN> getListTV()
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var listTV = (from tv in _context.THANHVIENs
                              select tv).ToList();

                return listTV;
            }
        }
        public static List<string> getListIDTV(string ID)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var listIDTV = (from ns in _context.NHANSUs
                                where string.Compare(ns.MaNhom, ID) == 0
                                select ns.MaThanhVien).ToList();
                return listIDTV;
            }
        }
        public static List<THANHVIEN> getListTV(List<string> lstID)
        {
            List<THANHVIEN> dsTV = new List<THANHVIEN>();
            using (var _context = new QUANLYPHONGLABEntities())
            {
                foreach (string ID in lstID)
                {
                    var item = (from tv in _context.THANHVIENs
                                where string.Compare(tv.ID, ID) == 0
                                select tv).Single();

                    dsTV.Add(item);
                }
            }
            return dsTV;
        }
        public static bool checkNT(string ID)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var item = (from ns in _context.NHANSUs
                            where string.Compare(ns.MaThanhVien, ID) == 0 && ns.MaNT == null
                            select ns).SingleOrDefault();
                if (item!= null)
                    return true;
                else
                    return false;
            }
        }
        public static List<string> getIDNhom(string ID)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var item = (from ns in _context.NHANSUs
                            where string.Compare(ns.MaThanhVien, ID) == 0
                            select ns.MaNhom).ToList();
                return item;
            }
        }
        public static int getID()
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var ID = _context.NHOMs.Select(p => p.ID).ToList();
                return Convert.ToInt32(ID.Max());
            }
        }
        public static List<string> getJobIDList(string ID_TV)
        {
            //List<List<CONGVIEC>> dsCV = new List<List<CONGVIEC>>();
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var jobList = (from pc in _context.PHANCONGs
                               where string.Compare(pc.MaTV, ID_TV) == 0
                               select pc.MaCV).ToList();
                //dsCV.Add(jobList);

                return jobList;
            }
        }
        public static List<CONGVIEC> getJobListCV(string ID_TV)
        {
            List<CONGVIEC> dsCV = new List<CONGVIEC>();
            using (var _context = new QUANLYPHONGLABEntities())
            {
                foreach(string ID in getJobIDList(ID_TV))
                {
                    var jobList = (from cv in _context.CONGVIECs
                                   where string.Compare(cv.ID, ID) == 0
                                   select cv).SingleOrDefault();
                    dsCV.Add(jobList);   
                }
                
            }
            return dsCV;
        }
        public static int getID_NT(string ID)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var db = (from ns in _context.NHANSUs
                          where ns.MaNT == null && string.Compare(ns.MaNhom,ID)==0
                          select ns).SingleOrDefault();
                if (db != null)
                    return Convert.ToInt32(db.MaThanhVien);
                else
                    return 0;

            }
        }
        public static List<DUAN> getDA(string ID_Nhom)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var duan = (from da in _context.DUANs
                            where string.Compare(da.Nhom, ID_Nhom) == 0
                            select da).ToList();
                return duan;
            }
        }
        public static DUAN getDA_ID(string ID_DA)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var duan = (from da in _context.DUANs
                            where string.Compare(da.ID, ID_DA) == 0
                            select da).SingleOrDefault();
                return duan;
            }
        }
        public static NGUOIQUANLY getNQL()
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var nql = (from item in _context.NGUOIQUANLies
                           select item).FirstOrDefault();
                return nql;
            }
        }
        public static List<CONGVIEC> getJobListDA(string ID_DA)
        {
            //List<CONGVIEC> dsCV = new List<CONGVIEC>();
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var dsCV = (from cv in _context.CONGVIECs
                              where string.Compare(cv.MaDA, ID_DA) == 0
                              select cv).ToList();
                return dsCV;
            }
        }
        public static THANHVIEN getTV(string ID)
        {
            using(var _context =new QUANLYPHONGLABEntities())
            {
                //var tv = _context.THANHVIENs.Find(ID);
                //return tv;
                var dbtv = (from tv in _context.THANHVIENs
                            where string.Compare(tv.ID,ID) == 0
                            select tv).SingleOrDefault();
                return dbtv;
            }
        }
        public static bool Add_UpdateTV(THANHVIEN tv)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                _context.THANHVIENs.AddOrUpdate(tv);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool UpdateNQL(NGUOIQUANLY nql)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                _context.NGUOIQUANLies.AddOrUpdate(nql);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool updateDA(DUAN da)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                _context.DUANs.AddOrUpdate(da);
                _context.SaveChanges();
                return true;
            }
        }
        public static List<THANHVIEN> getListTVTheoDK(string ID)
        {
            using(var _context =new QUANLYPHONGLABEntities())
            {
                var dbtv = _context.THANHVIENs.Where(p => p.HoTen.Trim().Contains(ID)).ToList();
                return dbtv;
            }
        }
        public static List<DUAN> getListDA()
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var listDA = (from da in _context.DUANs
                                select da).ToList();
                return listDA;
            }
        }
        public static List<DUAN> getListDA(string ID_T)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var listDA = (from da in _context.DUANs
                              where string.Compare(da.Nhom,ID_T)==0
                              select da).ToList();
                return listDA;
            }
        }
        public static string getIDlastDA()
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var listDA = (from da in _context.DUANs
                              select da).ToList();
                return listDA[listDA.Count - 1].ID.Trim();
            }
        }
        public static bool checkNT_IDTeam(string ID)
        {
            using(var _context =new QUANLYPHONGLABEntities())
            {
                var item = (from ns in _context.NHANSUs
                            where string.Compare(ns.MaNhom, ID) == 0 && ns.MaNT == null
                            select ns).SingleOrDefault();
                if (item != null)
                    return false;
                else
                    return true;
            }
        }
        public static int getIDLastTV()
        {
            using (var _context=new QUANLYPHONGLABEntities())
            {
                var db = (from tv in _context.THANHVIENs
                          select tv).ToList();
                return Convert.ToInt32(db[db.Count - 1].ID.Trim()) + 1;
            }
        }
        public static bool Add_Update_NS(NHANSU ns)
        {
            using(var _context=new QUANLYPHONGLABEntities())
            {
                _context.NHANSUs.AddOrUpdate(ns);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool Delete_TV(THANHVIEN tv)
        {
            using(var _context=new QUANLYPHONGLABEntities())
            {
                var dbns = (from ns in _context.NHANSUs
                            where string.Compare(ns.MaThanhVien, tv.ID) == 0
                            select ns).ToList();
                foreach (NHANSU item in dbns)
                {
                    _context.NHANSUs.Remove(item);
                    _context.SaveChanges();
                }
                var dbcv = (from pc in _context.PHANCONGs
                            where string.Compare(pc.MaTV, tv.ID) == 0
                            select pc.MaCV).ToList();
                foreach(string ID in dbcv)
                {
                    var db = (from cv in _context.CONGVIECs
                              where string.Compare(cv.ID, ID) == 0
                              select cv).SingleOrDefault();
                    _context.CONGVIECs.Remove(db);
                    _context.SaveChanges();
                }
                var dbtv = (from item in _context.THANHVIENs
                            where string.Compare(item.ID, tv.ID) == 0
                            select item).SingleOrDefault();
                _context.THANHVIENs.Remove(dbtv);
                _context.SaveChanges();
                return true;
            }
                
        }
        public static bool AddTeam(NHOM team)
        {
            using(var _context=new QUANLYPHONGLABEntities())
            {
                _context.NHOMs.AddOrUpdate(team);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool DeleteTeam(NHOM team)
        {
            using(var _context=new QUANLYPHONGLABEntities())
            {
                var dbda = (from da in _context.DUANs
                            where string.Compare(da.Nhom, team.ID) == 0
                            select da).ToList();
                foreach (DUAN it in dbda)
                {
                    _context.DUANs.Remove(it);
                    _context.SaveChanges();
                }
                var dbns = (from ns in _context.NHANSUs
                            where string.Compare(ns.MaNhom, team.ID) == 0
                            select ns).ToList();
                foreach(NHANSU ns in dbns)
                {
                    _context.NHANSUs.Remove(ns);
                    _context.SaveChanges();
                }
                var dbt = (from n in _context.NHOMs
                           where string.Compare(n.ID, team.ID) == 0
                           select n).SingleOrDefault();
                _context.NHOMs.Remove(dbt);
                _context.SaveChanges();
                return true;
            }
        }
        public static List<NHANSU> getAllNS(string ID_T)
        {
            using(var _context=new QUANLYPHONGLABEntities())
            {
                var dbns = (from ns in _context.NHANSUs
                            where string.Compare(ns.MaNhom,ID_T) == 0
                            select ns).ToList();
                return dbns;
            }
        }
        public static NHANSU getNS(string ID,string ID_T)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var dbns = (from ns in _context.NHANSUs
                            where string.Compare(ns.MaNhom, ID_T) == 0&& string.Compare(ns.MaThanhVien, ID) == 0
                            select ns).SingleOrDefault();
                return dbns;
            }
        }
        public static bool add_Update_DA(DUAN da)
        {
            using(var _context=new QUANLYPHONGLABEntities())
            {
                _context.DUANs.AddOrUpdate(da);
                _context.SaveChanges();
                return true;
            }
        }
        public static bool delete_DA(DUAN da)
        {
            using (var _context = new QUANLYPHONGLABEntities())
            {
                var dsCV = (from cv in _context.CONGVIECs
                            where string.Compare(cv.MaDA, da.ID) == 0
                            select cv).ToList();
                if (dsCV.Count > 0)
                {
                    foreach (CONGVIEC item in dsCV)
                    {
                        JobControllers.deleteJob(item);
                    }
                }
                var dbda = (from db in _context.DUANs
                            where string.Compare(db.ID, da.ID) == 0
                            select db).SingleOrDefault();
                _context.DUANs.Remove(dbda);
                _context.SaveChanges();
                return true;
            }
        }
        public static List<THANHVIEN> Find(string IDTV) 
        {
            using(var _context=new QUANLYPHONGLABEntities())
            {
                var dsTVSearch = (from tv in _context.THANHVIENs
                          where tv.ID.Contains(IDTV)
                          select tv).ToList();
                return dsTVSearch;
            }            
        }
        public static int CountTV(string ID_T)
        {
            using (var _context=new QUANLYPHONGLABEntities())
            {
                var count = (from ns in _context.NHANSUs
                             where string.Compare(ns.MaNhom, ID_T) == 0
                             select ns).ToList().Count;
                return count;
            }
        }
    }
}
