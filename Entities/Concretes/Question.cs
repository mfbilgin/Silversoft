using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class Question : IEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid ChallengeId { get; set; } = Guid.Empty;
    
    public string? Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public double Point { get; set; }
    public bool IsSolved { get; set; }
}