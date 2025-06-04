using System;
using FluentValidation;

namespace DevLife.Application.Modules.Auth.Services;

public static class ValidationService
{
    public static async Task Validate<T>(IValidator<T> validator, T dto)
    {
        var _validator = await validator.ValidateAsync(dto);

        if (!_validator.IsValid)
        {
            throw new ValidationException("Validation failed: " + string.Join(", ", _validator.Errors.Select(e => e.ErrorMessage)));
        }
    }
}