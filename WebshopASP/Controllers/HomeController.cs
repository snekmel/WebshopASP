using System.Web.Mvc;
using DalWebshop.Models;

namespace WebshopASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            ViewBag.Products = Product.GetNewestProducts(4);
            return View();
        }

    
    }
}