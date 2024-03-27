using System.ComponentModel.DataAnnotations;

namespace ManagementApp.API.Data.Models.MoneyManagement;

public class MoneyBank : EntityWithTraceability
{
    public int Id { get; set; }

    [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "El nombre debe tener entre {2} y {1} caracteres.")]
    [Required(ErrorMessage = "El nombre es requerido.")]
    public string Name { get; set; } = null!;
    public const int NameMaxLength = 120;
    public const int NameMinLength = 3;

    [StringLength(SummaryMaxLength, MinimumLength = SummaryMinLength, ErrorMessage = "El resumen debe tener entre {2} y {1} caracteres.")]
    public string? Summary { get; set; }
    public const int SummaryMaxLength = 200;
    public const int SummaryMinLength = 3;

    public int AccountId { get; set; }
    public MoneyAccount Account { get; set; } = null!;

    public ICollection<MoneyMovement> Movements { get; set; } = null!;
    public ICollection<MoneyBorrowed> MoneyBorrowed { get; set; } = null!;
}