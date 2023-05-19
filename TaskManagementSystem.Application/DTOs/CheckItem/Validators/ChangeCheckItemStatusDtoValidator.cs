using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.DTOs.CheckItem.Validators;

public class ChangeCheckItemStatusDtoValidator : AbstractValidator<ChangeCheckItemStatusDto>
{
    public ChangeCheckItemStatusDtoValidator(ICheckItemRepository itemRepository)
    {
        Include(new CheckItemExistenceValidator(itemRepository));
        RuleFor(dto => dto.Status)
            .NotEmpty().NotNull().WithMessage("Status is required.")
            .IsInEnum().WithMessage(
                "Status must be one of the following: " +
                $"{string.Join(", ", Enum.GetNames(typeof(CheckItemStatus)))}");
    }
}