using System.ComponentModel.DataAnnotations;

namespace ManagementApp.API.Data.Models.MoneyManagement;

public class MoneyMovementReason : EntityWithTraceability
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es requerido.")]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "El nombre debe tener entre {2} y {1} caracteres.")]
    public string Name { get; set; } = null!;
    public const int NameMaxLength = 120;
    public const int NameMinLength = 3;

    [StringLength(SummaryMaxLength, MinimumLength = SummaryMinLength, ErrorMessage = "El resumen debe tener entre {2} y {1} caracteres.")]
    public string? Summary { get; set; }
    public const int SummaryMaxLength = 200;
    public const int SummaryMinLength = 3;
    
    public virtual ICollection<MoneyMovement> Movements { get; set; } = null!;
}