using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.Task;
using TaskManagementSystem.Application.DTOs.Task.Validators;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.Requests.Commands;

namespace TaskManagementSystem.Application.Features.Task.Handlers.Commands;

public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public UpdateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var validationResult =
            await new UpdateTaskDtoValidator(_taskRepository).ValidateAsync(request.UpdateTaskDto, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var existingTask = await _taskRepository.Get(request.UpdateTaskDto.Id);

        if (existingTask == null)
        {
            // Handle the case where the task with the specified ID doesn't exist
            throw new NotFoundException(nameof(Domain.Task), request.UpdateTaskDto.Id);
        }

        var updatedTask = _mapper.Map<Domain.Task>(request.UpdateTaskDto);
        updatedTask.Id = existingTask.Id; // Preserve the existing task ID

        await _taskRepository.Update(updatedTask);

        return _mapper.Map<TaskDto>(updatedTask);
    }
}