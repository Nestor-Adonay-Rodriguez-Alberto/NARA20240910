using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using NARA20240910.Endpoints;
using NARA20240910.Models.DAL;

var builder = WebApplication.CreateBuilder(args);

// Documentacion de la API:
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Contexto Para DB:  * AGREGADA *
builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));


// Inyeccion Dependencias: * AGREGADA*
builder.Services.AddScoped<ProductNARADAL>();

var app = builder.Build();


// Metodo De Los Endpoints: * AGREGADA *
app.AddCustomerEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

