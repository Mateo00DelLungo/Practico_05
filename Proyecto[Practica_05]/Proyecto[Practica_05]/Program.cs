using Data.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Proyecto_Practica_05_.App;
using Proyecto_Practica_05_.Interfaces;
using Proyecto_Practica_05_.Models;
using Proyecto_Practica_05_.Services;
using Proyecto_Practica_05_.Utils;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//db context
var cnnstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TurnoDbContext>(options => options.UseSqlServer(cnnstring));

//inyeccion de la app
builder.Services.AddScoped<IApp, Aplication>();
// inyeccion de repositorios
builder.Services.AddScoped<IRepository<TServicio>, ServicioRepository>();
builder.Services.AddScoped<ITurnoRepository, TurnoRepository>();
builder.Services.AddScoped<IRepository<TDetalle>, DetalleRepository>();
//inyeccion de servicios
builder.Services.AddScoped<IManager<ServicioDTO>, ServicioManager>();
builder.Services.AddScoped<IManagerTurno, TurnoManager>();
builder.Services.AddScoped<IManager<DetalleDTO>, DetalleManager>();
//inyeccion de mapeador
builder.Services.AddScoped<IMapper<ServicioDTO, TServicio>, ServicioMapper>();
builder.Services.AddScoped<IMapper<TurnoDTO, TTurno>, TurnoMapper>();
builder.Services.AddScoped<IMapper<DetalleDTO, TDetalle>, DetalleMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
