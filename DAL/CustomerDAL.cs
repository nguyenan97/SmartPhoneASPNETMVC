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
        public int checkUser(string user, string pass)
        {
            
            try
            {
                var kq = db.Customers.Single(x => x.CustomerID == user);
                if (kq.Password == pass)
                {
                    if(kq.Status == true)
                    {
                        return 1; // thanh cong
                    }
                    return -3; // tai khoan dang bi khoa
                }
                else
                {
                    return -2; // sai pass
                }
            }
            catch (Exception)
            {
                return 0; // tk chua ton tai
            }
        }
        public Customer getCusByName(string name)
        {
            return db.Customers.Where(x => x.CustomerID == name).FirstOrDefault();
        }
        public bool DangKi(Customer cus)
        {
            try
            {
                if(db.Customers.Where(a=>a.CustomerID == cus.CustomerID).ToList().Count > 0)
                {
                    return false;
                }
                else
                {
                    db.Customers.Add(cus);
                    db.SaveChanges();
                    return true;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int CheckCusID(string id)
        {
            return db.Customers.Where(x => x.CustomerID == id).ToList().Count;
        }
        
    }
}
