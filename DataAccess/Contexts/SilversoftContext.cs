using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Contexts;

public class SilversoftContext(IConfiguration configuration) : DbContext
{
    private readonly IConfiguration? _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_configuration == null) return;
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

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