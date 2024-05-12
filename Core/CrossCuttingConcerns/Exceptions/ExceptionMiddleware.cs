using System.Net;
using Core.CrossCuttingConcerns.Exceptions.Business;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using ValidationFailure = FluentValidation.Results.ValidationFailure;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionMiddleware(RequestDelegate next)
{
    IEnumerable<ValidationFailure> _errors = [];

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(httpContext, e);
        }
    }

    private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var message = e.Message.IsNullOrEmpty() ? "Internal Server Error" : e.Message;
        if (e.GetType() == typeof(ValidationException))
        {
            _errors = ((ValidationException)e).Errors;
            httpContext.Response.StatusCode = 422;

            return httpContext.Response.WriteAsync(new ErrorDetails.ValidationErrorDetails
            {
                StatusCode = 422,
                Message = message,
                ValidationErrors = _errors
            }.ToString());
        }

        if (e.GetType() == typeof(BusinessException))
        {
            httpContext.Response.StatusCode = 400;

            return httpContext.Response.WriteAsync(new ErrorDetails.BusinessExceptionDetails
            {
                StatusCode = 400,
                Message = message,
            }.ToString());
        }

        if (e.GetType() == typeof(AuthorizationException))
        {
            httpContext.Response.StatusCode = 401;

            return httpContext.Response.WriteAsync(new ErrorDetails.AuthorizationExceptionDetails
            {
                StatusCode = 401,
                Message = message,
            }.ToString());
        }
        
        return httpContext.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = message
        }.ToString());
    }
}