﻿namespace Dtos.User;

public class ChangeUserPasswordDto
{
    public Guid Id { get; set; }
    public string CurrentPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}