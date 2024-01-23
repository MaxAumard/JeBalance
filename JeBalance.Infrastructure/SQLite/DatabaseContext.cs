﻿using JeBalance.Infrastructure.SQLite.Model;
using Microsoft.EntityFrameworkCore;
using JeBlance.Infrastructure.SQLServer.Configurations;
//dotnet ef migrations add initial --context DatabaseContext
namespace JeBalance.Infrastructure.SQLite
{
    public class DatabaseContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "app";

        public DbSet<PersonneSQL> Personnes { get; set; }
        public DbSet<DenonciationSQL> Denonciations { get; set; }

        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new DenonciationConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=JeBalance.db");
            }
        }
    }
}
