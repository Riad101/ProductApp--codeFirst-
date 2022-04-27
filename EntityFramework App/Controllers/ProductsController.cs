using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework_App.Models;

namespace EntityFramework_App.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDbContext compDb = new CompanyDbContext();
        

        // GET: Products
        public ActionResult Index()
        {
            List<Product> products = compDb.Products.ToList();
            return View(products);
        }
    }
}