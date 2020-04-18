using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaRestaurant.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        // Add Models Here
        // ex: public DbSet<Book> Books { get; set; }
        public DbSet<FoodOption> FoodOptions { get; set; }
        public DbSet<FoodOptionSet> FoodOptionSets { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodOption>().ToTable("FoodOptions");
            modelBuilder.Entity<FoodOptionSet>().ToTable("FoodOptionSets");
            modelBuilder.Entity<MenuItem>().ToTable("MenuItems");
            modelBuilder.Entity<MenuCategory>().ToTable("MenuCategories");
        }

    }
}
