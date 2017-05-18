using System.Collections.Generic;
using DalWebshop.Models;
using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebshopASP.Tests
{
    [TestClass]
    public class ProductCategorieTests
    {
        [TestMethod]
        public void Create()
        {
            ProductcategorieSQLContext psc = new ProductcategorieSQLContext();
            ProductCategorieRepository pr = new ProductCategorieRepository(psc);

            Productcategorie p = pr.Retrieve("1");
          //  p.Hoofdcategorie = pr.Retrieve("1");
            pr.Create(p);

        }

        [TestMethod]
        public void Retrieve()
        {

            ProductcategorieSQLContext psc = new ProductcategorieSQLContext();
            ProductCategorieRepository pr = new ProductCategorieRepository(psc);

            Productcategorie pc = pr.Retrieve("2");

            Assert.IsTrue(pc.Id == 2);
            Assert.IsTrue(pc.Hoofdcategorie.Id == 1);



             pc = pr.Retrieve("1");

            Assert.IsTrue(pc.Id == 1);
            Assert.IsTrue(pc.Hoofdcategorie == null);


        }

        [TestMethod]
        public void RetrieveAll()
        {
            ProductcategorieSQLContext psc = new ProductcategorieSQLContext();
            ProductCategorieRepository pr = new ProductCategorieRepository(psc);

            List<Productcategorie> lijst = pr.RetrieveAll();


            Assert.IsTrue(lijst[0].Hoofdcategorie == null);
            Assert.IsTrue(lijst[1].Hoofdcategorie.Id == 1);

        }

        [TestMethod]
        public void Update()
        {
            ProductcategorieSQLContext psc = new ProductcategorieSQLContext();
            ProductCategorieRepository pr = new ProductCategorieRepository(psc);

            Productcategorie p = pr.Retrieve("1");
            p.Omschrijving = "testaangepast";

            pr.Update(p);
        }

        [TestMethod]
        public void Delete()
        {
            ProductcategorieSQLContext psc = new ProductcategorieSQLContext();
            ProductCategorieRepository pr = new ProductCategorieRepository(psc);
            pr.Delete("4");
        }
    }
}