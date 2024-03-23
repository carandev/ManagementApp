namespace ManagementApp.API.Data.Models;

public class MoneyBank : EntityWithTraceability
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Summary { get; set; }

    public int AccountId { get; set; }
    public MoneyAccount Account { get; set; } = null!;

    public ICollection<MoneyMovement> Movements { get; set; } = null!;
}