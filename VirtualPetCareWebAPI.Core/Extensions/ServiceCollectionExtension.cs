using Microsoft.Extensions.DependencyInjection;
using VirtualPetCareWebAPI.Core.Utilities.IoC;

namespace VirtualPetCareWebAPI.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }
    }
}
