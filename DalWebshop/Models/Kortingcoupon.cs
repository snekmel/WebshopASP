namespace DalWebshop.Models
{
    public class Kortingcoupon
    {
        public int Id { get; private set; }
        public string Code { get; set; }
        public int Kortingspercentage { get; set; }

        public Kortingcoupon(int id, string code, int kortingspercentage)
        {
            Id = id;
            Code = code;
            Kortingspercentage = kortingspercentage;
        }

        public Kortingcoupon(string code, int kortingspercentage)
        {
            Code = code;
            Kortingspercentage = kortingspercentage;
        }
    }
}