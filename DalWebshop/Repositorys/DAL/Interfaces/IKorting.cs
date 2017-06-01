using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalWebshop.Models;
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

    }
}
