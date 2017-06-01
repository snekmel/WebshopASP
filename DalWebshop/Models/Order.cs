using System;
using System.Collections.Generic;
using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;

namespace DalWebshop.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public int GebruikerId { get; set; }
        public Kortingcoupon Kortingcoupon { get; set; }
        public List<OrderRow> Producten { get; set; }

        public Order(int id, DateTime date, int gebruikerId)
        {
            Id = id;
            Date = date;
            GebruikerId = gebruikerId;
            Producten = new List<OrderRow>();
        }

        public Order(int gebruikerId)
        {
            GebruikerId = gebruikerId;
            Date = DateTime.Now;
            Producten = new List<OrderRow>();
        }

        public Order()
        {
            Date = DateTime.Now;
            Producten = new List<OrderRow>();
        }

        public decimal TotaalPrijs()
        {
            decimal returnAmount = 0;
            foreach (OrderRow or in Producten)
            {
                returnAmount = returnAmount + (or.ProductInformatie().Prijs * or.Aantal);
            }

            if (Kortingcoupon != null)
            {
                returnAmount = (returnAmount / 100) * (100 - Kortingcoupon.Kortingspercentage);
            }

            return returnAmount;
        }



        public void SaveOrUpdate()
        {
             OrderSQLContext osc = new OrderSQLContext();
            OrderRepository or = new OrderRepository(osc);

            if (Id != 0)
            {
             //   or.Update(this);
            }
            else
            {
                or.Create(this);
            }
        }

        public static List<Order> All()
        {
            OrderSQLContext osc = new OrderSQLContext();
            OrderRepository or = new OrderRepository(osc);

            return or.RetrieveAll();
        }

        public static Order Find(string key)
        {
            OrderSQLContext osc = new OrderSQLContext();
            OrderRepository or = new OrderRepository(osc);

            return or.Retrieve(key);
        }

        public static List<Order> FindOrderByGebruikerId(int gebruikerId)
        {
            OrderSQLContext osc = new OrderSQLContext();
            OrderRepository or = new OrderRepository(osc);

            return or.RetrieveByGebruikerId(gebruikerId);
        }
    }
}