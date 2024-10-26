using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Components;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Inyeccion del contexto
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

//Inyeccion del servicio
builder.Services.AddScoped<TecnicosService>();
builder.Services.AddScoped<TiposTecnicosService>();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<TrabajosService>();
builder.Services.AddScoped<PrioridadesService>();
builder.Services.AddScoped<TrabajosDetalleService>();
builder.Services.AddScoped<CotizacionesService>();
builder.Services.AddScoped<CotizacionesDetalleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
