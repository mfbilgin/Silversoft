using Entities.Concretes;

namespace Business.Abstracts;

public interface IRoleService : IEntityService<Role>
{
    Role? GetByName(string name);
}