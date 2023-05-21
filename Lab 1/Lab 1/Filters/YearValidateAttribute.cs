using Lab_1.Models;
using System.ComponentModel.DataAnnotations;

namespace Lab_1.Filters;

public class YearValidateAttribute : ValidationAttribute
{
    private readonly int _min1;
    private readonly int _max1;
    private readonly int _min2;
    private readonly int _max2;

    public YearValidateAttribute(int min1, int max1, int min2, int max2)
    {
        _min1 = min1;
        _max1 = max1;
        _min2 = min2;
        _max2 = max2;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null && value is int intValue)
        {
            if (!((intValue >= _min1 && intValue <= _max1) || (intValue >= _min2 && intValue <= _max2)))
            {
                return new ValidationResult("Enter Valid Model!");
            }
        }

        return ValidationResult.Success;
    }
}
