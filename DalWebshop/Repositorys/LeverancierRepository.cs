using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class LeverancierRepository
    {
        private IMaintanable<Leverancier> _crudInterface;

        public LeverancierRepository(IMaintanable<Leverancier> i)
        {
            _crudInterface = i;
        }

        public string Create(Leverancier obj)
        {
            return _crudInterface.Create(obj);
        }

        public Leverancier Retrieve(string key)
        {
            return _crudInterface.Retrieve(key);
        }

        public List<Leverancier> RetrieveAll()
        {
            return _crudInterface.RetrieveAll();
        }

        public void Update(Leverancier obj)
        {
            _crudInterface.Update(obj);
        }

        public void Delete(string key)
        {
            _crudInterface.Delete(key);
        }
    }
}