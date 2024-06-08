using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddDbContext<MovieContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("MovieConnection")));

var app = builder.Build();
app.UseCors("corsapp");

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
