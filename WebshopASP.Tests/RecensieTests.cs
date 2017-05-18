using System.Collections.Generic;
using DalWebshop.Models;
using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebshopASP.Tests
{
    [TestClass]
    public class RecensieTests
    {
        [TestMethod]
        public void Create()
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);


            Recensie r = rr.Retrieve("1");
            r.GebruikerId = 2;

          //  rr.Create(r);



        }

        [TestMethod]
        public void Retrieve()
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);

            Recensie r = rr.Retrieve("1");

            Assert.IsTrue(r.Score == 7);
            Assert.IsTrue(r.ProductId == 1);
        }

        [TestMethod]
        public void RetrieveAll()
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);

            List<Recensie> lijst = rr.RetrieveAll();

          Assert.IsTrue(lijst[0].Score == 7);
            Assert.IsTrue(lijst[0].ProductId == 1);  
        }

        [TestMethod]
        public void Update()
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);
            Recensie r = rr.Retrieve("2");
            r.Opmerking = r.Opmerking + " aangepast";  
          //  rr.Update(r);

        }

        [TestMethod]
        public void Delete()
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);

            rr.Delete("2");
        }
    }
}