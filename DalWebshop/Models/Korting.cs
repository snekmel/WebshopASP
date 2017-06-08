using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using System;
using System.Collections.Generic;

namespace DalWebshop.Models
{
    public class Korting
    {
        public int Id { get; private set; }
        public double Kortingspercentage { get; set; }
        public string Opmerking { get; set; }
        public DateTime EindDatum { get; set; }

        public Korting(int id, double kortingspercentage, string opmerking, DateTime eindDatum)
        {
            Id = id;
            Kortingspercentage = kortingspercentage;
            Opmerking = opmerking;
            EindDatum = eindDatum;
        }

        public Korting(double kortingspercentage, string opmerking, DateTime eindDatum)
        {
            Kortingspercentage = kortingspercentage;
            Opmerking = opmerking;
            EindDatum = eindDatum;
        }

        public string SaveOrUpdate()
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            if (Id != 0)
            {
                kr.Update(this);
                return Id.ToString();
            }
            else
            {
                return kr.Create(this);
            }
        }

        public void Delete()
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            kr.Delete(Id.ToString());
        }

        public static List<Korting> All()
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            return kr.RetrieveAll();
        }

        public static Korting Find(string key)
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            return kr.Retrieve(key);
        }

        public static List<Korting> GetKortingByProductId(string productId)
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            return kr.RetrieveKortingByProductId(productId);
        }

        public static void AddKortingToProduct(string kortingId, string productid)
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            kr.AddKortingToProduct(productid, kortingId);
        }

        public static void RemoveKortingFromProducts(string kortingId)
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            kr.RemoveKortingFromProducts(kortingId);
        }

        public static List<Korting> RetrieveByProductId(string id)
        {
            KortingSQLContext ksc = new KortingSQLContext();
            KortingRepository kr = new KortingRepository(ksc);

            return kr.RetrieveKortingByProductId(id);
        }
    }
}