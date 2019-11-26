using Contoso.Apps.Movies.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Apps.Movies.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
      : base("SqlConnection")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemAggregate> ItemAggregates { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SimilarItem> Similarity { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ItemRating> ItemRatings { get; set; }
        public DbSet<CollectorLog> Events { get; set; }
        public DbSet<Rule> Associations { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<StoreDbContext>(null);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<ItemAggregate>().ToTable("ItemAggregate");
            modelBuilder.Entity<SimilarItem>().ToTable("Similarity");
            modelBuilder.Entity<CartItem>().ToTable("CartItem");
            modelBuilder.Entity<ItemRating>().ToTable("Ratings");
            modelBuilder.Entity<CollectorLog>().ToTable("Event");
            modelBuilder.Entity<Rule>().ToTable("associations");
            modelBuilder.Entity<SimilarItem>().ToTable("Similarity");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
        }
    }
}
