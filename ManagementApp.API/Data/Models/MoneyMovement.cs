namespace ManagementApp.API.Data.Models;

public class MoneyMovement : EntityWithTraceability
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public DateTime MovementDate { get; set; }

    public MoneyMovementType Type { get; set; }

    public int ReasonId { get; set; }
    public MoneyMovementReason Reason { get; set; } = null!;
    
    public int AccountId { get; set; }
    public MoneyAccount MoneyAccount { get; set; } = null!;

    public int OriginBankId { get; set; }
    public MoneyBank OriginBank { get; set; } = null!;
}