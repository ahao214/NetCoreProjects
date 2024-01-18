using Cart.Domain;
using Cart.Infrastructure;
using Cart.Infrastructure.DbContexts;
using Cart.WebAPI;
using Common.Jwt;
using Common.RabbitMQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddAuthenticationHeader();
});


//JWT
var JwtConfig = builder.Configuration.GetSection("Jwt");
builder.Services.AddJwtAuthentication(JwtConfig.Get<JwtSetting>());

// 注入RabbitMQ
builder.Services.AddRabbitMQ();

// 注入过滤器
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<CartJwtVersionCheckFilter>();
    opt.Filters.Add<UnitOfWorkFilter>();
});

// 注入DbContext
builder.Services.AddDbContext<CartDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 自定义服务
builder.Services.AddScoped<CartDomainService>();
builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();
builder.Services.AddScoped<ICartRepository, CartRepository>();

// 注入Redis
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = "43.143.170.48";
    opt.InstanceName = "shop_";
});

// 跨域
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(bui =>
    {
        bui.WithOrigins(new string[] { "http://localhost:8080" })
        .AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
