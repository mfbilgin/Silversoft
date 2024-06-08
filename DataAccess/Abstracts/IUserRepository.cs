using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IUserRepository : IEntityRepository<User>
{
    public User? GetByUsername(string username);
    public User? GetByEmail(string email);
    public User? GetByStudentNumber(string? studentNumber);
    public void VerifyEmail(string username);
}