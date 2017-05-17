using System;
using System.Collections.Generic;
using DalWebshop.Models;
using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebshopASP.Tests
{
    [TestClass]
    public class KortingTests
    {
        [TestMethod]
        public void Create()
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            Korting k = kr.Retrieve("1");
            k.Kortingspercentage = k.Kortingspercentage + 1;
          //   kr.Create(k);



        }

        [TestMethod]
        public void Retrieve()
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            Korting k = kr.Retrieve("1");
            Assert.IsTrue(k.Kortingspercentage == 23);

        }
        [TestMethod]
        public void RetrieveAll()
        {


            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            List<Korting> list = kr.RetrieveAll();
            Assert.IsTrue(list.Count > 1);

        }
        [TestMethod]
        public void Update()
        {

            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            Korting k = kr.Retrieve("1");

            k.Opmerking = k.Opmerking + "aangepast";

            kr.Update(k);

        }

        [TestMethod]
        public void Delete()
        {

            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

                kr.Delete("1");
        }
    }
}
