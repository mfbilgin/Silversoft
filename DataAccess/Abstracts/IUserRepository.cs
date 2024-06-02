using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IUserRepository : IEntityRepository<User>
{
    public User? GetByUsername(string username);
}