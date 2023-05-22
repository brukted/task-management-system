using MediatR;
using TaskManagementSystem.Application.DTOs.CheckItem;

namespace TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;

public class ChangeCheckItemStatusCommand : IRequest<CheckItemDto>
{
    public ChangeCheckItemStatusDto ChangeCheckItemStatusDto { get; set; } = null!;
}