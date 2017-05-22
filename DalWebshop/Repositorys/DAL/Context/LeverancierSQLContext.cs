using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class LeverancierSQLContext : IMaintanable<Leverancier>
    {
        public string Create(Leverancier obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Leverancier (naam,straat,huisnummer,postcode,land,plaats,telefoonnummer,email) VALUES (@naam,@straat,@huisnummer,@postcode,@land,@plaats,@telefoonnummer,@email);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@naam", obj.Naam);
                    cmd.Parameters.AddWithValue("@straat", obj.Straat);
                    cmd.Parameters.AddWithValue("@huisnummer", obj.Huisnummer);
                    cmd.Parameters.AddWithValue("@postcode", obj.Postcode);
                    cmd.Parameters.AddWithValue("@land", obj.Land);
                    cmd.Parameters.AddWithValue("@plaats", obj.Plaats);
                    cmd.Parameters.AddWithValue("@telefoonnummer", obj.Telefoonnummer);
                    cmd.Parameters.AddWithValue("@email", obj.Email);

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

        public Leverancier Retrieve(string key)
        {
            Leverancier returnLeverancier = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Leverancier where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnLeverancier = new Leverancier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                    }
                    con.Close();
                }

                return returnLeverancier;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Leverancier> RetrieveAll()
        {
            List<Leverancier> returnList = new List<Leverancier>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Leverancier";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Leverancier l = new Leverancier(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                        returnList.Add(l);
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

        public void Update(Leverancier obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "UPDATE Leverancier SET naam = @naam, straat = @straat, huisnummer = @huisnummer, postcode = @postcode, land = @land, plaats = @plaats, telefoonnummer = @telefoonnummer, email = @email WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@naam", obj.Naam);
                    cmd.Parameters.AddWithValue("@straat", obj.Straat);
                    cmd.Parameters.AddWithValue("@huisnummer", obj.Huisnummer);
                    cmd.Parameters.AddWithValue("@postcode", obj.Postcode);
                    cmd.Parameters.AddWithValue("@land", obj.Land);
                    cmd.Parameters.AddWithValue("@plaats", obj.Plaats);
                    cmd.Parameters.AddWithValue("@telefoonnummer", obj.Telefoonnummer);
                    cmd.Parameters.AddWithValue("@email", obj.Email);
                    cmd.Parameters.AddWithValue("@key", obj.Id);

                    cmd.ExecuteNonQuery();
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
                    string query = "DELETE FROM Leverancier where id = @key";
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