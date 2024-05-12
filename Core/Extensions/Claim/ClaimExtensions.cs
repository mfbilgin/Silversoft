using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Extensions.Claim;

public static class ClaimExtensions
{
    public static void AddEmail(this ICollection<System.Security.Claims.Claim> claims, string email)
    {
        claims.Add(new System.Security.Claims.Claim(JwtRegisteredClaimNames.Email, email));
    }

    public static void AddName(this ICollection<System.Security.Claims.Claim> claims, string name)
    {
        claims.Add(new System.Security.Claims.Claim(ClaimTypes.Name, name));
    }

    public static void AddNameIdentifier(this ICollection<System.Security.Claims.Claim> claims, string nameIdentifier)
    {
        claims.Add(new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, nameIdentifier));
    }

    public static void AddRoles(this ICollection<System.Security.Claims.Claim> claims, string[] roles)
    {
        roles.ToList().ForEach(role => claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, role)));
    }
}