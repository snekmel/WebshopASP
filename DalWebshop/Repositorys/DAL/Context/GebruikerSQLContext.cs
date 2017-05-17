using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class GebruikerSQLContext : IMaintanable<Gebruiker>
    {
        public string Create(Gebruiker obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Gebruiker(email,wachtwoord,voornaam,achternaam,isAdmin,straat,huisnummer,postcode,land,woonplaats)VALUES(@email,@wachtwoord,@voornaam,@achternaam,@isAdmin,@straat,@huisnummer,@postcode,@land,@woonplaats);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@wachtwoord", obj.Wachtwoord);
                    cmd.Parameters.AddWithValue("@voornaam", obj.Voornaam);
                    cmd.Parameters.AddWithValue("@achternaam", obj.Achternaam);
                    cmd.Parameters.AddWithValue("@isAdmin", Convert.ToInt32(obj.IsAdmin));
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
            Gebruiker returnUser = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Gebruiker where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnUser = new Gebruiker(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), Convert.ToBoolean(reader.GetInt32(5)), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10));
                    }
                    con.Close();
                }

                return returnUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Gebruiker> RetrieveAll()
        {
            List<Gebruiker> returnList;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    returnList = new List<Gebruiker>();

                    string query = "Select * from Gebruiker";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Gebruiker user = new Gebruiker(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), Convert.ToBoolean(reader.GetInt32(5)), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10));
                        returnList.Add(user);
                    }
                    con.Close();
                }

                return returnList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Gebruiker obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "UPDATE Gebruiker SET email = @email,wachtwoord = @wachtwoord,voornaam = @voornaam,achternaam = @achternaam,isAdmin = @isAdmin," +
                                   "straat = @straat,huisnummer = @huisnummer,postcode = @postcode,land = @land, woonplaats = @woonplaats, WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);

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

                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(string key)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "DELETE FROM Gebruiker where Gebruiker.id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@key", key);
                    con.Open();
                    cmd.ExecuteReader();
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}