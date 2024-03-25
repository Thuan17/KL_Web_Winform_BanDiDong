using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Configuration;
using WSite_CuaHangDienThoai.Models;

namespace WSite_CuaHangDienThoai.Areas.Admin.Controllers
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

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(tb_ProductCategory model)
        {

            if (ModelState.IsValid)
            {
                if (model.Title != null)
                {
                    model.CreatedDate = DateTime.Now;
                    model.ModifiedDate = DateTime.Now;
                    model.Alias = WSite_CuaHangDienThoai.Models.Common.Filter.FilterChar(model.Title);
                    db.tb_ProductCategory.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.txt = "Vui lòng nhập thông tin";
                    return View();
                }

            }

            return View();
        }



        public ActionResult Edit(int id)
        {
            var item = db.tb_ProductCategory.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_ProductCategory model)
        {
            if (ModelState.IsValid)
            {
                model.ModifiedDate = DateTime.Now;
                model.Alias = WSite_CuaHangDienThoai.Models.Common.Filter.FilterChar(model.Title);
                db.tb_ProductCategory.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }

    }
}