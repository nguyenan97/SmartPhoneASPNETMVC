using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL
{
    public class AccountDAL
    {
        SmartPhoneConexts db;
        public AccountDAL()
        {
            db = new SmartPhoneConexts();
        }
        public int checkUser(string user, string pass)
        {

            try
            {
                var kq = db.Accounts.Single(x => x.UserName == user);
                if (kq.Password == pass)
                {
                    if (kq.Status == true)
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
        public List<Account> GetAllAcc()
        {
            return db.Accounts.ToList();
        }
        public Account GetByName(string us)
        {
            return db.Accounts.Where(x => x.UserName == us).FirstOrDefault();
        }
        public string GetRole(string us)
        {
            return db.Accounts.Where(x => x.UserName == us).FirstOrDefault().Role;
        }
    }
}
