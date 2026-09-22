using DeskFlow;
using DeskFlow.Repositories;
using DeskFlow.Repositories.Interfaces;
using DeskFlow.Services;
using DeskFlow.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();


string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DeskFlowDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<ICategoriasRepository, CategoriasRepository>();
builder.Services.AddScoped<IChamadosRepository, ChamadosRepository>();

builder.Services.AddScoped<ICategoriasService, CategoriasService>();
builder.Services.AddScoped<IChamadosService, ChamadosService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseSwaggerUI(op =>
{
    op.SwaggerEndpoint("/openapi/v1.json", "v1");
});
// app.UseHttpsRedirection();
app.MapControllers();


app.Run();
