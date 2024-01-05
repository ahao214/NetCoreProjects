using Autofac;
using JOKER.NetE.IService;
using JOKER.NetE.Repository.Base;
using JOKER.NetE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JOKER.NetE.Extension
{
    public class AutofacModuleRegister:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var basePath = AppContext.BaseDirectory;

            var servicesDllFile = Path.Combine(basePath, "JOKER.NetE.Service.dll");
            var repositoryDllFile = Path.Combine(basePath, "JOKER.NetE.Repository.dll");


            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).InstancePerDependency();


            // 获取Service.dll 程序集服务，并注册
            var assemblysService = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysService)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired();

            // 获取 Repository.dll 程序集服务，并注册
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired();

        }

    }
}
