using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class OrderSQLContext : IOrder
    {
        private List<OrderRow> getOrderRowsByOrderId(int orderId)
        {
            List<OrderRow> returnList = new List<OrderRow>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query =
                        "SELECT * FROM Order_Product where orderId = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", orderId);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        OrderRow or = new OrderRow(reader.GetInt32(1), reader.GetInt32(2));
                        returnList.Add(or);
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

        private void DeleteProductRowsByOrderId(int orderId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "DELETE FROM Order_Product where orderId = @key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@key", orderId);
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

        public void Create(Order obj)
        {
            DataTable ProductRows = new DataTable();
            ProductRows.Columns.Add("productId");
            ProductRows.Columns.Add("aantal");

            foreach (OrderRow or in obj.Producten)
            {
                ProductRows.Rows.Add(or.ProductId, or.Aantal);
            }

            using (SqlConnection con = new SqlConnection(Env.ConString))
            {
                SqlCommand cmd = new SqlCommand("InsertOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductRows", ProductRows);
                cmd.Parameters.AddWithValue("@Datum", DateTime.Now);
                cmd.Parameters.AddWithValue("gebruikerId", obj.GebruikerId);
                
                if (obj.Kortingcoupon == null)
                {
                    cmd.Parameters.AddWithValue("@kortingcouponId", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@kortingcouponId", obj.Kortingcoupon.Id);
                }

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(string key)
        {
            try
            {
                DeleteProductRowsByOrderId(Convert.ToInt32(key));
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "DELETE FROM [Order] where id = @key";
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

        public Order Retrieve(string key)
        {
            Order returnorder = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "SELECT * FROM [Order] WHERE id = @id";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", key);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order o = new Order(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2));
                        if (!reader.IsDBNull(3))
                        {
                            o.Kortingcoupon = Kortingcoupon.Find(reader.GetInt32(3).ToString());
                        }
                        if (!reader.IsDBNull(4))
                        {
                            o.BetaalBedrag = reader.GetDecimal(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            o.Status = reader.GetString(5);
                        }

                        o.Producten = getOrderRowsByOrderId(o.Id);
                      
                        returnorder = o;
                    }
                    con.Close();
                }

                return returnorder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Order> RetrieveAll()
        {
            List<Order> returnList = new List<Order>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "SELECT * FROM [Order]";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Order o = new Order(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2));
                        if (!reader.IsDBNull(3))
                        {
                            o.Kortingcoupon = Kortingcoupon.Find(reader.GetInt32(3).ToString());
                        }
                        if (!reader.IsDBNull(4))
                        {
                            o.BetaalBedrag = reader.GetDecimal(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            o.Status = reader.GetString(5);
                        }

                        o.Producten = getOrderRowsByOrderId(o.Id);

                        returnList.Add(o);
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

        public void Update(Order obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "UPDATE [Order] SET status = @status WHERE id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@status", obj.Status);
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
    }
}