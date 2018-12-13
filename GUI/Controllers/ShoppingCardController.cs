using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using GUI.Models;

namespace GUI.Controllers
{
    public class ShoppingCardController : BaseController
    {
        // GET: ShoppingCart
        ProductBLL probll;
        OrderBLL obll;
        public ShoppingCardController()
        {
            probll = new ProductBLL();
            obll = new OrderBLL();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddCard(int id)
        {
            List<GUI.Models.ProductCart> lstCard = getCard();
            GUI.Models.ProductCart c = lstCard.Where(x => x.iProID == id).FirstOrDefault();
            if (c==null)
            {
                c = new Models.ProductCart(id);
                lstCard.Add(c);
            }
            else
            {
                lstCard[lstCard.IndexOf(c)].iQuantity += 1;
            }
            Session["Card"] = lstCard;
            //setAlert("Thêm vào giỏ hàng thành công", "Success");
            return Content(lstCard.Count().ToString());
        }
        public List<GUI.Models.ProductCart> getCard()
        {
            List<GUI.Models.ProductCart> lst = (List<GUI.Models.ProductCart>)Session["Card"];
            if (lst == null)
            {
                lst = new List<Models.ProductCart>();
                Session["Card"] = lst;
            }
            return lst;
        }
        public ActionResult viewCard()
        {
            if (Session["Card"] == null)
            {
                return RedirectToAction("Index","Product");
            }
            List<GUI.Models.ProductCart> lst = getCard();
            ViewBag.MoneySum = lst.Sum(x => x.iQuantity * x.dPrice);
            ViewBag.ThongBao = this.TempData["ThongBao"];
            return View(lst);
        }
        public ActionResult UpdateCart(string nval, string pid)
        {
            List<ProductCart> lst = (List<ProductCart>)Session["Card"];
            int id = Convert.ToInt32(pid);
            int newvalue;
            ProductCart pc = lst.Where(o => o.iProID == id).FirstOrDefault();
            newvalue = Convert.ToInt32(nval);
            pc.iQuantity = newvalue;
            return Content(string.Format("{0:0,0}", newvalue * pc.dPrice));
        }

        public ActionResult UpdateTotal()
        {
            List<ProductCart> lst = (List<ProductCart>)Session["Card"];
            return Content(string.Format("Tổng tiền: {0:0,0}", lst.Sum(o => (o.dPrice * o.iQuantity))));
        }

      
        public ActionResult payment()
        {
            if (Session["Card"] == null || Session["Card"].ToString() == "")
            {
                return Redirect("/Product/Index");
            }
            if (Session["DangNhap"] == null || Session["DangNhap"].ToString() == "")
            {
                return Redirect("/Customer/Login");
            }
            Customer cus =  (Customer)Session["DangNhap"];
            Order od = new Order();
            List<ProductCart> lst = getCard();
            od.OrderID = obll.createNewOderByID(Session["MaTK"].ToString());
            od.CustomerID = Session["MaTK"].ToString();
            od.OrderDate = DateTime.Now;
            od.RequiredDate = DateTime.Now;
            od.ShippedDate = DateTime.Now.AddDays(3);
            od.ShipAddress = cus.Address;
            od.Freight = 0;
            List<Order_Detail> lstD = new List<Order_Detail>();
            foreach (var item in lst)
            {
                Order_Detail _od = new Order_Detail();
                _od.OrderID = od.OrderID;
                _od.ProductID = item.iProID;
                _od.Quantity =(short) item.iQuantity;
                _od.UnitPrice =(decimal) item.dPrice;
                lstD.Add(_od);
            }
            obll.AddOrder(od,lstD);
            setAlert("Thanh toán thành công", "Success");
            Session["Card"] = null;           
            return Redirect("/Home/Index");
        }
        public ActionResult deletecart(int id)
        {

            var cart = (List<ProductCart>)Session["Card"];

            cart.RemoveAll(x => x.iProID== id);
            Session["Card"] = cart;
            if(cart != null )
            {
                return RedirectToAction("viewCard");
            }

            return RedirectToAction("Index", "Product");

        }
    }
}