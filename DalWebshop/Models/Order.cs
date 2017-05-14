using System;
using System.Collections.Generic;

namespace DalWebshop.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public Gebruiker Klant { get; private set; }
        public Kortingcoupon Kortingcoupon { get; private set; }
        public List<Product> Producten { get; private set; }

    }
}
