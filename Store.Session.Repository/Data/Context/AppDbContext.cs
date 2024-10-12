﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Session.Core.Entities;

namespace Store.Session.Repository.Data.Context
{
    public class AppDbContext:DbContext
    {



        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
    }
}
