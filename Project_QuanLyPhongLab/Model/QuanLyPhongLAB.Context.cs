﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_QuanLyPhongLab.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QUANLYPHONGLABEntities : DbContext
    {
        public QUANLYPHONGLABEntities()
            : base("name=QUANLYPHONGLABEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CONGVIEC> CONGVIECs { get; set; }
        public virtual DbSet<DUAN> DUANs { get; set; }
        public virtual DbSet<NGUOIQUANLY> NGUOIQUANLies { get; set; }
        public virtual DbSet<NHANSU> NHANSUs { get; set; }
        public virtual DbSet<NHOM> NHOMs { get; set; }
        public virtual DbSet<PHANCONG> PHANCONGs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<THANHVIEN> THANHVIENs { get; set; }
    }
}