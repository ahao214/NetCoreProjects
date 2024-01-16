using Joker.Net.BaseRepository;
using Joker.Net.BaseService;
using Joker.Net.EFCoreEnvironment.DbContexts;
using Joker.Net.IBaseRepository;
using Joker.Net.IBaseService;
using Joker.Net.Model;
using Joker.Net.Utility.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// 注入DbContext
builder.Services.AddDbContext<SqlDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 注入AutoMapper服务
builder.Services.AddAutoMapper(typeof(DTOMapper));


// 自定义依赖注入
builder.Services.AddCustomIOC();

// Identity注入
builder.Services.AddIdentity();

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



public static class IOCExtend
{
    /// <summary>
    /// 注入自定义接口
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCustomIOC(this IServiceCollection services)
    {
        // 注入仓储层
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleTypeRepository, ArticleTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        // 注入服务层
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<IArticleTypeService, ArticleTypeService>();
        services.AddScoped<IUserService, UserService>();


        return services;
    }


    /// <summary>
    /// 注入Identity框架
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        // 注入数据保护
        services.AddDataProtection();

        // 配置IdentityCore
        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireDigit = true;   // 必须要有数字
            opt.Password.RequireUppercase = true;   // 大写
            opt.Password.RequireLowercase = true;   // 小写
            opt.Password.RequireNonAlphanumeric = false;    // 是否需要非字母非数字字符
            opt.Password.RequiredLength = 6;    //最少6位长度

            opt.Lockout.MaxFailedAccessAttempts = 5; //登录失败次数
            opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //冻结5分钟

            opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;  // 密码重置规则
            opt.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
        });

        // 构建认证框架
        var idBuilder = new IdentityBuilder(typeof(User), typeof(Role), services);

        idBuilder.AddEntityFrameworkStores<SqlDbContext>()
            .AddDefaultTokenProviders()
            .AddUserManager<UserManager<User>>()
            .AddRoleManager<RoleManager<Role>>();

        return services;
    }
}