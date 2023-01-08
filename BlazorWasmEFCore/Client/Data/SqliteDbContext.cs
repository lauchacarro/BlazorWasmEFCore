using BlazorWasmEFCore.Shared;

using Microsoft.EntityFrameworkCore;

namespace BlazorWasmEFCore.Client.Data
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WeatherForecast> WeatherForecast => Set<WeatherForecast>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().HasKey(x => x.Id);
            modelBuilder.Entity<WeatherForecast>().Property(x => x.Summary).UseCollation("nocase");
        }
    }
}
