using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;
using BLL;
namespace GUI.Models
{
    public class ProductCart
    {
        ProductBLL pbll = null;
        public int iProID { get; set; }
        public string sProName { get; set; }
        public decimal dPrice { get; set; }
        public int iQuantity { get; set; }
        public string sImg { get; set; }
        public ProductCart(int id)
        {
            pbll = new ProductBLL();
            iProID = id;
            Product sp = pbll.getProductByID(iProID);
            sProName = sp.ProductName;
            dPrice = sp.UnitPrice;
            sImg = sp.ProductImage;
            iQuantity = 1;
        }
    }
}