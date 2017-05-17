using DalWebshop.Models;
using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WebshopASP.Tests
{
    [TestClass]
    public class GebruikerTests
    {
        [TestMethod]
        public void Retrieve()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            var user = gr.Retrieve("2");
            Assert.AreEqual(user.Email, "testemail");
        }

        [TestMethod]
        public void Create()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            var user = gr.Retrieve("100");
        }

        [TestMethod]
        public void RetrieveAll()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            List<Gebruiker> lijst = gr.RetrieveAll();

            Assert.IsTrue(lijst.Count > 20);
            Assert.AreEqual(lijst[1].Email, "larslemkens@gmail.com");
        }

        [TestMethod]
        public void Update()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            Gebruiker user = gr.Retrieve("2");
            // user.Voornaam = user.Voornaam + " Aangepast";
            gr.Update(user);
        }

        [TestMethod]
        public void Delete()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            gr.Delete("34");
        }
    }
}