using GestaoClinica.Components;
using GestaoClinica.Data.Context;
using GestaoClinica.Services.Implementations;
using GestaoClinica.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
// String de conexão do SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar o DbContext com SQL Server
builder.Services.AddDbContext<SQLServerDbContext>(options =>
{
    options.UseSqlServer(connectionString);

    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.LogTo(Console.WriteLine);
    }
});

// Registrar servicos de uso
builder.Services.AddScoped<IPessoaService, PessoaService>();

builder.Services.AddMudServices();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
