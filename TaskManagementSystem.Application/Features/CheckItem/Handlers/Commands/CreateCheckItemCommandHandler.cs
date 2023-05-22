using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.CheckItem;
using TaskManagementSystem.Application.DTOs.CheckItem.Validators;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;

namespace TaskManagementSystem.Application.Features.CheckItem.Handlers.Commands;

public class CreateCheckItemCommandHandler : IRequestHandler<CreateCheckItemCommand, CheckItemDto>
{
    private readonly ICheckItemRepository _checkItemRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public CreateCheckItemCommandHandler(ICheckItemRepository checkItemRepository, ITaskRepository taskRepository,
        IMapper mapper)
    {
        _checkItemRepository = checkItemRepository;
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<CheckItemDto> Handle(CreateCheckItemCommand request, CancellationToken cancellationToken)
    {
        var validationResult =
            await new CreateCheckItemDtoValidator(_taskRepository).ValidateAsync(request.CreateCheckItemDto,
                cancellationToken);
        
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var checkItem = _mapper.Map<Domain.CheckItem>(request.CreateCheckItemDto);

        await _checkItemRepository.Add(checkItem);

        var createdCheckItemDto = _mapper.Map<CheckItemDto>(checkItem);

        return createdCheckItemDto;
    }
}