using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;

namespace TaskManagementSystem.Application.Features.CheckItem.Handlers.Commands;

public class DeleteCheckItemCommandHandler : IRequestHandler<DeleteCheckItemCommand>
{
    private readonly ICheckItemRepository _checkItemRepository;

    public DeleteCheckItemCommandHandler(ICheckItemRepository checkItemRepository)
    {
        _checkItemRepository = checkItemRepository;
    }

    public async Task<Unit> Handle(DeleteCheckItemCommand request, CancellationToken cancellationToken)
    {
        var checkItem = await _checkItemRepository.Get(request.CheckItemId);

        if (checkItem == null)
        {
            // Handle the case where the check item with the specified ID doesn't exist
            throw new NotFoundException(nameof(CheckItem), request.CheckItemId);
        }

        await _checkItemRepository.Delete(checkItem);

        return Unit.Value;
    }
}