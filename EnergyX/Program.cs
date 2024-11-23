using Microsoft.EntityFrameworkCore;
using EnergyX.Data;
using EnergyX.Services;
using EnergyX.Models;
using EnergyX.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Configura��o da conex�o com o banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));


// Configuração do AutoMapper
// builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// builder.Services.AddAutoMapper(typeof(MappingProfile));

// builder.Services.AddAutoMapper(cfg =>
// {
//     cfg.CreateMap<Operadores, OperadoresDto>();
// }, typeof(Program).Assembly);

// Inje��o de reposit�rios
builder.Services.AddScoped<EnergyX.Repositories.Interfaces.IOperadoresRepository, EnergyX.Repositories.Implementations.OperadoresRepository>();
builder.Services.AddScoped<EnergyX.Repositories.Interfaces.IRelatoriosTurnoRepository, EnergyX.Repositories.Implementations.RelatoriosTurnoRepository>();
builder.Services.AddScoped<EnergyX.Repositories.Interfaces.IReatorRepository, EnergyX.Repositories.Implementations.ReatorRepository>();
// builder.Services.AddScoped<EnergyX.Repositories.Interfaces.IHistoricoRelatorioRepository, EnergyX.Repositories.Implementations.HistoricoRelatorioRepository>();
// builder.Services.AddScoped<EnergyX.Repositories.Interfaces.ILocalizacaoReatorRepository, EnergyX.Repositories.Implementations.LocalizacaoReatorRepository>();
// builder.Services.AddScoped<EnergyX.Repositories.Interfaces.ITipoReatorRepository, EnergyX.Repositories.Implementations.TipoReatorRepository>();
// builder.Services.AddScoped<EnergyX.Repositories.Interfaces.ITurnoRepository, EnergyX.Repositories.Implementations.TurnoRepository>();

// Inje��o de servi�os
builder.Services.AddScoped<IOperadoresService, OperadoresService>();
builder.Services.AddScoped<IRelatoriosTurnoService, RelatoriosTurnoService>();
builder.Services.AddScoped<IReatoresService, ReatoresService>();
// builder.Services.AddScoped<IHistoricoRelatorioService, HistoricoRelatorioService>();
// builder.Services.AddScoped<ITipoReatorService, TipoReatorService>();
// builder.Services.AddScoped<ITurnosService, TurnosService>();

// Adiciona servi�os ao cont�iner.
builder.Services.AddControllersWithViews(); // Adiciona suporte para controladores MVC
builder.Services.AddEndpointsApiExplorer(); // Habilita a explora��o de endpoints

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))
           .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information));


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10); // Tempo de expira��o da sess�o
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSession(); // Ativa o uso da sess�o
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"
);

app.Run();
