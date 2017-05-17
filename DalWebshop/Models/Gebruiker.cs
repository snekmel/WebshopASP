namespace DalWebshop.Models
{
    public class Gebruiker
    {
        public int Id { get; private set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public bool IsAdmin { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Land { get; set; }
        public string Woonplaats { get; set; }

        public Gebruiker(int id, string email, string wachtwoord, string voornaam, string achternaam, bool isAdmin, string straat, string huisnummer, string postcode, string land, string woonplaats)
        {
            Id = id;
            Email = email;
            Wachtwoord = wachtwoord;
            Voornaam = voornaam;
            Achternaam = achternaam;
            IsAdmin = isAdmin;
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Land = land;
            Woonplaats = woonplaats;
        }

        public Gebruiker(string email, string wachtwoord, string voornaam, string achternaam, bool isAdmin, string straat, string huisnummer, string postcode, string land, string woonplaats)
        {
            Email = email;
            Wachtwoord = wachtwoord;
            Voornaam = voornaam;
            Achternaam = achternaam;
            IsAdmin = isAdmin;
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Land = land;
            Woonplaats = woonplaats;
        }
    }
}