using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL
{
    public class CustomerDAL
    {
        SmartPhoneConexts db;
        public CustomerDAL()
        {
            db = new SmartPhoneConexts();
        }
        public bool checkUser(string user, string pass)
        {
            var kq = db.Customers.Where(x=>x.CustomerID == user && x.Password == pass).ToList<Customer>();
            if (kq.Count() > 0)
            {
                return true;
            }
            return false;
        }
        public Customer getCusByName(string name)
        {
            return db.Customers.Where(x => x.CustomerID == name).FirstOrDefault();
        }
    }
}
