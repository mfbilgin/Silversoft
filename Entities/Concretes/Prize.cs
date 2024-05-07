using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class Prize : IEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}