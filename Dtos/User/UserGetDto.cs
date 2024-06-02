﻿namespace Dtos.User;

public class UserGetDto
{
    public Guid Id { get; set; } = Guid.Empty;
    public string? StudentNumber { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}