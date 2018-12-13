using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
namespace GUI.Controllers
{
    public class CategoryProController : Controller
    {
        CategoryBLL catebll;
        public CategoryProController()
        {
            catebll = new CategoryBLL();
        }
        // GET: CategoryPro
        public ActionResult Index()
        {
            return PartialView("_MenuCategoryPro",catebll.GetAllCategory());
        }
    }
}