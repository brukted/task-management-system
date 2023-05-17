using MediatR;

namespace TaskManagementSystem.Application.Features.Task.Requests.Commands;

public class DeleteTaskCommand : IRequest<Unit>
{
    public int Id { get; set; }
}