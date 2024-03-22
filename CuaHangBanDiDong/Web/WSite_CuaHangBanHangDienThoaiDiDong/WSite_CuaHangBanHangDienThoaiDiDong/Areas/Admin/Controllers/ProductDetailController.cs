﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList;
using WSite_CuaHangBanHangDienThoaiDiDong.Models;
using WSite_CuaHangBanHangDienThoaiDiDong.Models.AdminToken;
namespace WSite_CuaHangBanHangDienThoaiDiDong.Areas.Admin.Controllers
{
    public class ProductDetailController : Controller
    {

        CUAHANGDIENTHOAIEntities db = new CUAHANGDIENTHOAIEntities();
        // GET: Admin/ProductDetail
        public ActionResult Index(int? page)
        {
            IEnumerable<tb_ProductDetai> items = db.tb_ProductDetai.OrderByDescending(x => x.ProductDetaiId);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);

        }





        public ActionResult Partial_AddProduct()
        {
            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "ProductCategoryId", "Title");
            ViewBag.ProductCompany = new SelectList(db.tb_ProductCompany.ToList(), "ProductCompanyId", "Title");
            return PartialView();
        }






        public ActionResult Add() 
        {
            //ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "ProductCategoryId", "Title");
            //ViewBag.ProductCompany = new SelectList(db.tb_ProductCompany.ToList(), "ProductCompanyId", "Title");
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(tb_ProductDetai model, List<string> Images, List<int> rDefault, ProductDetail_Token req)
        {
            var code = new { Success = false, Code = -1, Url = "" };
            var checkTitle = db.tb_ProductDetai.FirstOrDefault(r => r.Alias == WSite_CuaHangBanHangDienThoaiDiDong.Models.Common.Filter.FilterChar(model.Title));
            if (checkTitle == null)
            {
                if (ModelState.IsValid)
                {
                    if (Images != null && Images.Count > 0)
                    {
                        for (int i = 0; i < Images.Count; i++)
                        {
                            if (i + 1 == rDefault[0])
                            {
                              model.Image = Images[i];  
                                db.tb_ProductImage.Add(new tb_ProductImage
                            {
                                ProductDetaiId = model.ProductDetaiId,
                                Image = Images[i],
                                IsDefault = true
                            });
                            }
                            else
                            {
                                db.tb_ProductImage.Add(new tb_ProductImage
                                {
                                    ProductDetaiId = model.ProductDetaiId,
                                    Image = Images[i],
                                    IsDefault = true
                                });
                            }
                        }
                    }
                    //tb_NhanVien nvSession = (tb_NhanVien)Session["user"];
                    model.CreatedDate = DateTime.Now;
                    model.ModifiedDate = DateTime.Now;
                    model.IsHome = false;
                    model.IsFeature = false;
                    model.IsActive = false;
                    model.IsSale = false;
                    //model.CreatedBy = nvSession.TenNhanVien;
                    if (string.IsNullOrEmpty(model.Title))
                    {
                        model.SeoTitle = model.Title;
                    }
                    if (string.IsNullOrEmpty(model.Alias))
                    {
                        model.Alias = WSite_CuaHangBanHangDienThoaiDiDong.Models.Common.Filter.FilterChar(model.Title);
                    }
                    db.tb_ProductDetai.Add(model);
                    db.SaveChanges();
                    code = new { Success = true, Code = 1, Url = "" };

                }
            }
            else //Ten da ton tai
            {
                code = new { Success = true, Code = -2, Url = "" };
            }


            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "ProductCategoryId", "Title");
            ViewBag.ProductCompany = new SelectList(db.tb_ProductCompany.ToList(), "ProductCompanyId", "Title");
            return Json(code);
           
        }


    }
}