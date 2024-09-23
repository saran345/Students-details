using System.Data.SqlClient;
using WebApi05.Data;
using WebApi05.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Get connection string from configuration.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register SqlConnections as a singleton service
builder.Services.AddSingleton(new SqlConnections(connectionString));
builder.Services.AddSingleton<IStudentsRepository, StudentsRepository>();




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
