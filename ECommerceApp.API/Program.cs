using ECommerceApp.API.Extentions;
//using Microsoft.OpenApi.Models;
using ECommerceApp.Business.Helpers;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.Services;
using ECommerceApp.Data.Interfaces;
using ECommerceApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var sourses = builder.Configuration.Sources;

builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddScoped<IBasketService, BasketService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
//builder.Services.AddTransient<IEmailSender, EmailSender>();

var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();

builder.Services.AddSingleton(jwtOptions);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.IdentityServices(jwtOptions);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.configureExceptionErrorHandler();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
