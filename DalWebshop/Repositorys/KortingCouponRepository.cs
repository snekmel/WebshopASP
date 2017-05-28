using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class KortingCouponRepository
    {
        private IMaintanable<Kortingcoupon> _crudInterface;

        public KortingCouponRepository(IMaintanable<Kortingcoupon> i)
        {
            _crudInterface = i;
        }

        public string Create(Kortingcoupon obj)
        {
            return _crudInterface.Create(obj);
        }

        public List<Kortingcoupon> RetrieveAll()
        {
            return _crudInterface.RetrieveAll();
        }

        public Kortingcoupon Retrieve(string key)
        {
            return _crudInterface.Retrieve(key);
        }

        public void Update(Kortingcoupon obj)
        {
            _crudInterface.Update(obj);
        }

        public void Delete(string key)
        {
            _crudInterface.Delete(key);
        }

        public Kortingcoupon RetrieveByCode(string code)
        {
            Kortingcoupon result = null;

            foreach (Kortingcoupon k in this.RetrieveAll())
            {
                if (k.Code == code)
                {
                    result = k;
                }
            }

            return result;
        }
    }
}