using Microsoft.EntityFrameworkCore;
using System.Reflection;
using User.Domain;
using User.Infrastructure;
using User.Infrastructure.DbContexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.WebAPI;
using Common.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    // 启用Swagger鉴权组件
    opt.AddAuthenticationHeader();
});

// 注入Jwt服务
var JwtConfig = builder.Configuration.GetSection("Jwt");
builder.Services.AddJwtAuthentication(JwtConfig.Get<JwtSetting>());
builder.Services.Configure<JwtSetting>(JwtConfig);


// 注入DbContext
builder.Services.AddDbContext<UserDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 注入Redis缓存
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = "127.0.01";
    opt.InstanceName = "shop_";
});

// 注入MediatR
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


// 注入事物单元服务
builder.Services.Configure<MvcOptions>(opt =>
{
    // 注入事物单元过滤器服务
    opt.Filters.Add<UnitOfWorkFilter>();

    // 注入Jwt提前撤回过滤器服务
    opt.Filters.Add<JwtVersionCheckFilter>();
});

// 注入自定义服务
builder.Services.AddScoped<UserDomainService>();
builder.Services.AddScoped<ISmsCodeSender, SmsCodeSender>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();


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
