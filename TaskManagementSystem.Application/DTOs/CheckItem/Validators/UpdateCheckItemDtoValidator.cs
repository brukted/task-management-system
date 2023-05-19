using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;

namespace TaskManagementSystem.Application.DTOs.CheckItem.Validators;

public class UpdateCheckItemDtoValidator : AbstractValidator<UpdateCheckItemDto>
{
    public UpdateCheckItemDtoValidator(ICheckItemRepository checkItemRepository)
    {
        Include(new ICheckItemDtoValidator());
        Include(new CheckItemExistenceValidator(checkItemRepository));
    }
}