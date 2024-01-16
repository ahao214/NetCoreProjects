using Joker.Net.BaseRepository;
using Joker.Net.BaseService;
using Joker.Net.EFCoreEnvironment.DbContexts;
using Joker.Net.IBaseRepository;
using Joker.Net.IBaseService;
using Joker.Net.Utility.Mappers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// ע��DbContext
builder.Services.AddDbContext<SqlDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// ע��AutoMapper����
builder.Services.AddAutoMapper(typeof(DTOMapper));


// �Զ�������ע��
builder.Services.AddCustomIOC();

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
    public static IServiceCollection AddCustomIOC(this IServiceCollection services)
    {
        // ע��ִ���
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IArticleTypeRepository, ArticleTypeRepository>();
        // ע������
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<IArticleTypeService, ArticleTypeService>();

        return services;
    }

}