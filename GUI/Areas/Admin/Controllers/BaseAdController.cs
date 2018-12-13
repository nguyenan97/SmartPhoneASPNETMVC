using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
namespace GUI.Areas.Admin.Controllers
{
    public class BaseAdController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (Account)Session["ADMIN"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { Controller = "LoginAd", Action = "Login" }));
            }
            base.OnActionExecuting(filterContext);
        }
        protected void setAlert(string mess, string type)
        {
            TempData["AlertMessage"] = mess;
            if (type == "Success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "Warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "Error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}