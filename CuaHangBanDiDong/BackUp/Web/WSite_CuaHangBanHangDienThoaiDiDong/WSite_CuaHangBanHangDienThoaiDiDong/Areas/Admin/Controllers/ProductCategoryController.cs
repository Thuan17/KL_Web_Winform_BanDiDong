using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSite_CuaHangBanHangDienThoaiDiDong.Models;

namespace WSite_CuaHangBanHangDienThoaiDiDong.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {


       CUAHANGDIENTHOAIEntities db = new CUAHANGDIENTHOAIEntities();    


        // GET: Admin/ProductCategory
        public ActionResult Index()
        {

            var items = db.tb_ProductCategory.ToList().OrderByDescending(x => x.ProductCategoryId);
            if (items == null) 
            {
                ViewBag.txt = "Không Có Loại Sản Phẩm ";
            }

            return View(items);
        }
    }
}