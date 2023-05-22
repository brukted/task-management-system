using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.CheckItem;
using TaskManagementSystem.Application.DTOs.CheckItem.Validators;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;

namespace TaskManagementSystem.Application.Features.CheckItem.Handlers.Commands;

public class ChangeCheckItemStatusCommandHandler : IRequestHandler<ChangeCheckItemStatusCommand, CheckItemDto>
{
    private readonly ICheckItemRepository _checkItemRepository;
    private readonly IMapper _mapper;

    public ChangeCheckItemStatusCommandHandler(ICheckItemRepository checkItemRepository, IMapper mapper)
    {
        _checkItemRepository = checkItemRepository;
        _mapper = mapper;
    }

    public async Task<CheckItemDto> Handle(ChangeCheckItemStatusCommand request,
        CancellationToken cancellationToken)
    {
        var validationResult = await new ChangeCheckItemStatusDtoValidator(_checkItemRepository).ValidateAsync(
            request.ChangeCheckItemStatusDto, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);

        var checkItem = await _checkItemRepository.Get(request.ChangeCheckItemStatusDto.Id);
        checkItem!.Status = request.ChangeCheckItemStatusDto.Status;

        await _checkItemRepository.Update(checkItem);

        return _mapper.Map<CheckItemDto>(checkItem);
    }
}