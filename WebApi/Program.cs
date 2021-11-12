//using Microsoft.EntityFrameworkCore;
using EFDataAccessLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Restaurant", Version = "v1" });
});
// var connectionString = builder.Configuration.GetConnectionString("AppDatabase");
// builder.Services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<RestaurantContext>();

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
