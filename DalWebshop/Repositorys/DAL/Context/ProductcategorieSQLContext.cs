using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class ProductcategorieSQLContext : IMaintanable<Productcategorie>
    {
        public string Create(Productcategorie obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query;

                    if (obj.Hoofdcategorie == null)
                    {
                        query = "INSERT INTO Productcategorie (naam ,omschrijving) VALUES (@naam, @omschrijving);SELECT CAST(scope_identity() AS int);";
                    }
                    else
                    {
                        query = "INSERT INTO Productcategorie (hoofdCategorieID ,naam ,omschrijving) VALUES (@hoofdCategorieID, @naam, @omschrijving);SELECT CAST(scope_identity() AS int);";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    if (obj.Hoofdcategorie != null)
                    {
                        cmd.Parameters.AddWithValue("@hoofdCategorieID", obj.Hoofdcategorie.Id);
                    }

                    cmd.Parameters.AddWithValue("@naam", obj.Naam);
                    cmd.Parameters.AddWithValue("@omschrijving", obj.Omschrijving);

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

        private Productcategorie RetrieveHoofdCategorie(string key)
        {
            Productcategorie returnCategorie = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Productcategorie where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnCategorie = new Productcategorie(reader.GetInt32(0), reader.GetString(2), reader.GetString(3));
                    }
                    con.Close();
                }

                return returnCategorie;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Productcategorie Retrieve(string key)
        {
            Productcategorie returnCategorie = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Productcategorie where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnCategorie = new Productcategorie(reader.GetInt32(0), reader.GetString(2), reader.GetString(3));

                        if (!reader.IsDBNull(1))
                        {
                            returnCategorie.Hoofdcategorie = this.RetrieveHoofdCategorie(reader.GetInt32(1).ToString());
                        }
                    }
                    con.Close();
                }

                return returnCategorie;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Productcategorie> RetrieveAll()
        {
            List<Productcategorie> returnList = new List<Productcategorie>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Productcategorie";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Productcategorie returnCategorie = new Productcategorie(reader.GetInt32(0), reader.GetString(2), reader.GetString(3));

                        if (!reader.IsDBNull(1))
                        {
                            returnCategorie.Hoofdcategorie = this.RetrieveHoofdCategorie(reader.GetInt32(1).ToString());
                        }

                        returnList.Add(returnCategorie);
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

        public void Update(Productcategorie obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query;

                    if (obj.Hoofdcategorie != null)
                    {
                        query = "UPDATE Productcategorie SET hoofdCategorieID = @hoofdCategorieID, naam = @naam, omschrijving = @omschrijving Where id = @key";
                    }
                    else
                    {
                        query = "UPDATE Productcategorie SET naam = @naam, omschrijving = @omschrijving Where id = @key";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    if (obj.Hoofdcategorie != null)
                    {
                        cmd.Parameters.AddWithValue("@hoofdCategorieID", obj.Hoofdcategorie);
                    }

                    cmd.Parameters.AddWithValue("@naam", obj.Naam);
                    cmd.Parameters.AddWithValue("@omschrijving", obj.Omschrijving);
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
                    string query = "DELETE FROM Productcategorie where id = @key";
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