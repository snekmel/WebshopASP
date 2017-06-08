using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WebshopASP.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void All()
        {
            OrderSQLContext osc = new OrderSQLContext();
            List<Order> oList = osc.RetrieveAll();

            Assert.IsTrue(oList.Count > 0);
        }

        [TestMethod]
        public void Find()
        {
            OrderSQLContext osc = new OrderSQLContext();
            Order o = osc.Retrieve("25");
        }

        [TestMethod]
        public void Delete()
        {
            OrderSQLContext osc = new OrderSQLContext();
            osc.Delete("29");
        }
    }
}