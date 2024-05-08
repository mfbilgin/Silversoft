using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes.EntityFramework;

public class EfRoleRepository : EfEntityRepository<Role,SilversoftContext> ,IRoleRepository;