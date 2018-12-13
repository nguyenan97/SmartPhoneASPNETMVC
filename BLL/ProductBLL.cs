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
        public List<Product> getProductByCatagoryID(int id)
        {
            return prodal.getProductByCatagoryID(id);
        }
        public bool them(Product pro)
        {
            if(pro != null)
            {
                prodal.them(pro);
                return true;
            }
            return false;            
        }
        public bool Sua(Product p)
        {
            if (p != null)
            {
                prodal.Sua(p);
                return true;
            }
            return false;
        }
    }
}
