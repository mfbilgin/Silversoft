using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Extensions.Claim;
using Core.Interceptors;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Security;

public class SecurityAspect(string roles) : MethodInterception
{
    private readonly string[] _roles = roles.Split(',');

    private readonly IHttpContextAccessor? _httpContextAccessor =
        ServiceTool.ServiceProvider?.GetService<IHttpContextAccessor>();

    protected override void OnBefore(IInvocation invocation)
    {
        if (_httpContextAccessor == null)
        {
            throw new NullReferenceException("HttpContextAccessor is null.");
        }

        var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
        if (_roles.Any(role => roleClaims.Contains(role)))
        {
            return;
        }

        throw new AuthorizationException();
    }
}