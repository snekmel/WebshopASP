using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class KortingRepository
    {
        private IKorting _interface;

        public KortingRepository(IKorting i)
        {
            _interface = i;
        }

        public string Create(Korting obj)
        {
            return _interface.Create(obj);
        }

        public Korting Retrieve(string key)
        {
            return _interface.Retrieve(key);
        }

        public List<Korting> RetrieveAll()
        {
            return _interface.RetrieveAll();
        }

        public void Update(Korting obj)
        {
            _interface.Update(obj);
        }

        public void Delete(string key)
        {
            _interface.Delete(key);
        }

        public List<Korting> RetrieveKortingByProductId(string id)
        {
            return _interface.RetrieveKortingByProductId(id);
        }

        public void AddKortingToProduct(string productId, string kortingId)
        {
            _interface.AddKortingToProduct(productId, kortingId);
        }

        public void RemoveKortingFromProducts(string kortingId)
        {
            _interface.RemoveKortingFromProducts(kortingId);
        }
    }
}