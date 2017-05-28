using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using System.Collections.Generic;

namespace DalWebshop.Models
{
    public class Productcategorie
    {
        public int Id { get; private set; }
        public Productcategorie Hoofdcategorie { get; set; }

        public string Naam { get; set; }
        public string Omschrijving { get; set; }

        public Productcategorie(int id, string naam, string omschrijving)
        {
            Id = id;

            Naam = naam;
            Omschrijving = omschrijving;
        }

        public Productcategorie(Productcategorie hoofdcategorie, string naam, string omschrijving)
        {
            Hoofdcategorie = hoofdcategorie;
            Naam = naam;
            Omschrijving = omschrijving;
        }

        public void SaveOrUpdate()
        {
            ProductcategorieSQLContext psc = new ProductcategorieSQLContext();
            ProductCategorieRepository pr = new ProductCategorieRepository(psc);

            if (Id != 0)
            {
                pr.Update(this);
            }
            else
            {
                pr.Create(this);
            }
        }

        public static List<Productcategorie> All()
        {
            ProductcategorieSQLContext psc = new ProductcategorieSQLContext();
            ProductCategorieRepository pr = new ProductCategorieRepository(psc);

            return pr.RetrieveAll();
        }

        public static Productcategorie Find(string key)
        {
            ProductcategorieSQLContext psc = new ProductcategorieSQLContext();
            ProductCategorieRepository pr = new ProductCategorieRepository(psc);

            return pr.Retrieve(key);
        }
    }
}