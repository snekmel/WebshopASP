namespace DalWebshop.Models
{
    public class Recensie
    {
        public int Id { get; private set; }
        public int GebruikerId { get; set; }
        public int ProductId { get; set; }

        public string Opmerking { get;  set; }
        public bool Tevreden { get;  set; }
        public int Score { get;  set; }




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

     
    }
}
