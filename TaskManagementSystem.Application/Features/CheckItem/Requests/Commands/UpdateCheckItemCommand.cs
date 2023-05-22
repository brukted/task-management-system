using MediatR;
using TaskManagementSystem.Application.DTOs.CheckItem;

namespace TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;

public class UpdateCheckItemCommand : IRequest<Unit>
{
    public UpdateCheckItemDto UpdateCheckItemDto { get; set; } = null!;
}