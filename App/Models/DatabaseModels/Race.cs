using System.ComponentModel.DataAnnotations;

namespace App.Models.DatabaseModels;

public class Race
{
    public class Result
    {
        public int Id { get; set; }
        public uint DriverId { get; set; }
        public uint RaceId { get; set; }
        public uint Position { get; set; }
    }

    public uint Id { get; set; }

    #region Race Infos
    [Required(ErrorMessage = "Race lattitude is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid lattitude.")]
    public double Lattitude { get; set; }

    [Required(ErrorMessage = "Race longitude is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid longitude.")]
    public double Longitude { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Race name is required.")]
    [MinLength(2, ErrorMessage = "Race name must be more than 2 characters.")]
    [MaxLength(50, ErrorMessage = "Race name must be less than 50 characters.")]
    public string? Name { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Race da1e is required.")]
    [Display(Name = "Event Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EventDate { get; set; }

    [DataType(DataType.Time)]
    [Required(ErrorMessage = "Race start time is required.")]
    [Display(Name = "Race Start Time")]
    [DisplayFormat(DataFormatString = "{0:HH:mm}")]
    public DateTime RaceTime { get; set; }

    [DataType(DataType.ImageUrl)]
    public string Image { get; set; } = string.Empty;

    public List<Result>? Results { get; set; }
    #endregion

    #region Race Drivers
    [Range(0, uint.MaxValue, ErrorMessage = "Please enter a valid number.")]
    [Display(Name = "Maximim number of participants")]
    public uint MaxParticipants { get; set; } = 15;

    [Range(0, uint.MaxValue, ErrorMessage = "Please enter a valid number.")]
    [Display(Name = "Minimum age of participants")]
    public uint MinAge { get; set; } = 21;

    public List<Driver>? Drivers { get; set; }
    #endregion

    #region Race Vehicules
    [Required(ErrorMessage = "Allowed vehicules categories are required.")]
    [Display(Name = "Allowed Vehicule Categories")]
    public List<Vehicule.AvailableCategory>? AllowedCategories { get; set; }
    #endregion
}
