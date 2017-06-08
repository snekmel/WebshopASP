using DalWebshop.Models;
using DalWebshop.Repositorys;
using System.Web.Mvc;

namespace WebshopASP.Controllers
{
    public class AuthController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml");
        }

        public ActionResult Logout()
        {
            Session["AuthGebruiker"] = null;
            return RedirectToAction("Index", "Home");
        }

        // Get :Register
        public ActionResult Register()
        {
            return View("~/Views/Auth/Register.cshtml");
        }

        //Pst: RegisterPost
        [HttpPost]
        public ActionResult RegisterPost(FormCollection form)
        {
            Gebruiker newUser = new Gebruiker(form["Email"], form["Password"], form["Name"], form["Lastname"], false, form["Street"], form["HouseNumber"], form["Zipcode"], form["Country"], form["City"]);

            string id = newUser.SaveOrUpdate();

            if (id == null)
            {
                ViewBag.RegisterResult = false;
                return View("~/Views/Auth/Register.cshtml");
            }
            else
            {
                return Login();
            }
        }

        //Post: /Auth/Changepassword
        [HttpPost]
        public ActionResult Changepassword(FormCollection form)
        {
            Gebruiker g = (Gebruiker)Session["AuthGebruiker"];

            if (g.Wachtwoord == form["oldPassword"] && (form["newPassword"] == form["validateNewPassword"]))
            {
                g.Wachtwoord = form["newPassword"];

                g.SaveOrUpdate();
                ViewBag.UpdateResult = "true";
            }
            else
            {
                ViewBag.UpdateResult = "false";
            }

            return View("~/Views/Account/Settings.cshtml");
        }

        //Post: /Auth/Update
        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            Gebruiker g = (Gebruiker)Session["AuthGebruiker"];

            g.Email = form["Email"];
            g.Voornaam = form["Name"];
            g.Achternaam = form["Lastname"];
            g.Straat = form["Street"];
            g.Huisnummer = form["HouseNumber"];
            g.Postcode = form["Zipcode"];
            g.Woonplaats = form["Country"];
            g.Land = form["City"];

            string id = g.SaveOrUpdate();

            if (id != null)
            {
                ViewBag.UpdateResult = "true";
            }

            return View("~/Views/Account/Settings.cshtml");
        }

        // POST: Login
        [HttpPost]
        public ActionResult LoginPost(FormCollection form)
        {
            Gebruiker user = AuthRepository.CheckAuth(form["Email"], form["Password"]);

            if (user != null)
            {
                //Maak sessie aan
                Session["AuthGebruiker"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginResult = false;
                return View("~/Views/Auth/Login.cshtml");
            }
        }
    }
}