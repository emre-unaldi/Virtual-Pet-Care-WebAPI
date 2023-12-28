using Microsoft.Extensions.DependencyInjection;

namespace VirtualPetCareWebAPI.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
