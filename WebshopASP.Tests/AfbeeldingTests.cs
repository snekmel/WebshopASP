using DalWebshop.Repositorys.DAL.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebshopASP.Tests
{
    [TestClass]
    public class AfbeeldingTests
    {
        [TestMethod]
        public void RelationRow()
        {
            AfbeeldingSQLContext asc = new AfbeeldingSQLContext();
            asc.MakeProductAfbeeldingRow(1, 1);
        }

        [TestMethod]
        public void NewAfbeelding()
        {
            AfbeeldingSQLContext asc = new AfbeeldingSQLContext();
        }

        [TestMethod]
        public void DeleteAfbeelding()
        {
            AfbeeldingSQLContext asc = new AfbeeldingSQLContext();
            asc.Delete("2");
        }

        [TestMethod]
        public void RetrieveByProduct()
        {
            AfbeeldingSQLContext asc = new AfbeeldingSQLContext();

            int count = asc.RetrieveAfbeeldingenByProductId(1).Count;

            Assert.IsTrue(asc.RetrieveAfbeeldingenByProductId(1).Count > 0);
        }
    }
}