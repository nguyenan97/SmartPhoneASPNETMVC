using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
namespace GUI.Controllers
{
    public class CustomerController : Controller
    {
        CustomerBLL cbll;
        public CustomerController()
        {
            cbll = new CustomerBLL();
        }
      
        
        public ActionResult Login(Customer cm)
        {
            if (ModelState.IsValid)
            {
                var result = cbll.checkUser(cm.CustomerID, cm.Password);
                if (result == true)
                {
                    var user = cbll.getCusByName(cm.CustomerID);
                    var cusSession = new Customer();
                    cusSession.CustomerID = user.CustomerID;
                    cusSession.Password = user.Password;
                    Session.Add("DangNhap",cusSession);
                    return Content("dang nhap thanh cong");
                }
            }
            return View("Login");
        }
        public ActionResult Logout(string url)
        {
            Session.Abandon();
            if (Request.Cookies["myCookies"] != null)
            {
                HttpCookie myCookies = new HttpCookie("myCookies");
                myCookies.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookies);
            }
            return Redirect(url);
        }

    }
}