using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    internal class OrderSQLContext : IMaintanable<Order>
    {
        public string Create(Order obj)
        {
            throw new NotImplementedException();
        }

        public Order Retrieve(string key)
        {
            Order returnOrder = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Product where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    string query2 = "Select * from Order_Product where orderId = @orderId";
                    SqlCommand cmd2 = new SqlCommand(query2, con);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnOrder = new Order(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2));
                        if (!reader.IsDBNull(4))
                        {
                            KortingcouponSQLContext ksc = new KortingcouponSQLContext();
                            KortingCouponRepository kcr = new KortingCouponRepository(ksc);

                            returnOrder.Kortingcoupon = kcr.Retrieve("4");
                        }

                        cmd.Parameters.AddWithValue("@orderId", returnOrder.Id);

                        var reader2 = cmd.ExecuteReader();
                        while (reader2.Read())
                        {

                            if (!reader.IsDBNull(1))
                            {

                                ProductSQLContext psc = new ProductSQLContext();
                                ProductRepository pr = new ProductRepository(psc);

                                returnOrder.Producten.Add(pr.Retrieve(reader.GetInt32(1).ToString()));

                            }


                        }
                    }



                

                    con.Close();
                }

                return returnOrder;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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