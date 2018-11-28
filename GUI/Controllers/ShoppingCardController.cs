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
    public class ShoppingCardController : Controller
    {
        // GET: ShoppingCart
        ProductBLL probll;
        public ShoppingCardController()
        {
            probll = new ProductBLL();
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

    }
}