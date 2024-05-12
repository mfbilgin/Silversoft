using Core.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class CoreServiceRegistration
{
    public static void AddCoreServices(this IServiceCollection services, params ICoreModule[] coreModules)
    {
        foreach (var coreModule in coreModules)
        {
            coreModule.Load(services);
        }
        
        ServiceTool.Create(services);
    }
}