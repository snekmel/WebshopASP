using DalWebshop.Models;
using System.Collections.Generic;

namespace DalWebshop.Repositorys.DAL.Interfaces
{
    public interface IAfbeelding
    {
        string Create(Afbeelding obj);

        Afbeelding Retrieve(string key);

        List<Afbeelding> RetrieveAll();

        void Update(Afbeelding obj);

        void Delete(string key);

        List<Afbeelding> GetAfbeeldingByOrderId();
    }
}