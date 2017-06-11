using DalWebshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Product p = DalWebshop.Models.Product.Find(id);
                ViewBag.Product = p;
                ViewBag.Kortingen = p.RetrieveKorting();
            }

            if (Session["AuthGebruiker"] != null)
            {
                Gebruiker g = (Gebruiker)Session["AuthGebruiker"];
                ViewBag.CanReview = Recensie.CanReview(Convert.ToInt32(id), g.Id);
            }
            else
            {
                ViewBag.CanReview = false;
            }

            ViewBag.Recensies = DalWebshop.Models.Recensie.FindByProductId(Convert.ToInt32(id));

            return View("~/Views/Product/Product.cshtml");
        }

        //Get: Product/search/{String}
        public ActionResult Search(string id)
        {
            List<Product> allProducts = DalWebshop.Models.Product.All();
            ViewBag.Products = allProducts.Where(p => p.Titel.ToLower().Contains(id.ToLower()));
            ViewBag.Categories = DalWebshop.Models.Productcategorie.All();
            return View("~/Views/Product/Index.cshtml");
        }

        // GET: Productcategory/{id}
        public ActionResult ProductCategorie(string id)
        {
            if (id != null)
            {

                ViewBag.products = DalWebshop.Models.Product.GetByCategorieId(Convert.ToInt32(id));
                ViewBag.categories = Productcategorie.All();
            }
            return View("~/Views/Product/Index.cshtml");
        }



    }
}