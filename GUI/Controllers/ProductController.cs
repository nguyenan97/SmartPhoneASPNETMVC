using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
namespace GUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductBLL probll;
        CategoryBLL catebll;
        public ProductController()
        {
            probll = new ProductBLL();
            catebll = new CategoryBLL();
        }
        public ActionResult Index()
        {
            return View(probll.getAllProduct());
        }
       
        public ActionResult Detail(int id)
        {           
            return View(probll.getProductByID(id));
        }
        public ActionResult ListByCategory(int id)
        {
            return PartialView(probll.getProductByCatagoryID(id));
        }
    }
}