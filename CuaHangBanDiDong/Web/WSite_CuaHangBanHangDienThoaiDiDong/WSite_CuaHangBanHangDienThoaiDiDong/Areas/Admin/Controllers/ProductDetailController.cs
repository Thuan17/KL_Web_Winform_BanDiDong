using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList;
using WSite_CuaHangBanHangDienThoaiDiDong.Models;
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




        public ActionResult Add() 
        {
            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "ProductCategoryId", "Title");
            ViewBag.ProductCompany = new SelectList(db.tb_ProductCompany.ToList(), "ProductCompanyId", "Title");
            return View(); 
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public ActionResult Add() 
        ////{
            
        
        ////}



    }
}