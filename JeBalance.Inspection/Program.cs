using JeBalance.Denonciations;
using JeBalance.Domain;
using JeBalance.Infrastructure.SQLite;
using Microsoft.EntityFrameworkCore;
using JeBalance.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// For Entity 
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("localdb")),
    contextLifetime: ServiceLifetime.Scoped,
    optionsLifetime: ServiceLifetime.Transient);

builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

//app.UseAuthorization();



app.MapControllers();

app.Run();
