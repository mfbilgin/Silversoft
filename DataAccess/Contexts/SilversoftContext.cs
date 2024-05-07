using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts;

public class SilversoftContext(DbContextOptions<SilversoftContext> options) : DbContext(options)
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Hint> Hints { get; set; }
    public DbSet<Prize> Prizes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionSolver> QuestionSolvers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserPrize> UserPrizes { get; set; }
}