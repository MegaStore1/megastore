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

    }
}