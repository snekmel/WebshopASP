using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class AfbeeldingRepository
    {
        private IAfbeelding _interface;

        public AfbeeldingRepository(IAfbeelding i)
        {
            _interface = i;
        }

        public string Create(Afbeelding obj, int productId)
        {
            return _interface.Create(obj, productId);
        }

        public void Delete(string key)
        {
            _interface.Delete(key);
        }

        public List<Afbeelding> RetrieveAfbeeldingenByProductId(int id)
        {
            return _interface.RetrieveAfbeeldingenByProductId(id);
        }
    }
}