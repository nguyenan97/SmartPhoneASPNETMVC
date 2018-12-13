using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class HomeController : Controller
    {
        ProductBLL probll;
        public HomeController()
        {
            probll = new ProductBLL();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SanPhamLienQuan()
        {
            return PartialView("_SanPhamLienQuan",probll.getAllProduct());
        }

    }
}