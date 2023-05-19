using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.Common;

namespace TaskManagementSystem.Application.DTOs.CheckItem.Validators;

public class CheckItemExistenceValidator : AbstractValidator<BaseDto>
{
    public CheckItemExistenceValidator(ICheckItemRepository itemRepository)
    {
        RuleFor(p => p.Id)
            .MustAsync(async (id, _) => await itemRepository.Exists(id))
            .WithMessage("Check item with this id does not exist");
    }
}