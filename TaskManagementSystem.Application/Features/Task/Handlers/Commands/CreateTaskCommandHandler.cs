using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.Task;
using TaskManagementSystem.Application.DTOs.Task.Validators;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.Task.Requests.Commands;

namespace TaskManagementSystem.Application.Features.Task.Handlers.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskDto>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var validationResult =
                await (new CreateTaskDtoValidator().ValidateAsync(request.CreateTaskDto, cancellationToken));
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult);

            var task = _mapper.Map<Domain.Task>(request.CreateTaskDto);
            var createdTask = await _taskRepository.Add(task);

            return _mapper.Map<TaskDto>(createdTask);
        }
    }
}