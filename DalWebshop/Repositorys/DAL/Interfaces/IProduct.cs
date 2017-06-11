using DalWebshop.Models;
using System.Collections.Generic;

namespace DalWebshop.Repositorys.DAL.Interfaces
{
    public interface IProduct
    {
        string Create(Product obj);

        Product Retrieve(string key);

        List<Product> RetrieveAll();

        void Update(Product obj);

        void Delete(string key);

        List<Product> RetrieveByOrderId(int id);

        List<ProductVerkoop> RetrieveVerkoop();
    }
}