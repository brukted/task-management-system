using MediatR;
using TaskManagementSystem.Application.DTOs.Task;

namespace TaskManagementSystem.Application.Features.Task.Requests.Commands;

public class UpdateTaskCommand : IRequest<TaskDto>
{
    public UpdateTaskDto UpdateTaskDto { get; set; } = null!;
}