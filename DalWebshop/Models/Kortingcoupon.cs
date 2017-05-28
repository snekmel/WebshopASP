using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using System.Collections.Generic;

namespace DalWebshop.Models
{
    public class Kortingcoupon
    {
        public int Id { get; private set; }
        public string Code { get; set; }
        public int Kortingspercentage { get; set; }

        public Kortingcoupon(int id, string code, int kortingspercentage)
        {
            Id = id;
            Code = code;
            Kortingspercentage = kortingspercentage;
        }

        public Kortingcoupon(string code, int kortingspercentage)
        {
            Code = code;
            Kortingspercentage = kortingspercentage;
        }

        public void SaveOrUpdate()
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);
            if (Id != 0)
            {
                kcr.Update(this);
            }
            else
            {
                kcr.Create(this);
            }
        }

        public static List<Kortingcoupon> All()
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);

            return kcr.RetrieveAll();
        }

        public static Kortingcoupon Find(string key)
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);

            return kcr.Retrieve(key);
        }

        public static Kortingcoupon FindByCode(string code)
        {
            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
            KortingCouponRepository kcr = new KortingCouponRepository(ksc);

            return kcr.RetrieveByCode(code);
        }
    }
}