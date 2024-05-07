using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class User : IEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid RoleId { get; set; } = Guid.Empty;
    
    public string? StudentNumber { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    
    public Role Role { get; set; } = new();
}