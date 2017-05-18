using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class KortingcouponSQLContext : IMaintanable<Kortingcoupon>
    {
        public string Create(Kortingcoupon obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Kortingcoupon (code,kortingspercentage)VALUES (@code, @kortingspercentage);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@kortingspercentage", obj.Kortingspercentage);
                    cmd.Parameters.AddWithValue("@code", obj.Code);

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

        public Kortingcoupon Retrieve(string key)
        {
            Kortingcoupon returnKortingcoupon = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Kortingcoupon where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnKortingcoupon = new Kortingcoupon(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                    }
                    con.Close();
                }

                return returnKortingcoupon;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Kortingcoupon> RetrieveAll()
        {
            List<Kortingcoupon> returnList = new List<Kortingcoupon>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Kortingcoupon";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Kortingcoupon k = new Kortingcoupon(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
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

        public void Update(Kortingcoupon obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "UPDATE Kortingcoupon SET code = @code, kortingspercentage = @kortingspercentage WHERE id = @key";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@code", obj.Code);
                    cmd.Parameters.AddWithValue("@kortingspercentage", obj.Kortingspercentage);
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
                    string query = "DELETE FROM Kortingcoupon where id = @key";
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