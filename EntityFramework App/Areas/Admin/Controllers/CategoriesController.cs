using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework_App.Models;

namespace EntityFramework_App.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        CompanyDbContext company_db = new CompanyDbContext();
        // GET: Categories/Index
        public ActionResult Index()
        {
            
            List<Category> categories = company_db.Categories.ToList();
            return View(categories);
        }

       /* public ActionResult CgDetails()
        {
            //Product prod = amar_db.Products.Where(pd => pd.CategoryID == id).FirstOrDefault();
            return View();
        }
       */
    }
}