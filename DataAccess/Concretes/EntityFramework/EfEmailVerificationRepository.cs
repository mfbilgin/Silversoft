using DataAccess.Abstracts;
using DataAccess.Abstracts.EntityFramework;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework;

public class EfEmailVerificationRepository(DbContext context) : EfEntityRepository<EmailVerification>(context), IEmailVerificationRepository
{
    public EmailVerification? GetByToken(string token)
    {
        return Get(email => email.Token == token);
    }
}