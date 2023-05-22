using FluentValidation;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.DTOs.CheckItem.Validators;

public class ICheckItemDtoValidator : AbstractValidator<ICheckItemDto>
{
    public ICheckItemDtoValidator()
    {
        RuleFor(dto => dto.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(dto => dto.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(dto => dto.Status).NotEmpty().WithMessage(
            "Status must be one of the following: 0(InProgress), 1(Done)");
    }
}