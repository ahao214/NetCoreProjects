using AutoMapper;
using JOKER.NetE.Model;

namespace JOKER.NetE.Extension.ServiceExtensions
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<Role, RoleView>().ForMember(a => a.RoleName, o => o.MapFrom(d => d.Name));
            CreateMap<RoleView, Role>().ForMember(a => a.Name, o => o.MapFrom(d => d.RoleName));

        }

    }
}
