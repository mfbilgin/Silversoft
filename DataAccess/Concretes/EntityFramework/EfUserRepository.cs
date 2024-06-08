using DataAccess.Abstracts;
using DataAccess.Abstracts.EntityFramework;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class EfUserRepository(DbContext context) : EfEntityRepository<User>(context), IUserRepository
{
    public User? GetByUsername(string username)
    {
        return Get(user => user.Username == username);
    }

    public User? GetByEmail(string email)
    {
        return Get(user => user.Email == email);
    }

    public User? GetByStudentNumber(string? studentNumber)
    {
        return Get(user => user.StudentNumber == studentNumber);
    }

    public void VerifyEmail(string username)
    {
        var user = GetByUsername(username);
        if (user is null) return;
        user.EmailVerified = true;
        Update(user);
    }
}