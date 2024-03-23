using System.ComponentModel.DataAnnotations;

namespace ManagementApp.API.Data.Models;

public enum MoneyMovementType
{
    [Display(Name = "Ingreso")]
    Income = 10,
    
    [Display(Name = "Egreso")]
    Expense = 20,
    
    [Display(Name = "Transferencia entre cuentas")]
    AccountTransfer = 30
}