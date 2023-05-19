using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.Task;
using TaskManagementSystem.Application.Features.Task.Requests.Queries;

namespace TaskManagementSystem.Application.Features.Task.Handlers.Queries;

public class GetAllTasksCommandHandler : IRequestHandler<GetAllTasksCommand, List<TaskDto>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly Mapper _mapper;

    public GetAllTasksCommandHandler(ITaskRepository taskRepository, Mapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<List<TaskDto>> Handle(GetAllTasksCommand request, CancellationToken cancellationToken)
    {
        var tasks = await _taskRepository.GetAll();

        return _mapper.Map<List<TaskDto>>(tasks);
    }
}