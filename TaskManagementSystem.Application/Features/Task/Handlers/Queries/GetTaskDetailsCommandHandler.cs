using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.Task;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.Requests.Queries;

namespace TaskManagementSystem.Application.Features.Task.Handlers.Queries;

public class GetTaskDetailsCommandHandler : IRequestHandler<GetTaskDetailsCommand, TaskDto>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public GetTaskDetailsCommandHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<TaskDto> Handle(GetTaskDetailsCommand request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.Get(request.Id);

        if (task == null)
        {
            // Handle the case where the task with the specified ID doesn't exist
            throw new NotFoundException(nameof(Domain.Task), request.Id);
        }

        return _mapper.Map<TaskDto>(task);
    }
}