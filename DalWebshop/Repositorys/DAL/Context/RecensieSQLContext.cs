using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class RecensieSQLContext : IMaintanable<Recensie>
    {
        public string Create(Recensie obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Recensie (opmerking ,tevreden ,score ,gebruikerId ,productId) VALUES (@opmerking, @tevreden, @score, @gebruikerId, @productId);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@opmerking", obj.Opmerking);
                    cmd.Parameters.AddWithValue("@tevreden", Convert.ToInt32(obj.Tevreden));
                    cmd.Parameters.AddWithValue("@score", obj.Score);
                    cmd.Parameters.AddWithValue("@gebruikerId", obj.GebruikerId);
                    cmd.Parameters.AddWithValue("@productId", obj.ProductId);

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

        public Recensie Retrieve(string key)
        {
            Recensie returnRecensie = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Recensie where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnRecensie = new Recensie(reader.GetInt32(0), reader.GetString(1),Convert.ToBoolean(reader.GetInt32(2)), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));
                    }
                    con.Close();
                }

                return returnRecensie;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Recensie> RetrieveAll()
        {
            List<Recensie> returnList = new List<Recensie>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Recensie";
                    SqlCommand cmd = new SqlCommand(query, con);
                 

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                       Recensie r = new Recensie(reader.GetInt32(0), reader.GetString(1), Convert.ToBoolean(reader.GetInt32(2)), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5));
                        returnList.Add(r);
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
       
        public void Update(Recensie obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = " UPDATE Recensie SET opmerking = @opmerking, tevreden = @tevreden, score = @score, gebruikerId = @gebruikerId, productId = @productId WHERE id = @key";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@opmerking", obj.Opmerking);
                    cmd.Parameters.AddWithValue("@tevreden", Convert.ToInt32(obj.Tevreden));
                    cmd.Parameters.AddWithValue("@score", obj.Score);
                    cmd.Parameters.AddWithValue("@gebruikerId", obj.GebruikerId);
                    cmd.Parameters.AddWithValue("@productId", obj.ProductId);
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
                    string query = "DELETE FROM Recensie where id = @key";
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