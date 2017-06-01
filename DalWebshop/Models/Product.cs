﻿using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using System.Collections.Generic;

namespace DalWebshop.Models
{
    public class Product
    {
        public int Id { get; private set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public int Voorraad { get; set; }
        public decimal Prijs { get; set; }
        public int LeverancierId { get; private set; }
        public int ProductCategorieId { get; set; }

        public Product(int id, string titel, string omschrijving, int voorraad, decimal prijs, int leverancierId, int productCategorieId)
        {
            Id = id;
            Titel = titel;
            Omschrijving = omschrijving;
            Voorraad = voorraad;
            Prijs = prijs;
            LeverancierId = leverancierId;
            ProductCategorieId = productCategorieId;
        }

        public Product(string titel, string omschrijving, int voorraad, decimal prijs, int productCategorieId, int leverancierId)
        {
            Titel = titel;
            Omschrijving = omschrijving;
            Voorraad = voorraad;
            Prijs = prijs;
            ProductCategorieId = productCategorieId;
            LeverancierId = leverancierId;
        }

        public Leverancier RetrieveLeverancier()
        {
            return null;
        }

        public List<Afbeelding> RetrieveAfbeeldingen()
        {
            return null;
        }

        public List<Korting> RetrieveKorting()
        {
            return Korting.GetKortingByProductId(this.Id.ToString());
        }

        public Productcategorie RetrieveCategorie()
        {
            return null;
        }

        public List<Recensie> RetrieveRecensies()
        {
            return null;
        }

        //-----------------------------------------------------------Fat Model----------------------------------------------------
        public void SaveOrUpdate()
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);

            if (Id != 0)
            {
                pr.Update(this);
            }
            else
            {
                pr.Create(this);
            }
        }

        public static List<Product> All()
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);

            return pr.RetrieveAll();
        }

        public static Product Find(string key)
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);

            return pr.Retrieve(key);
        }
    }
}