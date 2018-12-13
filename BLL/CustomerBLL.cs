using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
namespace BLL
{
    public class CustomerBLL
    {
        CustomerDAL cdal;
        public CustomerBLL()
        {
            cdal = new CustomerDAL();
        }
        public int checkUser(string user, string pass)
        {
            if (user != "" && pass != "")
            {
                return cdal.checkUser(user,pass);
            }
            return -4; // chua nhap username pass
            
        }
        public Customer getCusByName(string name)
        {
            return cdal.getCusByName(name);
        }
        public bool DangKi(Customer cus)
        {
            if(cus != null)
            {
                cdal.DangKi(cus);
                return true;
            }
           
            return false;
            
        }
        public int CheckCusID(string id)
        {
            return cdal.CheckCusID(id);
        }
        
    }
}
