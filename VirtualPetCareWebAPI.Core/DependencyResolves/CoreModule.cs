using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using VirtualPetCareWebAPI.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;

namespace VirtualPetCareWebAPI.Core.DependencyResolves
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
