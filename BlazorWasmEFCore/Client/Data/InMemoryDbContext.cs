using BlazorWasmEFCore.Client.Helpers;
using BlazorWasmEFCore.Shared;

using Microsoft.EntityFrameworkCore;

namespace BlazorWasmEFCore.Client.Data
{
    public class InMemoryDbContext : DbContext
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> WeatherForecast => Set<WeatherForecast>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>();
        }
    }
}
