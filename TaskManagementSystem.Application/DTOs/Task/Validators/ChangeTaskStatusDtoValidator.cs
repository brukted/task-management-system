using FluentValidation;
using TaskManagementSystem.Application.Contracts.Persistence;

namespace TaskManagementSystem.Application.DTOs.Task.Validators;

public class ChangeTaskStatusDtoValidator : AbstractValidator<ChangeTaskStatusDto>
{
    public ChangeTaskStatusDtoValidator(ITaskRepository taskRepository)
    {
        RuleFor(p => p.Id).MustAsync(async (id, _) => await taskRepository.Exists(id))
            .WithMessage("Task with this id does not exist");

        RuleFor(p => p.Status).NotEmpty().WithMessage(
            "Status must be one of the following: 0(InProgress), 1(Done)");
    }
}