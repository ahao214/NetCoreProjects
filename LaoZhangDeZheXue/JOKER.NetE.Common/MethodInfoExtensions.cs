using System.Reflection;

namespace JOKER.NetE.Common
{
    public static class MethodInfoExtensions
    {
        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetFullName(this MethodInfo method)
        {
            if(method .DeclaringType== null)
            {
                return $@"{method.Name}";
            }
            return $"{method.DeclaringType.FullName}.{method.Name}";
        }
    }
}
