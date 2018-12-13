using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
namespace GUI.Areas.Admin.Controllers
{
    public class OrderAdController : BaseAdController
    {
        OrderBLL obll;
        public OrderAdController()
        {
            obll = new OrderBLL();
        }
        // GET: Admin/OrderAd
        public ActionResult Index()
        {
            return View(obll.GetAllOrder());
        }
        public ActionResult Detail(string id)
        {
            return View(obll.GetDetailOderDetail(id));
        }
    }
}