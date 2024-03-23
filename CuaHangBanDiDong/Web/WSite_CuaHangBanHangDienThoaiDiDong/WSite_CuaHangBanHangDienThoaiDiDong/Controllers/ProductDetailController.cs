using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

using WSite_CuaHangBanHangDienThoaiDiDong.Models;

namespace WSite_CuaHangBanHangDienThoaiDiDong.Controllers
{
    public class ProductDetailController : Controller
    {
        CUAHANGDIENTHOAIEntities db =new CUAHANGDIENTHOAIEntities();    
        // GET: ProductDetail
        public ActionResult Index(int? page)
        {
          
            var itemAcite = db.tb_ProductDetai.FirstOrDefault(r => r.IsActive == true);
            if (itemAcite != null)
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
            return View();
        }

        //public ActionResult 


    }
}