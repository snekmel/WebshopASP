using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class AfbeeldingSQLContext : IAfbeelding
    {
        public void DeleteProductAfbeeldingRow(int afbeeldingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "DELETE FROM Product_Afbeelding where afbeeldingId = @key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@key", afbeeldingId);
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

        public void MakeProductAfbeeldingRow(int productId, int afbeeldingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Product_Afbeelding (productId, afbeeldingId) VALUES (@productId, @afbeeldingId)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@productId", productId);
                    cmd.Parameters.AddWithValue("@afbeeldingId", afbeeldingId);
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

        public string Create(Afbeelding obj, int productId)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Afbeelding (path, naam) VALUES (@path, @naam);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@path", obj.Path);
                    cmd.Parameters.AddWithValue("@naam", obj.Naam);
                    returnId = (int)cmd.ExecuteScalar();
                    MakeProductAfbeeldingRow(productId, returnId);
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

        public void Delete(string key)
        {
            try
            {
                DeleteProductAfbeeldingRow(Convert.ToInt32(key));

                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "DELETE FROM Afbeelding where id = @key";
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

        public List<Afbeelding> RetrieveAfbeeldingenByProductId(int id)
        {
            List<Afbeelding> returnList = new List<Afbeelding>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query =
                        "SELECT Afbeelding.* FROM Product_Afbeelding INNER JOIN Afbeelding ON Product_Afbeelding.afbeeldingId = Afbeelding.id where productId = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Afbeelding a = new Afbeelding(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        returnList.Add(a);
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
    }
}