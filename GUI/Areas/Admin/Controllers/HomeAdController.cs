using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Areas.Admin.Controllers
{
    public class HomeAdController : BaseAdController
    {
        // GET: Admin/HomeAd
        public ActionResult Index()
        {
            return View();
        }
    }
}