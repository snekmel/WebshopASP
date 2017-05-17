namespace DalWebshop.Models
{
    public class Leverancier
    {

        public int Id { get; private set; }
        public string Naam { get;  set; }
        public string Straat { get;  set; }
        public string Huisnummer { get;  set; }
        public string Postcode { get;  set; }
        public string Land { get;  set; }
        public string Plaats { get;  set; }
        public string Telefoonnummer { get;  set; }
        public string Email { get;  set; }

        public Leverancier(int id, string naam, string straat, string huisnummer, string postcode, string land, string plaats, string telefoonnummer, string email)
        {
            Id = id;
            Naam = naam;
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Land = land;
            Plaats = plaats;
            Telefoonnummer = telefoonnummer;
            Email = email;
        }

        public Leverancier(string naam, string straat, string huisnummer, string postcode, string land, string plaats, string telefoonnummer, string email)
        {   

            Naam = naam;
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Land = land;
            Plaats = plaats;
            Telefoonnummer = telefoonnummer;
            Email = email;
        }
    }
}
