using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DalWebshop.Models;

namespace WebshopASP.Controllers
{
    public class ManageController : Controller
    {

         
       
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