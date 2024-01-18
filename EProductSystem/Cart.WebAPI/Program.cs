using Cart.WebAPI;
using Common.Jwt;
using Common.RabbitMQ;
using Microsoft.AspNetCore.Mvc;


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

builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<CartJwtVersionCheckFilter>();
});



// 自定义服务
builder.Services.AddScoped<IRabbitMqService, RabbitMqService>();

// 注入Redis
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = "43.143.170.48";
    opt.InstanceName = "shop_";
});





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
