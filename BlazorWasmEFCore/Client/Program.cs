using BlazorWasmEFCore.Client;
using BlazorWasmEFCore.Client.Data;

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<InMemoryDbContext>(o => o.UseInMemoryDatabase("database"));

builder.Services.AddDbContext<SqliteDbContext>(o => o.UseSqlite("Filename=app.db"));

builder.Services.AddScoped<RemoteLinqContext>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
