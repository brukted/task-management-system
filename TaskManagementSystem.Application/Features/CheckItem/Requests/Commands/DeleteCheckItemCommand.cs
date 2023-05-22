using MediatR;

namespace TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;

public class DeleteCheckItemCommand : IRequest<Unit>
{
    public int CheckItemId { get; set; }
}