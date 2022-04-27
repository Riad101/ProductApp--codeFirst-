﻿using EntityFramework_App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;
using static System.Net.WebRequestMethods;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework_App.Areas.Manager.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDbContext company_db = new CompanyDbContext();
        // GET: Products/index
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass = "fa-sort-asc", int pageNo = 1)
        {
            //amarDBEntities company_db = new amarDBEntities();
            List<Product> products = company_db.Products.Where(prod => prod.ProductName.Contains(search)).ToList();
            ViewBag.search = search;

            //sorting
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(pd => pd.ProductID).ToList();
                else
                    products = products.OrderByDescending(pd => pd.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(pd => pd.ProductName).ToList();
                else
                    products = products.OrderByDescending(pd => pd.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(pd => pd.Price).ToList();
                else
                    products = products.OrderByDescending(pd => pd.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(pd => pd.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(pd => pd.DateOfPurchase).ToList();
            }

            //paging
            int NoOfRecordsPerPage = 5;
            int NoOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (pageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = pageNo;
            ViewBag.NoOfPage = NoOfPage;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(products);
        }

        //method for storing image in database
        public void imageLoader(Product p)
        {
            if (Request.Files.Count >= 1)
            {
                var file = Request.Files[0];
                var imgBytes = new Byte[file.ContentLength];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64 = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                p.Photo = base64;
            }
        }

        public ActionResult Details(long id)
        {
            Product prod = company_db.Products.Where(pd => pd.ProductID == id).FirstOrDefault();
            return View(prod);
        }

        public ActionResult CgDetails(long id)
        {
            //List<Product> prod = company_db.Products.Where(pd => pd.CategoryID == id).
            //  Select(s => new { s.ProductName, s.CategoryID }).FirstOrDefault();

            var products = company_db.Products.Where(pd => pd.CategoryID == id).ToList();
            return View(products);
        }


        public ActionResult Create()
        {

            ViewBag.Categories = company_db.Categories.ToList();
            ViewBag.Brands = company_db.Brands.ToList();


            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ProductID,ProductName, Price, DateOfPurchase, AvailabilityStatus, CategoryID, BrandID, Active, Photo")] Product p)
        {
            if (ModelState.IsValid)
            {
                imageLoader(p);
                company_db.Products.Add(p);
                company_db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {             
                return View();
            }
        }


     

        public ActionResult Edit(long id)
        {
            ViewBag.Categories = company_db.Categories.ToList();
            ViewBag.Brands = company_db.Brands.ToList();

            Product existingProd = company_db.Products.Where(pd => pd.ProductID == id).FirstOrDefault();
            return View(existingProd);
        }


      
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                imageLoader(p);
                Product existingProd = company_db.Products.Where(pd => pd.ProductID == p.ProductID).FirstOrDefault();
                existingProd.ProductName = p.ProductName;
                existingProd.Price = p.Price;
                existingProd.DateOfPurchase = p.DateOfPurchase;
                existingProd.CategoryID = p.CategoryID;
                existingProd.BrandID = p.BrandID;
                existingProd.AvailabilityStatus = p.AvailabilityStatus;
                //imageLoader(existingProd);
                //existingProd.Photo = p.Photo;
                existingProd.Active = p.Active;
                company_db.SaveChanges();
            }
           
            return RedirectToAction("Index", "Products");
        }
        
    }
}