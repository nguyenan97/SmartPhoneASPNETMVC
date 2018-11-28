using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL
    {
        SmartPhoneConexts db;
        public ProductDAL()
        {
            db = new SmartPhoneConexts();
        }
        public IEnumerable<Product> getAllProduct()
        {
            return db.Products.ToList();
        }
        public Product getProductByID(int id)
        {
            return db.Products.Where(x => x.ProductID == id).FirstOrDefault();
        }
    }
}
