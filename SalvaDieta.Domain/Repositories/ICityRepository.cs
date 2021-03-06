﻿using SalvaDieta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Domain.Repositories
{
    public interface ICityRepository
    {
        List<City> Get();
        List<City> Get(int skip, int take);
        City Get(int id);
        void Create(City city);
        void Update(City city);
        void Delete(City city);
    }
}
