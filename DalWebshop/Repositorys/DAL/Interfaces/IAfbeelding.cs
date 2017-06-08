using DalWebshop.Models;
using System.Collections.Generic;

namespace DalWebshop.Repositorys.DAL.Interfaces
{
    public interface IAfbeelding
    {
        string Create(Afbeelding obj, int productId);

        void Delete(string key);

        List<Afbeelding> RetrieveAfbeeldingenByProductId(int id);
    }
}