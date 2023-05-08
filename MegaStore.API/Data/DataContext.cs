using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models;
using MegaStore.API.Models.Core;
using MegaStore.API.Models.Core.CountryModel;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<UserRoles>(userRole =>
            {
                userRole.HasKey(ur => new { ur.pageId, ur.userId });
            });

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

            modelBuilder.Entity<Country>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Country>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Module>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Module>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<State>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<State>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<ModulePage>()
                            .Property(b => b.creationDate)
                            .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<ModulePage>()
                .Property(b => b.updateDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Company>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Company>()
            .Property(o => o.updateDate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Plant>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Plant>()
            .Property(o => o.updateDate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

            modelBuilder.Entity<Product>()
                .Property(o => o.creationDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            modelBuilder.Entity<Product>()
            .Property(o => o.updateDate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        }

    }
}