using BlazorWasmEFCore.Shared;

using Microsoft.EntityFrameworkCore;

namespace BlazorWasmEFCore.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
    }
}
