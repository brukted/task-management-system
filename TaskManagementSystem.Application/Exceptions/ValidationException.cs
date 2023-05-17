using FluentValidation.Results;

namespace TaskManagementSystem.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public List<String> Errors { get; } = new();

    public ValidationException(ValidationResult result)
    {
        foreach (var error in result.Errors)
            Errors.Add(error.ErrorMessage);
    }
}