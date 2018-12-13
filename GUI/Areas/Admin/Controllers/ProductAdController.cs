using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
namespace GUI.Areas.Admin.Controllers
{
    public class ProductAdController : BaseAdController
    {
        ProductBLL probll;
        CategoryBLL catebll;
        public ProductAdController()
        {
            catebll = new CategoryBLL();
            probll = new ProductBLL();
        }
        // GET: Admin/ProductAd
        public ActionResult Index()
        {

            return View(probll.getAllProduct());
        }
        public ActionResult Create()
        {
            ViewBag.supp = new SelectList(catebll.GetAllSppulier(), "SupplierID", "CompanyName");
            ViewBag.danhmuc = new SelectList(catebll.GetAllCategory(), "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Product p1 = new Product()
                {
                    ProductID = p.ProductID,
                    CategoryID = p.CategoryID,
                    Description = p.Description,
                    Detail = p.Detail,
                    MetaDescription = p.MetaDescription,
                    MetaKeyword = p.MetaKeyword,
                    ProductImage = p.ProductImage,
                    ProductName = p.ProductName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    SeoLink = p.SeoLink,
                    SupplierID = p.SupplierID,
                    UnitPrice = p.UnitPrice,
                    Status = p.Status
                };
                probll.them(p1);

                try
                {
                    var fhinh = Request.Files["HinhAnh"];
                    var pathhinh = Server.MapPath("~/Assets//img//" + p1.ProductID + System.IO.Path.GetExtension(fhinh.FileName));
                    fhinh.SaveAs(pathhinh);
                    p1.ProductImage = "/Assets/img/" + p1.ProductID + System.IO.Path.GetExtension(fhinh.FileName);

                    probll.Sua(p1);
                }
                catch { }
                return RedirectToAction("Index");
            }
            ViewBag.supp = new SelectList(catebll.GetAllSppulier(), "SupplierID", "CompanyName");
            ViewBag.danhmuc = new SelectList(catebll.GetAllCategory(), "CategoryID", "CategoryName");
            return View(p);
        }
        public ActionResult Edit(int idd)
        {
            Product sp = probll.getProductByID(idd);
            Product pr = new Product()
            {
                ProductID = sp.ProductID,
                CategoryID = sp.CategoryID,
                Description = sp.Description,
                Detail = sp.Detail,
                MetaDescription = sp.MetaDescription,
                MetaKeyword = sp.MetaKeyword,
                ProductImage = sp.ProductImage,
                ProductName = sp.ProductName,
                QuantityPerUnit = sp.QuantityPerUnit,
                SeoLink = sp.SeoLink,
                SupplierID = sp.SupplierID,
                UnitPrice = sp.UnitPrice,
                Status = sp.Status
            };

            ViewBag.supp = new SelectList(catebll.GetAllSppulier(), "SupplierID", "CompanyName");
            ViewBag.danhmuc = new SelectList(catebll.GetAllCategory(), "CategoryID", "CategoryName");
            return View(pr);
        }
        [HttpPost]
        public ActionResult Edit(Product sp)
        {
            if (ModelState.IsValid)
            {
                Product pr = new Product()
                {
                    ProductID = sp.ProductID,
                    CategoryID = sp.CategoryID,
                    Description = sp.Description,
                    Detail = sp.Detail,
                    MetaDescription = sp.MetaDescription,
                    MetaKeyword = sp.MetaKeyword,
                    ProductImage = sp.ProductImage,
                    ProductName = sp.ProductName,
                    QuantityPerUnit = sp.QuantityPerUnit,
                    SeoLink = sp.SeoLink,
                    SupplierID = sp.SupplierID,
                    UnitPrice = sp.UnitPrice,
                    Status = sp.Status
                };
                
                probll.Sua(pr);
                return RedirectToAction("Index");
            }
            ViewBag.supp = new SelectList(catebll.GetAllSppulier(), "SupplierID", "CompanyName");
            ViewBag.danhmuc = new SelectList(catebll.GetAllCategory(), "CategoryID", "CategoryName");
            return View(sp);
        }
    }
}