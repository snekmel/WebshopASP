﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using DalWebshop.Models;
using DalWebshop.Repositorys;

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
            return RedirectToAction("Index","Home");
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

         Gebruiker newUser = new Gebruiker(form["Email"],form["Password"], form["Name"],form["Lastname"],false,form["Street"],form["HouseNumeber"],form["Zipcode"],form["Country"],form["City"]);
         string id = newUser.SaveOrUpdate();

            if (id == null)
            {
                ViewBag.RegisterResult = false;
            }
            else
            {
                ViewBag.RegisterResult = true;
            }
            return View("~/Views/Auth/Register.cshtml");
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