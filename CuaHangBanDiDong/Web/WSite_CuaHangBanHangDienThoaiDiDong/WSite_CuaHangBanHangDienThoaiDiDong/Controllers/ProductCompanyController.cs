using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSite_CuaHangBanHangDienThoaiDiDong.Models;

namespace WSite_CuaHangBanHangDienThoaiDiDong.Controllers
{
    public class ProductCompanyController : Controller
    {
        // GET: ProductCompany
        CUAHANGDIENTHOAIEntities db = new CUAHANGDIENTHOAIEntities();   
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Partial_Title()
        {
            var item = db.tb_ProductCompany.ToList();
            return PartialView(item);   
        }
    }
}