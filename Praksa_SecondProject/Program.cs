using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Praksa_SecondProject.Database;
using Praksa_SecondProject.Services.Interfaces;
using Praksa_SecondProject.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(setupAction =>
{
    setupAction.CacheProfiles.Add("100secondsCacheProfile", new CacheProfile { Duration = 100 });
});

//}).AddNewtonsoftJson(setupAction =>
//{
//    setupAction.SerializerSettings.ContractResolver =
//    new CamelCasePropertyNamesContractResolver();
//})
//              .AddXmlDataContractSerializerFormatters();) ;

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

app.UseResponseCaching();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
