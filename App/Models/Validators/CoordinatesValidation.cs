using System.ComponentModel.DataAnnotations;

namespace App.Models.ValidationLayers;

public class CoordinatesValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult($"Value is required.");

        double coordinate;
        if (double.TryParse(value.ToString()!.Replace(".", ","), out coordinate))
        {
            if (coordinate < 0)
                return new ValidationResult($"Value must be greater than 0.");
        }
        else
        {
            return new ValidationResult($"{value} must be a valid coordinate.");
        }
        return ValidationResult.Success;
    }
}
