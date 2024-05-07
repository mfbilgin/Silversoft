using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class Role : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}