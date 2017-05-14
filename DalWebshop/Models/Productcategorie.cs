namespace DalWebshop.Models
{
    public class Productcategorie
    {
        public int Id { get; private set; }
        public Productcategorie Hoofdcategorie { get; private set; }

        public string Naam { get; private set; }
        public string Omschrijving { get; private set; }


        

    }
}
