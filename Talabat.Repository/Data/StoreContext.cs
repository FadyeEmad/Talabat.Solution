﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet <Product> products { get; set; }
        public DbSet <ProductBrand> productBrands { get; set; }
        public DbSet <ProductType> productTypes { get; set; }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Departament> departaments { get; set; }
    }
}
