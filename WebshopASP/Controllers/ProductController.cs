using DalWebshop.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebshopASP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> producten = DalWebshop.Models.Product.All();
            ViewBag.Products = producten;
            ViewBag.Categories = DalWebshop.Models.Productcategorie.All();
            ViewBag.RowCount = (producten.Count / 3) + 1;

            return View("~/Views/Product/Index.cshtml");
        }

        // GET: Product/{id}
        public ActionResult Product(string id)
        {
            if (id != null)
            {
                ViewBag.Product = DalWebshop.Models.Product.Find(id);
            }

            ViewBag.Recensies = DalWebshop.Models.Recensie.FindByProductId(Convert.ToInt32(id));

            return View("~/Views/Product/Product.cshtml");
        }

        // GET: Productcategory/{id}
        public ActionResult ProductCategorie(string id)
        {
            if (id != null)
            {
                ViewBag.Categorie = DalWebshop.Models.Product.Find(id);
            }
            return View("~/Views/Product/Product.cshtml");
        }
    }
}