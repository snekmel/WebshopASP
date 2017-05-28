using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using System.Collections.Generic;

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
    }
}