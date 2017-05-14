using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopDal.Models
{
    class Productcategorie
    {
        public int Id { get; private set; }
        public Productcategorie Hoofdcategorie { get; private set; }

        public string Naam { get; private set; }
        public string Omschrijving { get; private set; }


        

    }
}
