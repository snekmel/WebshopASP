using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;

namespace DalWebshop.Repositorys.DAL.Context
{
    class GebruikerSQLContext: IMaintanable<Gebruiker>
    {

      

        public string Create(Gebruiker obj)
        {
            int returnId;
            try
            {

                using (SqlConnection con = new SqlConnection(Env.ConString))
                {

                    string query = "INSERT INTO Gebruiker([email],[wachtwoord],[voornaam],[achternaam],[isAdmin],[straat],[huisnummer],[postcode],[land],[woonplaats])VALUES" +
                              "([@email],[@wachtwoord],[@voornaam],[@achternaam],[@isAdmin],[@straat],[@huisnummer],[@postcode],[@land],[@woonplaats])";
                    SqlCommand cmd = new SqlCommand(query, _con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@wachtwoord", obj.Wachtwoord);
                    cmd.Parameters.AddWithValue("@voornaam", obj.Voornaam);
                    cmd.Parameters.AddWithValue("@achternaam", obj.Achternaam);
                    cmd.Parameters.AddWithValue("@isAdmin", obj.IsAdmin);
                    cmd.Parameters.AddWithValue("@straat", obj.Straat);
                    cmd.Parameters.AddWithValue("@huisnummer", obj.Huisnummer);
                    cmd.Parameters.AddWithValue("@postcode", obj.Postcode);
                    cmd.Parameters.AddWithValue("@land", obj.Land);
                    cmd.Parameters.AddWithValue("@woonplaats", obj.Woonplaats);

                    returnId = (int)cmd.ExecuteScalar();

                    con.Close();

                }


                return returnId.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Gebruiker Retrieve(string key)
        {
            throw new NotImplementedException();
        }

        public List<Gebruiker> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Gebruiker obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }
    }
}
