using DalWebshop.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace WebshopASP.Controllers
{
    public class OrderController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Shoppingcart()
        {
            this.SetCartOrderIfNull();

            return View("~/Views/Order/Shoppingcart.cshtml");
        }

        // GET: /ShoppingCart/Add/{id}
        public ActionResult Add(string id)
        {
            this.SetCartOrderIfNull();
            Order sessionorder = (Order)Session["CartOrder"];
            bool alreadyInList = sessionorder.Producten.Any(obj => obj.ProductId == Convert.ToInt32(id));
            if (!alreadyInList)
            {
                OrderRow or = new OrderRow(Convert.ToInt32(id), 1);
                sessionorder.Producten.Add(or);
                Session["CartOrder"] = sessionorder;
            }

            return Redirect("/ShoppingCart");
        }

        // GET: /ShoppingCart/Remove/{id}
        public ActionResult Remove(string id)
        {
            this.SetCartOrderIfNull();

            Order sessionorder = (Order)Session["CartOrder"];
            sessionorder.Producten.RemoveAll(or => or.ProductId.ToString() == id);

            Session["CartOrder"] = sessionorder;

            return Redirect("/ShoppingCart");
        }

        //Post : /Order/Coupon
        [HttpPost]
        public ActionResult Coupon(FormCollection form)
        {
            Kortingcoupon k = Kortingcoupon.FindByCode(form["kortingCoupon"]);
            if (k != null)
            {
                Order sessionorder = (Order)Session["CartOrder"];
                sessionorder.Kortingcoupon = k;
            }

            return Redirect("/ShoppingCart");
        }

        //Post : /Order/UpdateRowAmount
        [HttpPost]
        public ActionResult UpdateRowAmount(string productId, string aantal)
        {
            Order sessionorder = (Order)Session["CartOrder"];

            foreach (OrderRow or in sessionorder.Producten)
            {
                if (or.ProductId == Convert.ToInt32(productId))
                {
                    or.Aantal = Convert.ToInt32(aantal);
                }
            }

            Session["CartOrder"] = sessionorder;
            return null;
        }

        //Post : /Order/Post
        [HttpPost]
        public ActionResult Post(FormCollection form)
        {
            Order newOrder = (Order)Session["CartOrder"];
            Gebruiker loggedUser = (Gebruiker)Session["AuthGebruiker"];

            if (loggedUser == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                newOrder.GebruikerId = loggedUser.Id;
                newOrder.SaveOrUpdate();
                Session["CartOrder"] = null;
                return this.Shoppingcart();
            }
        }

        private void SetCartOrderIfNull()
        {
            if (Session["CartOrder"] == null)
            {
                Session["CartOrder"] = new Order();
            }
        }
    }
}