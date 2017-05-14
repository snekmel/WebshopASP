using System;

namespace DalWebshop.Models
{
    public class Korting
    {

        public int Id { get; private set; }
        public double Kortingspercentage { get; private set; }
        public string Opmerking { get; private set; }
        public DateTime EindDatum { get; private set; }

    }
}
