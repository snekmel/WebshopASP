using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Collections.Generic;

namespace DalWebshop.Repositorys
{
    public class OrderRepository
    {

        private IOrder _interface;

        public OrderRepository(IOrder i)
        {
            _interface = i;
        }

        public void Create(Order obj)
        {
            _interface.Create(obj);
      
        }

        public void Delete(string key)
        {
            _interface.Delete(key);
        }

        public Order Retrieve(string key)
        {
            return _interface.Retrieve(key);
        }

        public List<Order> RetrieveAll()
        {
            return _interface.RetrieveAll();
        }

        public List<Order> RetrieveByGebruikerId(int gebruikerId)
        {

            List<Order> returnList = new List<Order>();
            foreach (Order o in this.RetrieveAll())
            {
                if (o.GebruikerId == gebruikerId)
                {
                    returnList.Add(o);
                }
            }

            return returnList;
        }

    }
}