using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class Event : IEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? BannerUrl { get; set; }
    public string Location { get; set; } = string.Empty;
    public DateTime EventTime { get; set; }
}