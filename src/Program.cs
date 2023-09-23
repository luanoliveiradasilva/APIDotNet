using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using src.app.Data.Repository;
using Data.Context;
using Services;
using Services.Interface;
using Data.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register database
builder.Services.AddDbContext<AppContexts>(options => options.UseMySql(builder.Configuration.GetConnectionString("AppContexts"), ServerVersion.Parse("7.0.0") ?? throw new InvalidOperationException("Connection string 'AppContext' not found.")));

// Register UserService to use it with Dependency Injection in Controllers
builder.Services.AddTransient<IUserServices, UserService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

builder.Services.AddControllers().AddJsonOptions(x=> x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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