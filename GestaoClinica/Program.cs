using GestaoClinica.Components;
using GestaoClinica.Data.Context;
using GestaoClinica.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using GestaoClinica.Services.Implementations;
using GestaoClinica.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); // ← Essencial para páginas Razor
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();



// --- Serviços (Repository e Service) ---
builder.Services.AddScoped<IClienteService, MockClienteService>();

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = MudBlazor.Variant.Filled;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

// --- Mapeamento de componentes e rotas ---
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();