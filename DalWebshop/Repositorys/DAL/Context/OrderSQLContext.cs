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
              
              //Kortingcouponid moet ook leeg kunnen zijn

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
            throw new NotImplementedException();
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
    }
}