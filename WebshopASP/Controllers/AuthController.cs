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