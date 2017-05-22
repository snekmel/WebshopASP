using DalWebshop.Models;
using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace WebshopASP.Tests
{
    [TestClass]
    public class KortingcouponTests
    {
        [TestMethod]
        public void Create()
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);
            Kortingcoupon k = kcr.Retrieve("1");
        }

        [TestMethod]
        public void Retrieve()
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);

            Kortingcoupon k = kcr.Retrieve("1");

            Assert.AreEqual("Zomer10", k.Code);
        }

        [TestMethod]
        public void RetrieveAll()
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);

            List<Kortingcoupon> lijst = kcr.RetrieveAll();

            Assert.AreEqual("Zomer10", lijst[0].Code);
        }

        [TestMethod]
        public void Update()
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);

            Kortingcoupon k = kcr.Retrieve("1");
            k.Code = "Zomer20";
            k.Kortingspercentage = 20;

            kcr.Update(k);
        }

        [TestMethod]
        public void Delete()
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);

            kcr.Delete("1");
        }
    }
}