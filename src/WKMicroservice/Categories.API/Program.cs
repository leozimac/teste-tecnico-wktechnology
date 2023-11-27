using Categories.API.Application.Queries.GetAll;
using Categories.API.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersioning();
builder.Services.AddSwagger(Assembly.GetExecutingAssembly().GetName().Name);
builder.Services.AddMySql(builder.Configuration);
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
