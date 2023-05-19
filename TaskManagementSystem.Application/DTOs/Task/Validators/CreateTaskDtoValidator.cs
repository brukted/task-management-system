using FluentValidation;

namespace TaskManagementSystem.Application.DTOs.Task.Validators;

public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
{
    public CreateTaskDtoValidator()
    {
        Include(new ITaskDtoValidator());
    }
}