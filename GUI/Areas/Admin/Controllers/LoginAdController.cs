using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
namespace GUI.Areas.Admin.Controllers
{
    public class LoginAdController : Controller
    {
        AccountBLL abll;
        public LoginAdController()
        {
            abll = new AccountBLL();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string us, string pas)
        {
            if (ModelState.IsValid)
            {
                var result = abll.checkUser(us, Common.MD5Hash.MD5(pas));
                if (result == 1)
                {
                    
                    var user = abll.GetByName(us);
                    var cusSession = new Account();
                    cusSession.AccountID = user.AccountID;
                    cusSession.Password = user.Password;
                    Session.Add("ADMIN", cusSession);
                    
                    return Redirect("/Admin/HomeAd/Index");
                }
             
            }
            
            return View();
        }
        public ActionResult Logout()
        {
            Session["ADMIN"] = null;
            return RedirectToAction("Login", "LoginAd");
        }
    }
}