using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaStore.API.Models;
using MegaStore.API.Models.Core;
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .Property(b => b.creationDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<User>()
                    .Property(b => b.updateDate)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");


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
        }

    }
}