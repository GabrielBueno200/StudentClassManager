
using FluentValidation.Results;
using StudentClassManager.Application.Exceptions;

namespace StudentClassManager.Application.Extensions;

public static class ValidationResultErrorsExtension
{
    public static bool VerifyErrorsAndThrow(this ValidationResult result)
    {
        if (!result.IsValid)
        {
            var errorMessage = string.Join(", ", result.Errors.Select(error => error.ErrorMessage));
            throw new BadRequestException(errorMessage);
        }

        return true;
    }
}