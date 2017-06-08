using DalWebshop.Repositorys;
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
            return Leverancier.Find(this.LeverancierId.ToString());
        }

        public List<Afbeelding> RetrieveAfbeeldingen()
        {
            return Afbeelding.RetrieveAfbeeldingenByProductId(this.Id);
        }

        


        public Afbeelding MainImage()
        {
            if (this.RetrieveAfbeeldingen().Count != 0)
            {
                List<Afbeelding> lijst = this.RetrieveAfbeeldingen();
                return lijst[0];
            }
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
            return Recensie.FindByProductId(this.Id);
        }

        //-----------------------------------------------------------Fat Model----------------------------------------------------
        public string SaveOrUpdate()
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);

            if (Id != 0)
            {
                pr.Update(this);
                return this.Id.ToString();
            }
            else
            {
                return pr.Create(this);
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

        public static List<Product> GetNewestProducts(int aantal)
        {
            ProductSQLContext psc = new ProductSQLContext();
            ProductRepository pr = new ProductRepository(psc);
            return pr.RetrieveNewestProducts(aantal);
        }
    }
}