using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Infrastructure;
using BusinessLogicLayer.Configuration;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile(new MappingProfile());
    });
IMapper mapper = mapperConfig.CreateMapper();
// Add services to the container.
builder.Services.AddSingleton<IMapper>(mapper);
builder.Services.AddSingleton<IUoWFactory, UoWFactory>();
builder.Services.AddSingleton<IDishService, DishService>();
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Restaurant", Version = "v1" });
    });

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<JwtMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
