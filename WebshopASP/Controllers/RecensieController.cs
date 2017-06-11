using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DalWebshop.Models;

namespace WebshopASP.Controllers
{
    public class RecensieController : Controller
    {
        // GET: Recensie/Add
        [HttpPost]
        public void Add(FormCollection form)
        {
         
            int score = Convert.ToInt32(form["score"]);
            string opmerking = form["opmerking"];
            int userId = Convert.ToInt32(form["userId"]);
            int productId = Convert.ToInt32(form["productId"]);
            bool tevreden;
            if (form["tevreden"] == "on")
            {
                tevreden = true;

            }
            else
            {
                tevreden = false;
            }
            Recensie newRecensie = new Recensie(opmerking, tevreden, score, userId, productId);

            newRecensie.SaveOrUpdate();

            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}