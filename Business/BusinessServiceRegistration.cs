﻿using Business.Abstracts;
using Business.BusinessRules;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddSingleton<IRoleService, RoleManager>();
        services.AddSingleton<IRoleRepository, EfRoleRepository>();
    }
}