﻿using System;
using System.Collections.Generic;
using DalWebshop.Models;
using DalWebshop.Repositorys.DAL.Interfaces;
using System.Data.SqlClient;

namespace DalWebshop.Repositorys.DAL.Context
{
    public class AfbeeldingSQLContext : IMaintanable<Afbeelding>
    {
        public string Create(Afbeelding obj)
        {
            throw new NotImplementedException();
        }

        public Afbeelding Retrieve(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(Afbeelding obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public List<Afbeelding> RetrieveAll()
        {
            throw new NotImplementedException();
        }
    }
}
