using DataAccess.Abstracts;
using DataAccess.Abstracts.EntityFramework;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class EfRoleRepository(DbContext context) : EfEntityRepository<Role>(context),IRoleRepository
{
    public Role? GetByName(string name)
    {
        return Get(role => role.Name == name);
    }
    
}