using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WSite_CuaHangDienThoai.Models;
namespace WSite_CuaHangDienThoai.Areas.Admin.Controllers
{
    public class StoreController : Controller
    {
        CUAHANGDIENTHOAIEntities db = new CUAHANGDIENTHOAIEntities();
        // GET: Admin/Store
        public ActionResult Index(int? page)
        {
            IEnumerable<tb_Store> items = db.tb_Store.OrderByDescending(x => x.StoreId);
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


        public ActionResult Partial_Add() 
        {
            return PartialView();
        }

        public ActionResult Add() 
        {
             return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(tb_Store model ) 
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.Alias = WSite_CuaHangDienThoai.Models.Common.Filter.FilterChar(model.DiChi);
                db.tb_Store.Add(model);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else 
            {
                ViewBag.txt = "Lỗi thêm cửa hàng";
                return View();  
            }

           
        }



        [HttpGet]
        public ActionResult GetDistricts(string city)
        {
            // Simulate getting districts from a database based on the selected city
            List<DistrictModel> districts = new List<DistrictModel>();
            if (city == "hcm")
            {
                districts.Add(new DistrictModel { Id = 1, Name = "Quận 1" });
                districts.Add(new DistrictModel { Id = 2, Name = "Quận 2" });
                districts.Add(new DistrictModel { Id = 3, Name = "Quận 2" });
                // Add other districts of HCM City as needed
            }
            else if (city == "bentre")
            {
                districts.Add(new DistrictModel { Id = 1, Name = "Quận A" });
                districts.Add(new DistrictModel { Id = 2, Name = "Quận B" });
                // Add other districts of Bến Tre as needed
            }

            return Json(districts, JsonRequestBehavior.AllowGet);
        }





    }
}