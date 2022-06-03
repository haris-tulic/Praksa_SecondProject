using Microsoft.EntityFrameworkCore;
using Praksa_SecondProject.Database;
using Praksa_SecondProject.Services.Interfaces;
using Praksa_SecondProject.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBandService, BandService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
