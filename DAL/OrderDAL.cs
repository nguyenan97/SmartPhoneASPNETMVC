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
        public List<Order> GetAllOrder()
        {
            return db.Orders.ToList();

        }
        public List<Order_Detail> GetDetailOrder(string id)
        {
            var kq = db.Order_Details.Where(x => x.OrderID == id).ToList();
            return kq;
        }
        public string createNewOderByID(string makh)
        {
            DateTime dt = DateTime.Now;
            string time = "" + dt.Year + (dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString())
                + (dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString());
            string id = "";
            //object obj = db.Orders.Where(x => x.CustomerID == makh && x.OrderID.StartsWith(makh + "_" + time)).OrderBy(x => x.OrderID).FirstOrDefault();
            //object obj2 = db.Orders.Where(x => x.CustomerID == makh && x.OrderID.StartsWith(makh + "_01")).OrderBy(x => x.OrderID).FirstOrDefault();
            object obj = (from d in db.Orders
                          where d.CustomerID == makh && d.OrderID.StartsWith(makh + "_" + time)
                          orderby d.OrderID descending
                          select d.OrderID).FirstOrDefault();
            if (obj == null)
            {
                id = makh + "_" + time + "01";
            }
            else
            {
                int num = int.Parse(obj.ToString().Trim().Substring(obj.ToString().Trim().Length - 2));
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
