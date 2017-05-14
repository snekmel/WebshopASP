using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;

namespace DalWebshop.Repositorys
{
    class GebruikerRepository
    {
        private IMaintanable<Gebruiker> _interface;

        public GebruikerRepository(IMaintanable<Gebruiker> i)
        {
            _interface = i;
        }
    }
}
