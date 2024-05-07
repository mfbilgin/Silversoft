using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class Hint : IEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid QuestionId { get; set; } = Guid.Empty;
    public string Content { get; set; } = string.Empty;
    public int Price { get; set; }
    
    public Question Question { get; set; } = new();
}