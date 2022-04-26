using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFramework_App.Models;

namespace EntityFramework_App.Areas.Admin.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands/Index
        public ActionResult Index()
        {
            CompanyDbContext company_db = new CompanyDbContext();
            List<Brand> brands = company_db.Brands.ToList();
            return View(brands);
        }
    }
}