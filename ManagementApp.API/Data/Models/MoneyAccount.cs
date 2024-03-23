namespace ManagementApp.API.Data.Models;

public class MoneyAccount : EntityWithTraceability
{
    public int Id { get; set; }

    public decimal CurrentBalance { get; set; }

    public int OwnerId { get; set; }
    public User Owner { get; set; } = null!;

    public virtual ICollection<MoneyMovement> Movements { get; set; } = null!;
    public virtual ICollection<MoneyBank> Banks { get; set; } = null!;
}