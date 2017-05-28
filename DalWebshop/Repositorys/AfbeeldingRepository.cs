using DalWebshop.Repositorys.DAL.Interfaces;

namespace DalWebshop.Repositorys
{
    public class AfbeeldingRepository
    {
        private IAfbeelding _interface;

        public AfbeeldingRepository(IAfbeelding i)
        {
            _interface = i;
        }
    }
}