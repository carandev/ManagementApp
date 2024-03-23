namespace ManagementApp.API.Data.Models;

public class MoneyOwed : EntityWithTraceability
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int AccountId { get; set; }
    public MoneyAccount Account { get; set; } = null!;

    public int? OriginBankId { get; set; }
    public MoneyBank? OriginBank { get; set; }
}