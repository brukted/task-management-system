using MediatR;
using TaskManagementSystem.Application.DTOs.CheckItem;

namespace TaskManagementSystem.Application.Features.CheckItem.Requests.Queries;

public class GetTaskCheckItemsRequest : IRequest<List<CheckItemDto>>
{
    public int TaskId { get; set; }
}