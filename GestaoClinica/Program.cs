using GestaoClinica.Components;
using GestaoClinica.Data.Context;
using GestaoClinica.Repository.Interfaces;
using GestaoClinica.Repository;
using GestaoClinica.Services.Interfaces;
using GestaoClinica.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using GestaoClinica.Repository.Implementation;
using GestaoClinica.Entities;
using GestaoClinica.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// --- Banco de dados ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SQLServerDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.LogTo(Console.WriteLine);
    }
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.WriteIndented = true;
});

// --- Serviços (Repository e Service) ---
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();
builder.Services.AddScoped<IServicoService, ServicoService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

// --- Blazor e MudBlazor ---
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// --- Controllers (API) ---
builder.Services.AddControllers();

// --- Swagger (para testar a API) ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// --- CORS (liberando tudo) ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// --- Ativar CORS antes do MapControllers ---
app.UseCors("PermitirTudo");

// --- API ---
app.MapControllers();

// --- Blazor ---
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
