using System.ComponentModel.DataAnnotations;

namespace StudentClassManager.WebUI.Attributes;

public class YearValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is int year && year >= DateTime.Now.Year)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("O campo Ano deve ser maior ou igual ao ano atual.");
    }
}

