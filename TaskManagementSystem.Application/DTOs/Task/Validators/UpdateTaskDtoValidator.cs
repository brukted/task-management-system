using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;

namespace TaskManagementSystem.Application.DTOs.Task.Validators;

public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
{
    public UpdateTaskDtoValidator(ITaskRepository taskRepository)
    {
        RuleFor(p => p.Id).MustAsync(async (id, _) => await taskRepository.Exists(id))
            .WithMessage("Task with this id does not exist");

        Include(new ITaskDtoValidator());
    }
}