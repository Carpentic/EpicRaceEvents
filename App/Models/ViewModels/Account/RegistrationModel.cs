#nullable disable

using App.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace App.Models.ViewModels.Account;

public class RegistrationModel
{
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "First name is required.")]
    [MinLength(2, ErrorMessage = "Fist name must be more than 2 characters.")]
    [MaxLength(30, ErrorMessage = "Fist name must be less than 30 characters.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Last name is required.")]
    [MinLength(2, ErrorMessage = "Last name must be more than 2 characters.")]
    [MaxLength(30, ErrorMessage = "Last name must be less than 30 characters.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birth date is required.")]
    [AgeValidator(16, ErrorMessage = "You must be at least 16 to register.")]
    [Display(Name = "Date of Birth")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}
