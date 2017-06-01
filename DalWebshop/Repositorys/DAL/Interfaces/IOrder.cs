using DalWebshop.Models;
using System.Collections.Generic;

namespace DalWebshop.Repositorys.DAL.Interfaces
{
    public interface IOrder
    {
        void Create(Order obj);

        Order Retrieve(string key);

        List<Order> RetrieveAll();

        void Update(Order obj);

        void Delete(string key);

        
    }
}