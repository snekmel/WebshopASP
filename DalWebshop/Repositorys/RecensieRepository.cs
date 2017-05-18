using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;

namespace DalWebshop.Repositorys
{
    public class RecensieRepository
    {
        private IMaintanable<Recensie> _interface;

        public RecensieRepository(IMaintanable<Recensie> i)
        {
            _interface = i;
        }

        public List<Recensie> RetrieveByProductId(int id)
        {
            List<Recensie> recensies = this.RetrieveAll();
            return recensies.Where(r => r.ProductId == id).ToList();
        }

        public List<Recensie> RetrieveByGebruikerId(int id)
        {
            List<Recensie> recensies = this.RetrieveAll();
            return recensies.Where(r => r.GebruikerId == id).ToList();
        }

        public string Create(Recensie obj)
        {
            return _interface.Create(obj);
        }


        public List<Recensie> RetrieveAll()
        {
            return _interface.RetrieveAll();
        }


        public Recensie Retrieve(string key)
        {
            return _interface.Retrieve(key);

        }

        public void Update(Recensie obj)
        {
            _interface.Update(obj);
        }

        public void Delete(string key)
        {
            _interface.Delete(key);
        }
    }
}
