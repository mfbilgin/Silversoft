﻿namespace Core.CrossCuttingConcerns.Exceptions;

public class AuthorizationException() : Exception("Unauthorized Access! You do not have permission to access this resource.");