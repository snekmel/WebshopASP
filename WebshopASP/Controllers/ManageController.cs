using DalWebshop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
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

            ViewBag.Orders = DalWebshop.Models.Order.All();
            return View("~/Views/Manage/Orders.cshtml");    
        }


        //Get: Manage/Order/{id}
        public ActionResult Order(string id)
        {

            ViewBag.Orders = DalWebshop.Models.Order.All();
            ViewBag.Order = DalWebshop.Models.Order.Find(id);

            return View("~/Views/Manage/Orders.cshtml");
        }


        //POST: /Manage/OrderStatusUpdate/{newStatus}{orderId}
        [HttpPost]
        public ActionResult OrderStatusUpdate(string newStatus, string orderId)
        {
            Order selectedOrder = DalWebshop.Models.Order.Find(orderId);
            selectedOrder.Status = newStatus;
            selectedOrder.SaveOrUpdate();

            return this.Orders();

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

        //Get: Manage/Supplier/New
        [HttpPost]
        public ActionResult SupplierNew()
        {
            ViewBag.Leveranciers = Leverancier.All();
            return View("~/Views/Manage/Suppliers.cshtml");
        }

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

        //Post: Manage/DiscountNew
        [HttpPost]
        public ActionResult DiscountNew(FormCollection form)
        {
            Korting newDiscount = new Korting(Convert.ToDouble(form["Percentage"]), form["Description"], Convert.ToDateTime(form["endDate"]));
            string discountId = newDiscount.SaveOrUpdate();

            string productIds = form["productIds"];
            string[] productidList = productIds.Split(',');

            foreach (string id in productidList)
            {
                Korting.AddKortingToProduct(discountId, id);
            }

            return this.Discounts("");
        }

        //Post: Manage/DiscountUpdate
        [HttpPost]
        public ActionResult DiscountUpdate(FormCollection form)
        {
            FormCollection f = form;

            if (form["updateBtn"] != null)
            {
                Korting korting = Korting.Find(form["id"]);
                korting.EindDatum = Convert.ToDateTime(form["endDate"]);
                korting.Opmerking = form["Description"];
                korting.Kortingspercentage = Convert.ToDouble(form["discountPercentage"]);
                korting.SaveOrUpdate();
            }
            else if (form["deleteBtn"] != null)
            {
                Korting korting = Korting.Find(form["id"]);
                Korting.RemoveKortingFromProducts(korting.Id.ToString());
                korting.Delete();
            }

            return this.Discounts("");
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
            ViewBag.Leverancier = Leverancier.All();
            ViewBag.Categorien = Productcategorie.All();
            return View("~/Views/Manage/Products.cshtml");
        }

        //POST: Manage/ProductNew
        [HttpPost]
        public HtmlString ProductNew(IEnumerable<HttpPostedFileBase> images, FormCollection form)
        {
            string title = form["title"];
            string desc = form["description"];
            int voorraad = Convert.ToInt32(form["stock"]);
            decimal prijs = Decimal.Parse(form["price"]);
            int categorieId = Convert.ToInt32(form["categories"]);
            int leverancierId = Convert.ToInt32(form["supplier"]);

            Product newProduct = new Product(title, desc, voorraad, prijs, categorieId, leverancierId);
            string newProductId = newProduct.SaveOrUpdate();

            foreach (var file in images)
            {
                if (file != null)
                {
                    var fileName = Guid.NewGuid() + Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    file.SaveAs(path);
                    Afbeelding newAfbeelding = new Afbeelding("/Content/Images", fileName);
                    Afbeelding.Save(newAfbeelding, Convert.ToInt32(newProductId));
                }
            }
            return new HtmlString("test");
        }
    }
}