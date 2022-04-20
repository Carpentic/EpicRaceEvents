#nullable disable

using System.ComponentModel.DataAnnotations;

namespace App.Models.Validators;

public class AgeValidator : ValidationAttribute
{
    int _minimumAge;

    public AgeValidator(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    public override bool IsValid(object value)
    {
        DateTime date;
        if (DateTime.TryParse(value.ToString(), out date))
        {
            return date.AddYears(_minimumAge) < DateTime.Now;
        }
        return false;
    }
}
