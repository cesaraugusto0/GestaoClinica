using GestaoClinica.Components;
using GestaoClinica.Data.Context;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Repository;
using GestaoClinica.Services.Interfaces;
using GestaoClinica.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// --- Banco de dados ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Database=GestaoClinicaDb;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True";

builder.Services.AddDbContext<SQLServerDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.LogTo(Console.WriteLine);
    }
});

// --- Serviços (Repository e Service) ---
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

// --- Blazor e MudBlazor ---
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices(); // Apenas uma vez

// --- Adicione isso: Suporte a Controllers (para a API) ---
builder.Services.AddControllers();

// --- Swagger (para testar a API) ---
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else
{

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// --- Mapeie os controllers (API) ---
app.MapControllers(); // ← Essencial para a API

// --- Mapeie o Blazor ---
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();