namespace Entities.Concretes;

public class QuestionSolver
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid UserId { get; set; } = Guid.Empty;
    public Guid QuestionId { get; set; } = Guid.Empty;
    public DateTime SolutionDate { get; set; }
    public bool IsFirst { get; set; }

    public User User { get; set; } = new();
    public Question Question { get; set; } = new();
}