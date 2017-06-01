﻿using DalWebshop.Models;
using System.Web.Mvc;

namespace WebshopASP.Controllers
{
    public class ManageController : Controller
    {
        //Get: Manage/Users
        public ActionResult Users()
        {
            return View("~/Views/Manage/Users.cshtml");
        }

        //Get: Manage/Orders
        public ActionResult Orders()
        {
            return View("~/Views/Manage/Orders.cshtml");
        }

        //Get: Manage/Suppliers
        public ActionResult Suppliers()
        {
            ViewBag.Leveranciers = Leverancier.All();
            return View("~/Views/Manage/Suppliers.cshtml");
        }

        //Get: Manage/Suppliers/{id}
        public ActionResult Supplier(string id)
        {
            ViewBag.Leveranciers = Leverancier.All();
            ViewBag.Leverancier = Leverancier.Find(id);
            return View("~/Views/Manage/Suppliers.cshtml");
        }

/*
        //Get: Manage/Supplier/New
        [HttpPost]
        public ActionResult SupplierNew()
        {
            ViewBag.Leveranciers = Leverancier.All();
            return View("~/Views/Manage/Suppliers.cshtml");
        }
*/



        //Get: Manage/Discounts/{Id}
        public ActionResult Discounts(string id)
        {

            ViewBag.Discounts = Korting.All();
            ViewBag.Products = Product.All();

            if (id != null)
            {
                ViewBag.Discount = Korting.Find(id);
            }

            return View("~/Views/Manage/Discounts.cshtml");
        }

        //Get: Manage/DiscountCoupons
        public ActionResult DiscountCoupons()
        {
            return View("~/Views/Manage/DiscountCoupons.cshtml");
        }

        // GET: Manage/Products
        public ActionResult Products()
        {
            ViewBag.Producten = Product.All();
            return View("~/Views/Manage/Products.cshtml");
        }

        [HttpPost]
        public ActionResult NewProduct(FormCollection form)
        {
            //Save product
            //Save images
            //Koppel aan product
            return this.Products();
        }
    }
}