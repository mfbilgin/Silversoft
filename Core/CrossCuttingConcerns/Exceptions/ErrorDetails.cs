﻿using FluentValidation.Results;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ErrorDetails
{
    public string Message { get; set; } = string.Empty;
    public int StatusCode { get; set; }


    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; } = [];
    }
    public class BusinessExceptionDetails : ErrorDetails
    {
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
    
    public class AuthorizationExceptionDetails : ErrorDetails
    {
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}