using Joker.Net.BaseRepository;
using Joker.Net.BaseService;
using Joker.Net.EFCoreEnvironment.DbContexts;
using Joker.Net.IBaseRepository;
using Joker.Net.IBaseService;
using Joker.Net.Model;
using Joker.Net.MyBlog.Filters;
using Joker.Net.Utility;
using Joker.Net.Utility.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ����Swagger��Ȩ���
builder.Services.AddSwaggerGen(opt =>
{

    var scheme = new OpenApiSecurityScheme()
    {
        Description = $"Authorization header \r\n Example: 'Bearer xxxxxxxxxxxxxxxx'",
        Reference = new OpenApiReference() { Type = ReferenceType.SecurityScheme, Id = "Authorization" },
        Scheme = "oauth2",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    };

    opt.AddSecurityDefinition("Authorization", scheme);

    var requirement = new OpenApiSecurityRequirement();
    requirement[scheme] = new List<string>();
    opt.AddSecurityRequirement(requirement);

});


// ��ȡ�����ļ���jwt����Ϣ��Ȼ��ͨ��Configuration����ϵͳע�뵽Controller�������Ȩ
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("Jwt"));

// ����Jwt����Ȩ
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {

        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSetting>();
        byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecKey);
        var secKey = new SymmetricSecurityKey(keyBytes);

        opt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,  //����䷢Token��webӦ�ó���

            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,  //Token��������

            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = secKey,
            ClockSkew = TimeSpan.FromSeconds(jwtSettings.ExpireSeconds)
        };

    });


// ע��DbContext
builder.Services.AddDbContext<SqlDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// ע��Filter����
//builder.Services.Configure<MvcOptions>(opt =>
//{
//    opt.Filters.Add<JwtVersionCheckFilter>();
//});

// ע��AutoMapper����
builder.Services.AddAutoMapper(typeof(DTOMapper));


// �Զ�������ע��
builder.Services.AddCustomIOC();

// Identityע��
builder.Services.AddIdentity();

// ע��Redis�������
//ע��Redis�������
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = "localhost"; //redis��ַ
    opt.InstanceName = "blog_";      //����ǰ׺
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//��Ȩ
app.UseAuthentication();
//��Ȩ
app.UseAuthorization();



app.MapControllers();

app.Run();



public static class IOCExtend
{
    /// <summary>
    /// ע���Զ���ӿ�
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomIOC(this IServiceCollection services)
    {
        // ע��ִ���
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleTypeRepository, ArticleTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // ע������
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<IArticleTypeService, ArticleTypeService>();
        services.AddScoped<IUserService, UserService>();


        return services;
    }


    /// <summary>
    /// ע��Identity���
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        // ע�����ݱ���
        services.AddDataProtection();

        // ����IdentityCore
        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireDigit = true;   // ����Ҫ������
            opt.Password.RequireUppercase = true;   // ��д
            opt.Password.RequireLowercase = true;   // Сд
            opt.Password.RequireNonAlphanumeric = false;    // �Ƿ���Ҫ����ĸ�������ַ�
            opt.Password.RequiredLength = 6;    //����6λ����

            opt.Lockout.MaxFailedAccessAttempts = 5; //��¼ʧ�ܴ���
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //����5����

            opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;  // �������ù���
            opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
        });

        // ������֤���
        var idBuilder = new IdentityBuilder(typeof(User), typeof(Role), services);

        idBuilder.AddEntityFrameworkStores<SqlDbContext>()
            .AddDefaultTokenProviders()
            .AddUserManager<UserManager<User>>()
            .AddRoleManager<RoleManager<Role>>();

        return services;
    }
}