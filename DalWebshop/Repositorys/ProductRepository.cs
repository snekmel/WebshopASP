using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class ProductRepository
    {
        private IProduct _interface;

        public ProductRepository(IProduct i)
        {
            _interface = i;
        }

        public string Create(Product obj)
        {
            return _interface.Create(obj);
        }

        public Product Retrieve(string key)
        {
            return _interface.Retrieve(key);
        }

        public List<Product> RetrieveAll()
        {
            return _interface.RetrieveAll();
        }

        public void Update(Product obj)
        {
            _interface.Update(obj);
        }

        public void Delete(string key)
        {
            _interface.Delete(key);
        }
    }
}