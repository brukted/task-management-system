using MediatR;
using TaskManagementSystem.Application.DTOs.CheckItem;

namespace TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;

public class CreateCheckItemCommand : IRequest<CheckItemDto>
{
    public CreateCheckItemDto CreateCheckItemDto { get; set; } = null!;
}