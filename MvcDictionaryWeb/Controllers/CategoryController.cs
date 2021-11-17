using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcDictionaryWeb.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager cm = new CategoryManager();
        public ActionResult Index()
        {            
            return View();
        }

        public  ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetAllBl();
            return View(categoryvalues);

        }

        public ActionResult AddCategory(Category p)
        {
            cm.CategoryAddBl(p);
            return RedirectToAction("GetCategoryList");

        }
    }
}