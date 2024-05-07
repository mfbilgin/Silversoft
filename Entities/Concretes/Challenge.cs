using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class Challenge : IEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public DateTime ExpirationDate  { get; set; }

}