using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSite_CuaHangBanHangDienThoaiDiDong.Models;

namespace WSite_CuaHangBanHangDienThoaiDiDong.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product


        CUAHANGDIENTHOAIEntities db = new  CUAHANGDIENTHOAIEntities();



        public ActionResult Index(int? page )
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
    }
}