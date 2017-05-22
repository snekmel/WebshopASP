using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class ProductCategorieRepository
    {
        private IMaintanable<Productcategorie> _crudInterface;

        public ProductCategorieRepository(IMaintanable<Productcategorie> i)
        {
            _crudInterface = i;
        }

        public string Create(Productcategorie obj)
        {
            return _crudInterface.Create(obj);
        }

        public Productcategorie Retrieve(string key)
        {
            return _crudInterface.Retrieve(key);
        }

        public List<Productcategorie> RetrieveAll()
        {
            return _crudInterface.RetrieveAll();
        }

        public void Update(Productcategorie obj)
        {
            _crudInterface.Update(obj);
        }

        public void Delete(string key)
        {
            _crudInterface.Delete(key);
        }
    }
}