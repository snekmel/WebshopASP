using DalWebshop.Models;
using System.Web.Mvc;

namespace WebshopASP.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Settings
        public ActionResult Settings()
        {
            return View("~/Views/Account/Settings.cshtml");
        }

        // GET: Account/Orders
        public ActionResult Orders(string id)
        {
            Gebruiker g = (Gebruiker)Session["AuthGebruiker"];

            if (g != null)
            {

                ViewBag.MyOrders = Order.FindOrderByGebruikerId(g.Id);
                if (id != null)
                {
                    ViewBag.Order = Order.Find(id);
                }
                return View("~/Views/Account/Orders.cshtml");
            }
            else
            {
                return View("~/Views/Auth/Login.cshtml");
            }
        }
    }
}