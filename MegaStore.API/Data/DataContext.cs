using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;
using MegaStore.API.Models.Customer;
using MegaStore.API.Models.Order;
using MegaStore.API.Models.Product.Inventory;
using MegaStore.API.Models.Product.Product;
using MegaStore.API.Models.Settings.Company;
using MegaStore.API.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace MegaStore.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<ModulePage> ModulePages { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Plant> Plants { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<ProductFile> ProductFiles { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerVerificationCode> CustomerVerificationCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
            modelBuilder.Entity<UserRoles>(userRole =>
            {
                userRole.HasKey(ur => new { ur.pageId, ur.userId });
            });


            modelBuilder.Entity<User>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<UserRoles>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<UserRoles>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<UserRoles>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                .HasMany(e => e.pages)
                .WithMany(e => e.users)
                .UsingEntity<UserRoles>();


            modelBuilder.Entity<Photo>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Photo>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Photo>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Country>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Country>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Country>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Module>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Module>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Module>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<State>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<State>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<State>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<ModulePage>()
                            .Property(b => b.creationDate)
                            .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<ModulePage>()
                .Property(b => b.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<ModulePage>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Company>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Company>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Company>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Plant>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Plant>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Plant>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Category>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Category>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Category>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Category>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Product>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Product>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<Color>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Color>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Color>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            modelBuilder.Entity<ProductFile>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<ProductFile>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<ProductFile>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            // Product Line
            modelBuilder.Entity<ProductLine>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<ProductLine>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<ProductLine>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            // Order
            modelBuilder.Entity<Order>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Order>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Order>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            // OrderLine
            modelBuilder.Entity<OrderLine>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<OrderLine>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<OrderLine>()
                .Property(o => o.status)
                .HasDefaultValue(true);

            // Customer
            modelBuilder.Entity<Customer>()
               .Property(o => o.creationDate)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Customer>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Customer>()
                .Property(o => o.status)
                .HasDefaultValue(false);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.email).IsUnique();
            });

            // Customer Verification Codes
            modelBuilder.Entity<CustomerVerificationCode>()
               .Property(o => o.creationDate)
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<CustomerVerificationCode>()
                .Property(o => o.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<CustomerVerificationCode>()
                .Property(o => o.status)
                .HasDefaultValue(true);
        }

    }
}