namespace DalWebshop.Models
{
    public  class Product
    {
        public int Id { get; private set; }
        public string Titel { get; private set; }
        public string Omschrijving { get; private set; }
        public int Voorraad { get; private set; }
        public decimal Prijs { get; private set; }
        public Leverancier Leverancier { get; private set; }


        //Productcategorie
        //Afbeeldingen
        //Korting
        //Recensies
        

    }
}
