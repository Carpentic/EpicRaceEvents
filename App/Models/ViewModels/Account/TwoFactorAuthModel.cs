#nullable disable

using System.ComponentModel.DataAnnotations;

namespace App.Models.ViewModels.Account;

public class TwoFactorAuthModel
{
    [Required]
    [DataType(DataType.Text)]
    public string TwoFactorCode { get; set; }
    public bool RememberMe { get; set; }
}
