using Microsoft.EntityFrameworkCore;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Application db context initializer
        /// </summary>
        public AppDbContext() { }

        /// <summary>
        /// Application db context initializer
        /// </summary>
        /// <param name="options">DbContext options</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Branch> Branches { get; set; }

        /// <summary>
        /// Context creation
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().ToTable("Currencies");
            modelBuilder.Entity<Branch>().ToTable("Branches");
        }

        /// <summary>
        /// Context configuration
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=(localdb)\\mssqllocaldb;Database=QualaDBTest;Trusted_Connection=True;MultipleActiveResultSets=true";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
