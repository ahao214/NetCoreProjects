
using Autofac;
using Autofac.Extensions.DependencyInjection;
using JOKER.NetE.Common;
using JOKER.NetE.Extension;
using JOKER.NetE.Extensions;
using JOKER.NetE.IService;
using JOKER.NetE.Repository.Base;
using JOKER.NetE.Service;

namespace JOKER.NetE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule<AutofacModuleRegister>();
                    builder.RegisterModule<AutofacPropertityModuleReg>();
                });


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            AutoMapperConfig.RegisterMappings();


            // ≈‰÷√
            builder.Services.AddSingleton(new AppSettings(builder.Configuration));

            // “¿¿µ◊¢»Î
            //builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
            //builder.Services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
