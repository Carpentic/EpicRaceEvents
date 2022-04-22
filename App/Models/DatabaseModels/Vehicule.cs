using System.ComponentModel.DataAnnotations;

namespace App.Models.DatabaseModels;

public class Vehicule
{
    public class AvailableCategory
    {
        public uint Id { get; set; }

        #region Category Infos
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Color is required")]
        public string? Color { get; set; }

        [DataType(DataType.Text)]
        public string? Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string? Image { get; set; }
        #endregion
    }

    public uint Id { get; set; }

    #region Vehicule Infos
    [DataType(DataType.Date)]
    [Display(Name = "Build Date")]
    public DateTime BuildDate { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Brand is required.")]
    public string? Brand { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Model is required.")]
    public string? Model { get; set; }

    [DataType(DataType.ImageUrl)]
    public string? Image { get; set; }

    [Required(ErrorMessage = "PowerLevel is required.")]
    [Range(0, uint.MaxValue, ErrorMessage = "Please enter a valid number.")]
    public uint PowerLevel { get; set; }

    [Required(ErrorMessage = "HorsePower is required.")]
    [Range(0, uint.MaxValue, ErrorMessage = "Please enter a valid number.")]
    public uint HorsePower { get; set; }
    #endregion

    public List<AvailableCategory>? Categories { get; set; }
    public List<Driver>? PossessedBy { get; set; }
}
