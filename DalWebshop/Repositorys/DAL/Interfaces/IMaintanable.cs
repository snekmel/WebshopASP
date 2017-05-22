using System.Collections.Generic;

namespace DalWebshop.Repositorys.DAL.Interfaces
{
    public interface IMaintanable<T>
    {
        string Create(T obj);

        T Retrieve(string key);

        List<T> RetrieveAll();

        void Update(T obj);

        void Delete(string key);
    }
}