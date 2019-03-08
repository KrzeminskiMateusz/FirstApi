﻿using FirstApi.Core.Domain;
using FirstApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private ISet<Driver> _drivers = new HashSet<Driver>();

        public void Add(Driver driver)
        {
            _drivers.Add(driver);
        }

        public Driver Get(Guid userId) => _drivers.Single(x => x.UserId == userId);

        public IEnumerable<Driver> GetAll() => _drivers;
 

        public void Update(Driver driver)
        {
        }
    }
}