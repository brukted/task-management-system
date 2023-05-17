using MediatR;
using TaskManagementSystem.Application.DTOs.Task;

namespace TaskManagementSystem.Application.Features.Task.Requests.Commands;

public class ChangeTaskStatusCommand : IRequest<TaskDto>
{
    public ChangeTaskStatusDto ChangeTaskStatusDto { get; set; } = null!;
}