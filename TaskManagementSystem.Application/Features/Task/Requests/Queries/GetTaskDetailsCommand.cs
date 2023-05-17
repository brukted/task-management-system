using MediatR;
using TaskManagementSystem.Application.DTOs.Task;

namespace TaskManagementSystem.Application.Features.Task.Requests.Queries;

public class GetTaskDetailsCommand : IRequest<TaskDto>
{
    public int Id { get; set; }
}