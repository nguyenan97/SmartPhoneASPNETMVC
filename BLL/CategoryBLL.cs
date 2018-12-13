using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
namespace BLL
{
    public class CategoryBLL
    {
        CategoryDAL catedal;
        public CategoryBLL()
        {
            catedal = new CategoryDAL();
        }
        public List<Category> GetAllCategory()
        {
            return catedal.getAllCategory();
        }
        public List<Supplier> GetAllSppulier()
        {
            return catedal.GetAllSppulier();
        }
    }
}
