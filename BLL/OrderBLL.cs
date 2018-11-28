using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
namespace BLL
{
    class OrderBLL
    {
        OrderDAL odal;
        public OrderBLL()
        {
            odal = new OrderDAL();
        }
        public string createNewOderByID(string makh)
        {
            if (makh != "")
            {
                return odal.createNewOderByID(makh);
            }
            throw new Exception("khach hang chua dang nhap");
        }
        public void AddOrder(Order or, List<Order_Detail> lst)
        {
           if (or != null)
            {
                odal.AddOrder(or, lst);
            }
           else
            {
                throw new Exception("ban chua chon mat hang");
            }
        }
    }
}
