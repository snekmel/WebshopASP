using System;

namespace DalWebshop.Models
{
    public class Korting
    {

        public int Id { get; private set; }
        public double Kortingspercentage { get;  set; }
        public string Opmerking { get;  set; }
        public DateTime EindDatum { get;  set; }


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
    }
}
