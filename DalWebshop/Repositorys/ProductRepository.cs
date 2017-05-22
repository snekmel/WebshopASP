using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class ProductRepository
    {
        private IMaintanable<Product> _crudInterface;

        public ProductRepository(IMaintanable<Product> i)
        {
            _crudInterface = i;
        }

        public string Create(Product obj)
        {
            return _crudInterface.Create(obj);
        }

        public Product Retrieve(string key)
        {
            return _crudInterface.Retrieve(key);
        }

        public List<Product> RetrieveAll()
        {
            return _crudInterface.RetrieveAll();
        }

        public void Update(Product obj)
        {
            _crudInterface.Update(obj);
        }

        public void Delete(string key)
        {
            _crudInterface.Delete(key);
        }
    }
}