using DataAccess.Abstracts;
using DataAccess.Abstracts.EntityFramework;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class EfUserRepository(DbContext context) : EfEntityRepository<User>(context), IUserRepository
{
    
}