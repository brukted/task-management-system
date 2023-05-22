using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.CheckItem.Validators;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;

namespace TaskManagementSystem.Application.Features.CheckItem.Handlers.Commands;

public class UpdateCheckItemCommandHandler : IRequestHandler<UpdateCheckItemCommand, Unit>
{
    private readonly ICheckItemRepository _checkItemRepository;
    private readonly IMapper _mapper;

    public UpdateCheckItemCommandHandler(ICheckItemRepository checkItemRepository, IMapper mapper)
    {
        _checkItemRepository = checkItemRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateCheckItemCommand request, CancellationToken cancellationToken)
    {
        var validationResult =
            await new UpdateCheckItemDtoValidator(_checkItemRepository).ValidateAsync(request.UpdateCheckItemDto,
                cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var existingCheckItem = await _checkItemRepository.Get(request.UpdateCheckItemDto.Id);
        var updatedCheckItem = _mapper.Map<Domain.CheckItem>(request.UpdateCheckItemDto);

        existingCheckItem!.Title = updatedCheckItem.Title;
        existingCheckItem.Description = updatedCheckItem.Description;
        existingCheckItem.Status = updatedCheckItem.Status;

        await _checkItemRepository.Update(existingCheckItem);

        return Unit.Value;
    }
}