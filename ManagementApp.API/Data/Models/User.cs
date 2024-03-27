using System.ComponentModel.DataAnnotations;
using ManagementApp.API.Data.Models.MoneyManagement;

namespace ManagementApp.API.Data.Models;

public class User
{
    public int Id { get; set; }

    [StringLength(MaxFullNameLength, MinimumLength = MinFullNameLength, ErrorMessage = "El nombre debe estar entre {2} y {1} carácteres")]
    public string FullName { get; set; } = null!;
    public const int MaxFullNameLength = 120;
    public const int MinFullNameLength = 3;

    [DataType(DataType.EmailAddress)]
    [StringLength(MaxEmailLength, MinimumLength = MinEmailLength, ErrorMessage = "El correo debe estar entre {2} y {1} carácteres")]
    public string Email { get; set; } = null!;
    public const int MaxEmailLength = 256;
    public const int MinEmailLength = 5;
    
    [DataType(DataType.DateTime)]
    public DateTime? CreationDate { get; set; }
    
    [DataType(DataType.DateTime)]
    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<MoneyAccount> MoneyAccounts { get; set; } = null!;
}