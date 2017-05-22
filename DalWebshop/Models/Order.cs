using System;
using System.Collections.Generic;

namespace DalWebshop.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public int GebruikerId { get; private set; }

        public Kortingcoupon Kortingcoupon { get; set; }
        public List<Product> Producten { get; set; }

        public Order(int id, DateTime date, int gebruikerId)
        {
            Id = id;
            Date = date;
            GebruikerId = gebruikerId;
            Producten = new List<Product>();
        }

        public Order(int gebruikerId)
        {
            GebruikerId = gebruikerId;
            Date = DateTime.Now;
            Producten = new List<Product>();
        }
    }
}