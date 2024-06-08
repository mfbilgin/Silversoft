using Entities.Abstracts;

namespace Entities.Concretes;

public sealed class UserPrize : IEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
    public Guid PrizeId { get; set; } = Guid.Empty;
    public DateTime BuyDate { get; set; }
}