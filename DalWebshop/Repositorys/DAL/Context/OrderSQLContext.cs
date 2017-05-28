using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class OrderSQLContext : IOrder
    {
        private List<OrderRow> RetrieveOrderRow()
        {
            List<OrderRow> returnList = new List<OrderRow>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "SELECT *  Order_Product";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderRow or = new OrderRow(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
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

        private void SaveOrderRow(OrderRow row)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Order_Product (orderId ,productId ,aantal) VALUES (@orderId ,@productId ,@aantal)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderId", row.OrderId);
                    cmd.Parameters.AddWithValue("@productId", row.ProductId);
                    cmd.Parameters.AddWithValue("@aantal", row.Aantal);

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

        public string Create(Order obj)
        {
            int orderId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO [Order] (datum ,gebruikerId ,kortingcouponId) VALUES (datum, gebruikerId,kortingcouponId);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    orderId = (int)cmd.ExecuteScalar();
                    foreach (OrderRow or in obj.Producten)
                    {
                        or.OrderId = orderId;
                        this.SaveOrderRow(or);
                    }

                    con.Close();
                }

                return orderId.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Order Retrieve(string key)
        {
            throw new NotImplementedException();
        }

        public List<Order> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Order obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }
    }
}