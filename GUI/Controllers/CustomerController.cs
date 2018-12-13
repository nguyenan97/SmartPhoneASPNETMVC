using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
using BotDetect.Web.Mvc;

namespace GUI.Controllers
{
    public class CustomerController : BaseController
    {
        CustomerBLL cbll;
        public CustomerController()
        {
            cbll = new CustomerBLL();
        }
        public ActionResult Login()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var result = cbll.checkUser(username, GUI.Common.MD5Hash.MD5(password));
                if (result == 1)
                {
                    Session["MaTK"] = username;
                    var user = cbll.getCusByName(username);
                    var cusSession = new Customer();
                    cusSession.CustomerID = user.CustomerID;
                    cusSession.Password = GUI.Common.MD5Hash.MD5(user.Password);
                    Session.Add("DangNhap", cusSession);
                    setAlert("Đăng nhập thành công", "Success");
                    return Redirect("/ShoppingCard/viewCard");
                }
                else if(result == -3)
                {
                    setAlert("Tài khoản chưa kích hoạt hoặc đang bị khóa", "Error");
                    return View();
                }
                else if (result == -2)
                {
                    var user = cbll.getCusByName(username);
                    setAlert("Sai password", "Error");
                    return View(user);
                }
                else if (result == -3)
                {
                    setAlert("Tài khoản không tồn tại", "Error");
                    return View();
                }
                else if (result == -4)
                {
                    setAlert("Bạn chưa nhập username hoặc password", "Error");
                    return View();
                }
            }
            setAlert("Đăng nhập thất bại", "Error");
            return View();
        }
        public ActionResult Logout()
        {
            Session["DangNhap"] = null;
            return RedirectToAction("Login", "Customer");
        }
        public ActionResult DangKi()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [SimpleCaptchaValidation("CaptchaCode", "ExampleCaptcha", "Sai mã captcha")]
        public ActionResult DangKi(Customer cus)
        {
            if (ModelState.IsValid)
            {
                if(cbll.CheckCusID(cus.CustomerID)>0)
                {
                    
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");                    
                }
                else
                {
                    cbll.DangKi(new Customer
                    {
                        CustomerID = cus.CustomerID,
                        Password = GUI.Common.MD5Hash.MD5(cus.Password),
                        Address = cus.Address,
                        ContactName = cus.ContactName,
                        Phone = cus.Phone,
                        Status = true
                    });

                    Login(cus.CustomerID, cus.Password);
                    setAlert("Đăng kí thành công", "Success");
                    return Redirect("/trang-chu");
                }
                
            }
            setAlert("Đăng kí thất bại", "Error");
            return View(cus);
        }

    }
}