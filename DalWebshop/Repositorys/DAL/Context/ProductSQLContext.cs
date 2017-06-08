using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class ProductSQLContext : IProduct
    {
        public string Create(Product obj)
        {
            int returnId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "INSERT INTO Product (titel,omschrijving,voorraad,prijs,leverancierId,productcategorieId) VALUES (@titel, @omschrijving, @voorraad, @prijs, @leverancierId, @productcategorieId);SELECT CAST(scope_identity() AS int);";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    cmd.Parameters.AddWithValue("@titel", obj.Titel);
                    cmd.Parameters.AddWithValue("@omschrijving", obj.Omschrijving);
                    cmd.Parameters.AddWithValue("@voorraad", obj.Voorraad);
                    cmd.Parameters.AddWithValue("@prijs", obj.Prijs);
                    cmd.Parameters.AddWithValue("@leverancierId", obj.LeverancierId);
                    cmd.Parameters.AddWithValue("@productcategorieId", obj.ProductCategorieId);

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

        public Product Retrieve(string key)
        {
            Product returnProduct = null;
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Product where id = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", key);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        returnProduct = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDecimal(4), reader.GetInt32(6), reader.GetInt32(7));
                    }
                    con.Close();
                }

                return returnProduct;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<Product> RetrieveAll()
        {
            List<Product> returnList = new List<Product>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "Select * from Product";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product p = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDecimal(4), reader.GetInt32(6), reader.GetInt32(7));

                        returnList.Add(p);
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

        public void Update(Product obj)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "UPDATE Product SET titel = @titel, omschrijving = @omschrijving, voorraad = @voorraad, prijs = @prijs, leverancierId = @leverancierId, productcategorieId = @productcategorieId WHERE id = @key";

                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();

                    cmd.Parameters.AddWithValue("@titel", obj.Titel);
                    cmd.Parameters.AddWithValue("@omschrijving", obj.Omschrijving);
                    cmd.Parameters.AddWithValue("@voorraad", obj.Voorraad);
                    cmd.Parameters.AddWithValue("@prijs", obj.Prijs);
                    cmd.Parameters.AddWithValue("@leverancierId", obj.LeverancierId);
                    cmd.Parameters.AddWithValue("@productcategorieId", obj.ProductCategorieId);
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
                    string query = "DELETE FROM Product where id = @key";
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

        public List<Product> RetrieveByOrderId(int id)
        {
            List<Product> returnList = new List<Product>();
            try
            {
                using (SqlConnection con = new SqlConnection(Env.ConString))
                {
                    string query = "SELECT Product.* FROM Order_Product INNER JOIN Product on id = Order_Product.productId WHERE Order_Product.orderId = @key";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@key", id);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Product p = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetDecimal(4), reader.GetInt32(6), reader.GetInt32(7));

                        returnList.Add(p);
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