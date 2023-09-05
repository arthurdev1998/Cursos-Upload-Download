using Data.Contexto.Context;
using Domain.Entities;
using Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//CONEXAO COM O BANCO DE DADOS

string stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(stringConnection));


// UTILIZACAO DOS OBJETOS <REPOSITORY>

builder.Services.AddScoped<AlunoRepository>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddTransient<IManageImage, ManageImage>();

// AUTOMAPPER

builder.Services.AddAutoMapper(typeof(EntitiesToDto));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
