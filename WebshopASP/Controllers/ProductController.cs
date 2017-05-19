using DalWebshop.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebshopASP.Controllers
{
    public class ProductController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
          //  List<Product> products = DalWebshop.Models.Product.All();

            return View("~/Views/Product/Index.cshtml");
        }

        // GET: Product/{id}
        public ActionResult Product(string id)
        {
            Product selectedProduct = DalWebshop.Models.Product.Find(id);

            ViewBag.Product = selectedProduct;
            return View("~/Views/Product/Product.cshtml");
        }
    }
}