namespace ManagementApp.API.Data.Models;

public class MoneyMovementReason : EntityWithTraceability
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Summary { get; set; }
}