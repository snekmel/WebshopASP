using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace DalWebshop.Models
{
    public class Recensie
    {
        public int Id { get; private set; }
        public int GebruikerId { get; set; }
        public int ProductId { get; set; }

        public string Opmerking { get; set; }
        public bool Tevreden { get; set; }
        public int Score { get; set; }

        public Recensie(int id, string opmerking, bool tevreden, int score, int gebruikerId, int productId)
        {
            Id = id;
            Opmerking = opmerking;
            Tevreden = tevreden;
            Score = score;
            GebruikerId = gebruikerId;
            ProductId = productId;
        }

        public Recensie(string opmerking, bool tevreden, int score, int gebruikerId, int productId)
        {
            Opmerking = opmerking;
            Tevreden = tevreden;
            Score = score;
            GebruikerId = gebruikerId;
            ProductId = productId;
        }

        public void SaveOrUpdate()
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);

            if (Id != 0)
            {
                rr.Update(this);
            }
            else
            {
                rr.Create(this);
            }
        }

        public static List<Recensie> All()
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);

            return rr.RetrieveAll();
        }

        public static Recensie Find(string key)
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);

            return rr.Retrieve(key);
        }

        public static int AverageScoreByProductId(int productId)
        {
            List<Recensie> list = FindByProductId(productId);
            int total = 0;
                
            foreach (Recensie r in list)
            {
              total =  total + r.Score;
            }

            if (total == 0)
            {
                return total;
            }
            else
            {
                return (total / list.Count);
            }
          
        }


        public static List<Recensie> FindByProductId(int id)
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);

            return rr.RetrieveByProductId(id);
        }

        public static List<Recensie> FindByGebruikerId(int id)
        {
            RecensieSQLContext rcs = new RecensieSQLContext();
            RecensieRepository rr = new RecensieRepository(rcs);

            return rr.RetrieveByGebruikerId(id);
        }

        public static bool CanReview(int productId, int userId)
        {
            bool returnValue = false;

            List<Order> userOrders = Order.FindOrderByGebruikerId(userId);
            List<Recensie> userRecensies = Recensie.FindByGebruikerId(userId);

            foreach (Order order in userOrders)
            {
                foreach (OrderRow or in order.Producten)
                {
                    if (or.ProductId == productId)
                    {
                        // klant heeft product ooit besteld
                        returnValue = true;

                        foreach (Recensie recensie in userRecensies)
                        {
                            //Check of klant al een review heeft geschreven voor dit product.
                            if (recensie.ProductId == productId)
                            {
                                returnValue = false;
                            }
                        }
                    }
                }
            }

            return returnValue;
        }
    }
}