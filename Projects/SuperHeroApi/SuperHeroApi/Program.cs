using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var heroConnectionString = builder
    .Configuration
    .GetConnectionString("HeroesConnection");

builder
    .Services
    .AddDbContext<HeroContext>( options =>
        options.UseMySql(
            heroConnectionString, 
            ServerVersion.AutoDetect(heroConnectionString)
        ) 
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
