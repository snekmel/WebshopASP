using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;

namespace DalWebshop.Repositorys
{
    class AfbeeldingRepository
    {

        private IMaintanable<Afbeelding> _interface;

        public AfbeeldingRepository(IMaintanable<Afbeelding> i)
        {
            _interface = i;
        }

    }
}
