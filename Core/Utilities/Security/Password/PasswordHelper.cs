using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Utilities.Security.Password
{
    public abstract class PasswordHelper
    {
        public static string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%";
            var password = Enumerable.Repeat(chars, 8)
                .Select(s => s[new Random().Next(s.Length)]).ToArray();
            
            return new string(password).ToUpper();
        }
        
    }
}