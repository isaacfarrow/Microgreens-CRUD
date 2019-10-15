using System;
using System.Collections.Generic;
using System.Text;
using Microgreens.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microgreens.Data
{
    public class ProductsDbContext : DbContext
    {
        //Here we add in the tables that we are using.....
        public DbSet<Products> Products { get; set; }
        public DbSet<SowRatesL> SowRatesL { get; set; }
        public DbSet<Yields> Yields { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

        public ProductsDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }






    }
}