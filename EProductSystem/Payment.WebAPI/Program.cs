using Common.Alipay;
using Common.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddAuthenticationHeader();
});

//��ȡ�����ļ���Jwt������
var JwtConfig = builder.Configuration.GetSection("Jwt");
builder.Services.AddJwtAuthentication(JwtConfig.Get<JwtSetting>());

//��ȡ�����ļ���Alipay������
var AlipayConfig = builder.Configuration.GetSection("Alipay");
builder.Services.AddAlipay(AlipayConfig.Get<AlipaySetting>());


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