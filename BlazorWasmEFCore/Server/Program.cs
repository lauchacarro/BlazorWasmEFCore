using BlazorWasmEFCore.Client.Helpers;
using BlazorWasmEFCore.Server.Data;

using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

using Remote.Linq.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews()
    .AddJsonOptions(o => o.JsonSerializerOptions.ConfigureRemoteLinq());

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseSqlite("Filename=appserver.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

SeedData();

app.Run();



void SeedData()
{

    var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!context.WeatherForecasts.Any())
    {
        context.WeatherForecasts.AddRange(WeatherForecastHelper.GetWeatherForecasts(100).WithId());

        context.SaveChanges();
    }
}
