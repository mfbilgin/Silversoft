﻿using System;
using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class User : IEntity
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string StudentNumber { get; set; } 
    public string Email { get; set; } 
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public int Point { get; set; }
    public bool Status { get; set; }
        
}