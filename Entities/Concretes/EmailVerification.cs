using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class EmailVerification : IEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}