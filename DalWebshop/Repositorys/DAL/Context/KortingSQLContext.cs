using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class KortingSQLContext : IKorting
    {
        public string Create(Korting obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Korting (kortingspercentage ,opmerking ,eindDatum) VALUES (@kortingspercentage, @opmerking, @eindDatum);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@kortingspercentage", obj.Kortingspercentage);
                    cmd.Parameters.AddWithValue("@opmerking", obj.Opmerking);
                    cmd.Parameters.AddWithValue("@eindDatum", obj.EindDatum);

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

        public Korting Retrieve(string key)
        {
            Korting returnKorting = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Korting where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnKorting = new Korting(reader.GetInt32(0), Convert.ToDouble(reader.GetDecimal(1)), reader.GetString(2), reader.GetDateTime(3));
                    }
                    con.Close();
                }

                return returnKorting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Korting> RetrieveAll()
        {
            List<Korting> returnList = new List<Korting>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Korting";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Korting k = new Korting(reader.GetInt32(0), Convert.ToDouble(reader.GetDecimal(1)), reader.GetString(2), reader.GetDateTime(3));
                        returnList.Add(k);
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

        public void Update(Korting obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = " UPDATE Korting SET kortingspercentage = @kortingspercentage, opmerking = @opmerking, eindDatum = @eindDatum WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@kortingspercentage", obj.Kortingspercentage);
                    cmd.Parameters.AddWithValue("@opmerking", obj.Opmerking);
                    cmd.Parameters.AddWithValue("@eindDatum", obj.EindDatum);
                    cmd.Parameters.AddWithValue("@key", obj.Id);

                    con.Open();
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
                    string query = "DELETE FROM Korting where id = @key";
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

        public List<Korting> RetrieveKortingByProductId(string id)
        {
            List<Korting> returnList = new List<Korting>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "SELECT k.* FROM Product_Korting INNER JOIN Korting k on k.id = kortingId where productId = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Korting k = new Korting(reader.GetInt32(0), Convert.ToDouble(reader.GetDecimal(1)), reader.GetString(2), reader.GetDateTime(3));
                        returnList.Add(k);
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

        public void AddKortingToProduct(string productId, string kortingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Product_Korting (productId,kortingId) VALUES (@productId, @kortingId)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@kortingId", kortingId);
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