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
        public bool checkUser(string user, string pass)
        {
            if (user != "" && pass != "")
            {
                return cdal.checkUser(user,pass);
            }
            throw new Exception("ban chua dang nhap");
        }
        public Customer getCusByName(string name)
        {
            return cdal.getCusByName(name);
        }
    }
}
