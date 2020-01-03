using Contoso.Apps.Movies.Data.Models;
using Microsoft.EntityFrameworkCore;
using DataGenerator;
using System;

namespace Contoso.Apps.Movies.Data
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if(string.IsNullOrWhiteSpace(AppSettings.Configuration["SQL_CONNECTION_STRING"]))
                {
                    throw new Exception("SQL connection string is missing. Please add and try again.");
                }

                optionsBuilder.UseSqlServer(AppSettings.Configuration["SQL_CONNECTION_STRING"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().ToTable("Item");
            //modelBuilder.Entity<Order>().ToTable("Orders");
            //modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
        }
    }
}
