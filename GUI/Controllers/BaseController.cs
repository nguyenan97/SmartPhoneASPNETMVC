using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Controllers
{
    public class BaseController : Controller
    {
        

        protected void setAlert(string mess, string type)
        {
            TempData["AlertMessage"] = mess;
            if(type == "Success")
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