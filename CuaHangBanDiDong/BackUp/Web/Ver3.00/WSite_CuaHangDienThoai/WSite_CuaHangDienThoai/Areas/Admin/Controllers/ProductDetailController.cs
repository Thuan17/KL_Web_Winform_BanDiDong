using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSite_CuaHangDienThoai.Models;

namespace WSite_CuaHangDienThoai.Areas.Admin.Controllers
{
    public class ProductDetailController : Controller
    {
       CUAHANGDIENTHOAIEntities db = new CUAHANGDIENTHOAIEntities();
        // GET: Admin/ProductDetail
        public ActionResult Index(int? page)
        {

            var itemActive = db.tb_ProductDetai.FirstOrDefault(r => r.IsActive == true);
            if (itemActive != null)
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
            else
            {
                ViewBag.txt = "abc";
                return View();
            }


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
        public ActionResult Add(tb_ProductDetai model, List<string> Images, List<int> rDefault, TokenProductDetail req)
        {
            var code = new { Success = false, Code = -1, Url = "" };
            var checkTitle = db.tb_ProductDetai.FirstOrDefault(r => r.Title == req.Title);
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
                    model.IsActive = req.IsActive;
                    model.IsHot = req.IsHot;
                    model.IsFeature = req.IsFeature;
                    model.IsSale = req.IsSale;

                    model.IsHome = req.IsHome;



                    //model.CreatedBy = nvSession.TenNhanVien;
                    if (string.IsNullOrEmpty(model.Title))
                    {
                        model.SeoTitle = model.Title;
                    }
                    if (string.IsNullOrEmpty(model.Alias))
                    {
                        model.Alias = WSite_CuaHangDienThoai.Models.Common.Filter.FilterChar(model.Title);
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



        public ActionResult Edit(int? id)
        {
            ViewBag.ProductCategory = new SelectList(db.tb_ProductCategory.ToList(), "ProductCategoryId", "Title");
            ViewBag.ProductCompany = new SelectList(db.tb_ProductCompany.ToList(), "ProductCompanyId", "Title");
            var item = db.tb_ProductDetai.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tb_ProductDetai model)
        {
            if (ModelState.IsValid)
            {
                model.IsActive = false;
                model.IsHome = false;
                model.IsFeature = false;
                model.IsSale = false;
                model.IsHot = false;
                model.ModifiedDate = DateTime.Now;
                model.Alias = WSite_CuaHangDienThoai.Models.Common.Filter.FilterChar(model.Title);
                db.tb_ProductDetai.Add(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);

        }



        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.tb_ProductDetai.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }

            return Json(new { success = false });
        }

        public ActionResult IsHome(int id)
        {
            var items = db.tb_ProductDetai.Find(id);
            if (items != null)
            {
                items.IsHome = !items.IsHome;
                db.Entry(items).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isHome = items.IsHome });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsHot(int id)
        {
            var item = db.tb_ProductDetai.Find(id);
            if (item != null)
            {
                item.IsHot = !item.IsHot;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isHot = item.IsHot });
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsFeature(int id)
        {
            var item = db.tb_ProductDetai.Find(id);
            if (item != null)
            {
                item.IsFeature = !item.IsFeature;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isFeature = item.IsFeature });
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = db.tb_ProductDetai.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isSale = item.IsSale });
            }

            return Json(new { success = false });
        }


    }
}