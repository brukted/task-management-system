using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.Task;
using TaskManagementSystem.Application.DTOs.Task.Validators;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.Requests.Commands;

namespace TaskManagementSystem.Application.Features.Task.Handlers.Commands;

public class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand, TaskDto>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public ChangeTaskStatusCommandHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<TaskDto> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var validationResult = new ChangeTaskStatusDtoValidator(_taskRepository).Validate(request.ChangeTaskStatusDto);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var task = _mapper.Map<Domain.Task>(request.ChangeTaskStatusDto);
        await _taskRepository.Update(task);

        return _mapper.Map<TaskDto>(task);
    }
}