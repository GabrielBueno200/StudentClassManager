using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StudentClassManager.WebUI.Attributes;
public class PasswordValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        string password = value as string;

        string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";

        if (password != null && Regex.IsMatch(password, pattern))
        {
            return true;
        }

        return false;
    }
}