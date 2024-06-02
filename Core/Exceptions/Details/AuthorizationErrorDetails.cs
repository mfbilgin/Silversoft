using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Core.Exceptions.Details;

public class AuthorizationErrorDetails : IErrorDetails
{
    public int StatusCode { get; } = StatusCodes.Status401Unauthorized;
    public string Message { get; } = "You are not authorized to access this resource.";
    public string GetDetails()
    {
        return JsonConvert.SerializeObject(this);
    }
}