using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Orders()
        {
            return View("~/Views/Account/Orders.cshtml");
        }
    }
}