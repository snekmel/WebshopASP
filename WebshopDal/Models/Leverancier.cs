using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopDal.Models
{
    class Leverancier
    {

        public int Id { get; private set; }
        public string Naam { get; private set; }
        public string Straat { get; private set; }
        public string Huisnummer { get; private set; }
        public string Postcode { get; private set; }
        public string Land { get; private set; }
        public string Plaats { get; private set; }
        public string Telefoonnummer { get; private set; }
        public string Email { get; private set; }
    }
}
