using Microsoft.EntityFrameworkCore;
using User.Domain;
using User.Infrastructure;
using User.Infrastructure.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// 注入自定义服务
builder.Services.AddScoped<ISmsCodeSender, SmsCodeSender>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
