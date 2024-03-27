using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementApp.API.Data.Models.MoneyManagement;

public class MoneyAccount : EntityWithTraceability
{
    public int Id { get; set; }
    
    [Column(TypeName = "decimal(18, 2)")] 
    [Range(MinCurrentBalance, MaxCurrentBalance, ErrorMessage = "El saldo actual debe estar entre {1} y {2}.")]
    [Required(ErrorMessage = "El saldo actual es requerido.")]
    public decimal CurrentBalance { get; set; }
    public const double MinCurrentBalance = 0;
    public const double MaxCurrentBalance = 10_000_000;

    public virtual ICollection<MoneyMovement> Movements { get; set; } = null!;
    public virtual ICollection<MoneyBank> Banks { get; set; } = null!;
    
    public virtual ICollection<MoneyBorrowed> MoneyBorrowed { get; set; } = null!;
}