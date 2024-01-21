using JeBalance.Infrastructure.SQLite.Model;
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
            modelBuilder.ApplyConfiguration(new PersonneConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            if (!optionsBuilder.IsConfigured)
            {
                // Utilisation d'un chemin relatif
                string databasePath = Path.Combine(Directory.GetCurrentDirectory(), "JeBalanceDb.db");
                optionsBuilder.UseSqlite($"Data Source={databasePath}");
            }
        }
    }
}
