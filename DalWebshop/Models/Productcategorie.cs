namespace DalWebshop.Models
{
    public class Productcategorie
    {
        public int Id { get; private set; }
        public Productcategorie Hoofdcategorie { get; set; }

        public string Naam { get; set; }
        public string Omschrijving { get; set; }

        public Productcategorie(int id, string naam, string omschrijving)
        {
            Id = id;

            Naam = naam;
            Omschrijving = omschrijving;
        }

        public Productcategorie(Productcategorie hoofdcategorie, string naam, string omschrijving)
        {
            Hoofdcategorie = hoofdcategorie;
            Naam = naam;
            Omschrijving = omschrijving;
        }
    }
}