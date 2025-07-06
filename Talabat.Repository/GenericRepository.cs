﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _dbComtext;

        public GenericRepository(StoreContext dbComtext)
        {
            _dbComtext = dbComtext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _dbComtext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbComtext.Set<T>().FindAsync(id);
        }
    }
}
