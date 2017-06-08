using DalWebshop.Repositorys;
using DalWebshop.Repositorys.DAL.Context;
using System.Collections.Generic;

namespace DalWebshop.Models
{
    public class Afbeelding
    {
        public Afbeelding(string path, string naam)
        {
            this.Path = path;
            this.Naam = naam;
        }

        public Afbeelding(int id, string path, string naam)
        {
            this.Id = id;
            this.Path = path;
            this.Naam = naam;
        }

        public int Id { get; private set; }
        public string Path { get; set; }
        public string Naam { get; set; }

        public static string Save(Afbeelding obj, int productId)
        {
            AfbeeldingSQLContext asc = new AfbeeldingSQLContext();
            AfbeeldingRepository ar = new AfbeeldingRepository(asc);
            return ar.Create(obj, productId);
        }

        public static void Delete(int afbeeldingId)
        {
            AfbeeldingSQLContext asc = new AfbeeldingSQLContext();
            AfbeeldingRepository ar = new AfbeeldingRepository(asc);
            ar.Delete(afbeeldingId.ToString());
        }

        public static List<Afbeelding> RetrieveAfbeeldingenByProductId(int id)
        {
            AfbeeldingSQLContext asc = new AfbeeldingSQLContext();
            AfbeeldingRepository ar = new AfbeeldingRepository(asc);

            return ar.RetrieveAfbeeldingenByProductId(id);
        }
    }
}