#nullable disable

using App.Models.ValidationLayers;
using System.ComponentModel.DataAnnotations;

namespace App.Models.DatabaseModels;

public class Race
{
    public class Result
    {
        public int Id { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Race Race { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        public uint Position { get; set; }
    }

    public uint Id { get; set; }

    #region Race Infos
    [Required(ErrorMessage = "Race lattitude is required.")]
    [CoordinatesValidation]
    public double Lattitude { get; set; }

    [Required(ErrorMessage = "Race longitude is required.")]
    [CoordinatesValidation]
    public double Longitude { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Race name is required.")]
    [MinLength(2, ErrorMessage = "Race name must be more than 2 characters.")]
    [MaxLength(50, ErrorMessage = "Race name must be less than 50 characters.")]
    public string Name { get; set; }

    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Race date and time are required.")]
    [Display(Name = "Event Date/Time")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm::ss}")]
    public DateTime EventDate { get; set; }

    [DataType(DataType.ImageUrl)]
    public string Image { get; set; } = string.Empty;

    public virtual List<Result> Results { get; set; }
    #endregion

    #region Race Drivers
    [Range(0, uint.MaxValue, ErrorMessage = "Please enter a valid number.")]
    [Display(Name = "Maximim number of participants")]
    public uint MaxParticipants { get; set; } = 15;

    [Range(0, uint.MaxValue, ErrorMessage = "Please enter a valid number.")]
    [Display(Name = "Minimum age of participants")]
    public uint MinAge { get; set; } = 21;

    public virtual List<Driver> Drivers { get; set; }
    #endregion

    #region Race Vehicules
    [Required(ErrorMessage = "Allowed vehicules categories are required.")]
    [Display(Name = "Allowed Vehicule Categories")]
    public virtual List<Vehicule.AvailableCategory> AllowedCategories { get; set; }
    #endregion
}
