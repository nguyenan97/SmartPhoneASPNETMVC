using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
namespace BLL
{
    public class AccountBLL
    {
        AccountDAL db;
        public AccountBLL()
        {
            db = new AccountDAL();
        }
        public int checkUser(string user, string pass)
        {
            if (user != "" && pass != "")
            {
                return db.checkUser(user, pass);
            }
            return -4; // chua nhap username pass

        }
        public Account GetByName(string us)
        {
            return db.GetByName(us);
        }
        public List<Account> GetAllAcc()
        {
            return db.GetAllAcc();
        }
        public string GetRole(string us)
        {
            return db.GetRole(us);
        }
    }
}
