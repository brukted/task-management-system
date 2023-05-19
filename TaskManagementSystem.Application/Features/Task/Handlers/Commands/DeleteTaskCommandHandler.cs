using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.Requests.Commands;

namespace TaskManagementSystem.Application.Features.Task.Handlers.Commands;

public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
{
    private readonly ITaskRepository _taskRepository;

    public DeleteTaskCommandHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.Get(request.Id);

        if (task == null)
        {
            // Handle the case where the task with the specified ID doesn't exist
            throw new NotFoundException(nameof(Domain.Task), request.Id);
        }

        await _taskRepository.Delete(task);

        return Unit.Value;
    }
}