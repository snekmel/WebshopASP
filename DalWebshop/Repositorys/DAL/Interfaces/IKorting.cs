using DalWebshop.Models;
using System.Collections.Generic;

namespace DalWebshop.Repositorys.DAL.Interfaces
{
    public interface IKorting
    {
        string Create(Korting obj);

        Korting Retrieve(string key);

        List<Korting> RetrieveAll();

        void Update(Korting obj);

        void Delete(string key);

        List<Korting> RetrieveKortingByProductId(string id);

        void AddKortingToProduct(string productId, string kortingId);

        void RemoveKortingFromProducts(string kortingId);
    }
}