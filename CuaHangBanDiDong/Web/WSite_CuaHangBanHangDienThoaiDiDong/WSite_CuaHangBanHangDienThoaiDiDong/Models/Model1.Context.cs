﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WSite_CuaHangBanHangDienThoaiDiDong.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CUAHANGDIENTHOAIEntities : DbContext
    {
        public CUAHANGDIENTHOAIEntities()
            : base("name=CUAHANGDIENTHOAIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tb_Cart> tb_Cart { get; set; }
        public virtual DbSet<tb_CartItem> tb_CartItem { get; set; }
        public virtual DbSet<tb_ExportWareHouse> tb_ExportWareHouse { get; set; }
        public virtual DbSet<tb_Function> tb_Function { get; set; }
        public virtual DbSet<tb_KhachHang> tb_KhachHang { get; set; }
        public virtual DbSet<tb_Order> tb_Order { get; set; }
        public virtual DbSet<tb_OrderDetail> tb_OrderDetail { get; set; }
        public virtual DbSet<tb_ProductCategory> tb_ProductCategory { get; set; }
        public virtual DbSet<tb_ProductCompany> tb_ProductCompany { get; set; }
        public virtual DbSet<tb_ProductDetai> tb_ProductDetai { get; set; }
        public virtual DbSet<tb_ProductDetailConnect> tb_ProductDetailConnect { get; set; }
        public virtual DbSet<tb_ProductDetailMemory> tb_ProductDetailMemory { get; set; }
        public virtual DbSet<tb_ProductDetailPin> tb_ProductDetailPin { get; set; }
        public virtual DbSet<tb_ProductDetailProcessor> tb_ProductDetailProcessor { get; set; }
        public virtual DbSet<tb_ProductImage> tb_ProductImage { get; set; }
        public virtual DbSet<tb_Return> tb_Return { get; set; }
        public virtual DbSet<tb_ReturnDetail> tb_ReturnDetail { get; set; }
        public virtual DbSet<tb_Review> tb_Review { get; set; }
        public virtual DbSet<tb_ReviewDetail> tb_ReviewDetail { get; set; }
        public virtual DbSet<tb_Role> tb_Role { get; set; }
        public virtual DbSet<tb_Staff> tb_Staff { get; set; }
        public virtual DbSet<tb_StaffImage> tb_StaffImage { get; set; }
        public virtual DbSet<tb_Voucher> tb_Voucher { get; set; }
        public virtual DbSet<tb_Warehouse> tb_Warehouse { get; set; }
    }
}
