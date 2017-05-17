using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class KortingRepository
    {
        private IMaintanable<Korting> _crudInterface;

        public KortingRepository(IMaintanable<Korting> i)
        {
            _crudInterface = i;
        }

        public string Create(Korting obj)
        {
            return _crudInterface.Create(obj);
        }

        public Korting Retrieve(string key)
        {
            return _crudInterface.Retrieve(key);
        }

        public List<Korting> RetrieveAll()
        {
            return _crudInterface.RetrieveAll();
        }

        public void Update(Korting obj)
        {
            _crudInterface.Update(obj);
        }

        public void Delete(string key)
        {
            _crudInterface.Delete(key);
        }
    }
}