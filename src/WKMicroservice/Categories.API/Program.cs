using Categories.API.Application.Queries.GetAll;
using Categories.API.IoC;
using System.Reflection;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersioning();
builder.Services.AddSwagger(Assembly.GetExecutingAssembly().GetName().Name);
builder.Services.AddMySql(builder.Configuration, dbHost, dbName, dbPassword);
builder.Services.AddRepositories();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllCategoriesQuery).Assembly));
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwaggerApp();

app.UseAuthorization();

app.MapControllers();

app.Run();
