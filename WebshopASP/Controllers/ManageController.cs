using DalWebshop.Models;
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
            return View("~/Views/Manage/Suppliers.cshtml");
        }

        //Get: Manage/Discounts
        public ActionResult Discounts()
        {
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