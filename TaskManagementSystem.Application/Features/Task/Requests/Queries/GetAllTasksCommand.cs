using MediatR;
using TaskManagementSystem.Application.DTOs.Task;

namespace TaskManagementSystem.Application.Features.Task.Requests.Queries;

public class GetAllTasksCommand : IRequest<List<TaskDto>>
{
}