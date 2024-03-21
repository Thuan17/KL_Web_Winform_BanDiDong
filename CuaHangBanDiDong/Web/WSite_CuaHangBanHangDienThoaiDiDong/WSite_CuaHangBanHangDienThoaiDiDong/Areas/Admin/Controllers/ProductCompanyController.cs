using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WSite_CuaHangBanHangDienThoaiDiDong.Models;
using WSite_CuaHangBanHangDienThoaiDiDong.Models.AdminToken;

namespace WSite_CuaHangBanHangDienThoaiDiDong.Areas.Admin.Controllers
{
    public class ProductCompanyController : Controller
    {
        CUAHANGDIENTHOAIEntities db =new CUAHANGDIENTHOAIEntities();
        // GET: Admin/ProductCompany
        public ActionResult Index(int? page )
        {
            IEnumerable<tb_ProductCompany> items = db.tb_ProductCompany.OrderByDescending(x => x.ProductCompanyId);
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





        public ActionResult Partial_AddProcuctCompany() 
        {


            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "ProductCategoryId", "Title");
            return PartialView();
        }

        public ActionResult Add() 
        {
            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCompany_Token req , tb_ProductCompany model )
        {
            return View();

        }




    }
}