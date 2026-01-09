using CatalogoFilme.Service;
using CatalogoFilme.Domain.Repository;
using CatalogoFilme.Domain.Entity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI();

app.Run();
