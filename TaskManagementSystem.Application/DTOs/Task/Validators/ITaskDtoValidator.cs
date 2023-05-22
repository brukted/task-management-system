using FluentValidation;

namespace TaskManagementSystem.Application.DTOs.Task.Validators;

public class ITaskDtoValidator : AbstractValidator<ITaskDto>
{
    public ITaskDtoValidator()
    {
        RuleFor(p => p.Title).NotNull().NotEmpty().WithMessage("Title is required.").MinimumLength(3).MaximumLength(50)
            .WithMessage("Title must be between 3 and 50 characters");

        RuleFor(p => p.Description).NotNull().NotEmpty().WithMessage("Description is required.").MinimumLength(3)
            .MaximumLength(255).WithMessage("Description must be between 3 and 255 characters");

        RuleFor(p => p.StartDate).NotNull().NotEmpty().WithMessage("StartDate is required.");

        RuleFor(p => p.EndDate).NotNull().NotEmpty().WithMessage("EndDate is required.")
            .GreaterThanOrEqualTo(p => p.StartDate)
            .WithMessage("EndDate must be greater than or equal to StartDate");

        RuleFor(p => p.Status).NotEmpty().WithMessage(
            "Status must be one of the following: 0(InProgress), 1(Done)");
    }
}