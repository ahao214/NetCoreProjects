using Microsoft.EntityFrameworkCore;
using Product.Domain;
using Product.Infrastructure;
using Product.Infrastructure.Configs;
using Product.Infrastructure.DBContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ProductDbContext>(opt =>
//{
//    opt.UseNpgsql(builder.Configuration.GetSection("ConnStr").Value);
//});

builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// ◊¢»Î≤÷¥¢≤„
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


// ≈‰÷√øÁ”Ú
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(bui =>
    {
        bui.WithOrigins(new string[] { "http://localhost:5000" })
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

//  π”√øÁ”Ú
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
