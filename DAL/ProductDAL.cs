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
        public List<Product> getProductByCatagoryID(int id)
        {
            
            return db.Products.Where(x => x.CategoryID == id).ToList();
        }
        public bool them(Product pro)
        {
            try
            {
                db.Products.Add(pro);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool Sua(Product p)
        {
            Product pro = db.Products.Where(x => x.ProductID == p.ProductID).FirstOrDefault();
            if(pro != null)
            {

                db.Entry(pro).State = System.Data.Entity.EntityState.Modified;

                pro.CategoryID = p.CategoryID;
                pro.Description = p.Description;
                pro.Detail = p.Detail;
                pro.MetaDescription = p.MetaDescription;
                pro.MetaKeyword = p.MetaKeyword;
                pro.ProductImage = p.ProductImage;
                pro.ProductName = p.ProductName;
                pro.QuantityPerUnit = p.QuantityPerUnit;
                pro.SeoLink = p.SeoLink;
                pro.SupplierID = p.SupplierID;
                pro.UnitPrice = p.UnitPrice;
                pro.Status = p.Status;
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
