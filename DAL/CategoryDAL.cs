using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL
{
    public class CategoryDAL
    {
        SmartPhoneConexts db;
        public CategoryDAL()
        {
            db = new SmartPhoneConexts();
        }
        public List<Category> getAllCategory()
        {
            return db.Categories.ToList();
        }
        public List<Supplier> GetAllSppulier()
        {
            return db.Suppliers.ToList();
        }
    }
}
