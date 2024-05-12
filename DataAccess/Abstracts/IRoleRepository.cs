using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IRoleRepository : IEntityRepository<Role>
{
    Role? GetByName(string name);
}