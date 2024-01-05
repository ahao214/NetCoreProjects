using Autofac;
using Autofac.Extras.DynamicProxy;
using JOKER.NetE.IService;
using JOKER.NetE.Repository.Base;
using JOKER.NetE.Service;
using System.Reflection;

namespace JOKER.NetE.Extension
{
    public class AutofacModuleRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;

            var servicesDllFile = Path.Combine(basePath, "JOKER.NetE.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "JOKER.NetE.Repository.dll");

            var aopTypes = new List<Type>() { typeof(ServiceAOP) };
            builder.RegisterType<ServiceAOP>();

            // 注册仓储
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();

            // 注册服务
            builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).InstancePerDependency().EnableInterfaceInterceptors().InterceptedBy(aopTypes.ToArray()); 


            // 获取Service.dll 程序集服务，并注册
            var assemblysService = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysService)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired()
                .EnableClassInterceptors()
                .InterceptedBy(aopTypes.ToArray());

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired();

        }

    }
}
