using DalWebshop.Models;
using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WebshopASP.Tests
{
    [TestClass]
    public class LeverancierTests
    {
        [TestMethod]
        public void Create()
        {
            LeverancierSQLContext lsc = new LeverancierSQLContext();
            LeverancierRepository lr = new LeverancierRepository(lsc);
            Leverancier l = lr.Retrieve("2");
            l.Naam = "Lars";
            //  lr.Create(l);
        }

        [TestMethod]
        public void Retrieve()
        {
            LeverancierSQLContext lsc = new LeverancierSQLContext();
            LeverancierRepository lr = new LeverancierRepository(lsc);

            Leverancier l = lr.Retrieve("2");

            Assert.IsTrue(l.Plaats == "sadf");
        }

        [TestMethod]
        public void RetrieveAll()
        {
            LeverancierSQLContext lsc = new LeverancierSQLContext();
            LeverancierRepository lr = new LeverancierRepository(lsc);
            List<Leverancier> lijst = lr.RetrieveAll();
            Assert.IsTrue(lijst.Count >= 2);
        }

        [TestMethod]
        public void Update()
        {
            LeverancierSQLContext lsc = new LeverancierSQLContext();
            LeverancierRepository lr = new LeverancierRepository(lsc);
            Leverancier l = lr.Retrieve("2");

            l.Naam = l.Naam + "AAngepast";
            
            lr.Update(l);


        }

        [TestMethod]
        public void Delete()
        {
            LeverancierSQLContext lsc = new LeverancierSQLContext();
            LeverancierRepository lr = new LeverancierRepository(lsc);

            // lr.Delete("1");
        }
    }
}