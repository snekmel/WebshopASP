using System.Collections.Generic;
using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;

namespace DalWebshop.Repositorys
{
    public class GebruikerRepository
    {
        private IMaintanable<Gebruiker> _crudInterface;

        public GebruikerRepository(IMaintanable<Gebruiker> i)
        {
            _crudInterface = i;
        }

        public string Create(Gebruiker obj)
        {
            return _crudInterface.Create(obj);
        }

        public Gebruiker Retrieve(string key)
        {
            return _crudInterface.Retrieve(key);
        }

        public List<Gebruiker> RetrieveAll()
        {
            return _crudInterface.RetrieveAll();
        }

        public void Update(Gebruiker obj)
        {
            _crudInterface.Update(obj);
        }

        public void Delete(string key)
        {
            _crudInterface.Delete(key);
        }

    }
}
