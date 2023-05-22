using MediatR;
using TaskManagementSystem.Application.DTOs.Task;

namespace TaskManagementSystem.Application.Features.Task.Requests.Commands;

public class CreateTaskCommand : IRequest<TaskDto>
{
    public CreateTaskDto CreateTaskDto { get; init; } = null!;
}