using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static void AddDataAccessServices(this IServiceCollection services)
    {
        
        services.AddSingleton<IRoleRepository,EfRoleRepository>(); 
        services.AddSingleton<DbContext,SilversoftContext>();

    }
}