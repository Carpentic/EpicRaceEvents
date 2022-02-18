using System.ComponentModel.DataAnnotations;

namespace App.Models.DatabaseModels;

public class Driver
{
    public uint Id { get; set; }

    #region Driver Personnal Infos
    [DataType(DataType.Text)]
    [Required(ErrorMessage = "First name is required.")]
    [MinLength(2, ErrorMessage = "Fist name must be more than 2 characters.")]
    [MaxLength(30, ErrorMessage = "Fist name must be less than 30 characters.")]
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Last name is required.")]
    [MinLength(2, ErrorMessage = "Last name must be more than 2 characters.")]
    [MaxLength(30, ErrorMessage = "Last name must be less than 30 characters.")]
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Birth date is required.")]
    [Display(Name = "Date of Birth")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }

    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; set; }
    #endregion

    #region Driver Racing Infos
    public List<Vehicule>? Vehicules { get; set; }
    public List<Race>? Races { get; set; }
    #endregion
}
