using DalWebshop.Models;
using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WebshopASP.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Create()
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);

            Product p = pr.Retrieve("1");
            p.Prijs = p.Prijs + 4;
            pr.Create(p);
        }

        [TestMethod]
        public void Retrieve()
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);

            Product p = pr.Retrieve("1");
            Assert.IsTrue(p.Id == 1);
            Assert.IsTrue(p.Titel == "Test");
        }

        [TestMethod]
        public void RetrieveAll()
        {
            // ProductSQLContext psc = new ProductSQLContext();
            // ProductRepository pr = new ProductRepository(psc);

            List<Product> producten = Product.All();

            Assert.IsTrue(producten.Count == 2);
        }

        [TestMethod]
        public void Update()
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);

            Product p = pr.Retrieve("1");
            p.Prijs = p.Prijs + 4;
            // p.KortingId = 5;
            pr.Update(p);
        }

        [TestMethod]
        public void Delete()
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);
        }
    }
}