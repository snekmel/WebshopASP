namespace DalWebshop.Models
{
   public class Gebruiker
    {

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Wachtwoord { get; private set; }
        public string Voornaam { get; private set; }
        public string Achternaam { get; private set; }
        public bool IsAdmin { get; private set; }
        public string Straat { get; private set; }
        public string Huisnummer { get; private set; }
        public string Postcode { get; private set; }
        public string Land { get; private set; }
        public string Woonplaats { get; private set; }
    }
}
