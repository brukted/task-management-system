using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.DTOs.CheckItem.Validators;

public class ChangeCheckItemStatusDtoValidator : AbstractValidator<ChangeCheckItemStatusDto>
{
    public ChangeCheckItemStatusDtoValidator(ICheckItemRepository itemRepository)
    {
        Include(new CheckItemExistenceValidator(itemRepository));
        RuleFor(dto => dto.Status).NotEmpty().WithMessage(
            "Status must be one of the following: 0(InProgress), 1(Done)");
    }
}