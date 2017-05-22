using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using System.Collections.Generic;

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

        //------------ Fat model

        public string SaveOrUpdate()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            if (Id != null)
            {
                gr.Update(this);
                return this.Id.ToString();
            }
            else
            {
                return gr.Create(this);
            }
        }

        public static List<Gebruiker> All()
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            return gr.RetrieveAll();
        }

        public static Gebruiker Find(string key)
        {
            GebruikerSQLContext gsc = new GebruikerSQLContext();
            GebruikerRepository gr = new GebruikerRepository(gsc);

            return gr.Retrieve(key);
        }
    }
}