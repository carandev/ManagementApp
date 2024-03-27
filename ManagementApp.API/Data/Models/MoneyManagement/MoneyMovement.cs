using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementApp.API.Data.Models.MoneyManagement;

public class MoneyMovement : EntityWithTraceability
{
    public int Id { get; set; }

    [Column(TypeName = "decimal(18, 2)")] 
    [Range(MinAmount, MaxAmount, ErrorMessage = "El monto debe estar entre {1} y {2}.")]
    [Required(ErrorMessage = "El monto es requerido.")]
    public decimal Amount { get; set; }
    public const double MinAmount = 0;
    public const double MaxAmount = 10_000_000;

    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "La fecha del movimiento es requerida.")]
    public DateTime MovementDate { get; set; }

    [Required(ErrorMessage = "El tipo de movimiento es requerido.")]
    public MoneyMovementType Type { get; set; }

    public int ReasonId { get; set; }
    public MoneyMovementReason Reason { get; set; } = null!;
    
    public int AccountId { get; set; }
    public MoneyAccount MoneyAccount { get; set; } = null!;

    public int OriginBankId { get; set; }
    public MoneyBank OriginBank { get; set; } = null!;
}