using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;

namespace TaskManagementSystem.Application.DTOs.CheckItem.Validators;

public class CreateCheckItemDtoValidator : AbstractValidator<CreateCheckItemDto>
{
    public CreateCheckItemDtoValidator(ITaskRepository taskRepository)
    {
        RuleFor(p => p.TaskId).MustAsync(async (id, _) => await taskRepository.Exists(id))
            .WithMessage("Task with this id does not exist");

        Include(new ICheckItemDtoValidator());
    }
}