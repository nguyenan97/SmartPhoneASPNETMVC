using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderDAL
    {
        SmartPhoneConexts db;
        public OrderDAL()
        {
            db = new SmartPhoneConexts();
        }
        public string createNewOderByID(string makh)
        {
            DateTime dt = DateTime.Now;
            string time = "" + dt.Year + (dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString())
                + (dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString());
            string id = "";
            object obj = (from d in db.Orders
                          where d.CustomerID == makh && d.OrderID.StartsWith(makh + "_" + time)
                          orderby d.OrderID descending
                          select d.OrderID).FirstOrDefault();
            if (obj == null)
            {
                id = makh + "_" + "01";
            }
            else
            {
                int num = int.Parse(obj.ToString().Trim().Substring(
                    obj.ToString().Trim().Length - 2));
                num++;
                id = makh + "_" + time + (num < 10 ? "0" + num : "" + num); 
            }
            return id;
        }
        public void AddOrder(Order or, List<Order_Detail> lst)
        {
            db.Orders.Add(or);
            db.Order_Details.AddRange(lst);
            db.SaveChanges();
        }
    }
}
