using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
namespace BLL
{
    public class ProductBLL
    {
        ProductDAL prodal;
        public ProductBLL()
        {
            prodal = new ProductDAL();
        }
        public IEnumerable<Product> getAllProduct()
        {
            return prodal.getAllProduct();
        }
        public Product getProductByID(int id)
        {
            return prodal.getProductByID(id);
        }
    }
}
