using MediatR;
using TaskManagementSystem.Application.DTOs.CheckItem;

namespace TaskManagementSystem.Application.Features.CheckItem.Requests.Queries;

public class GetAllCheckItemsRequest : IRequest<List<CheckItemDto>>
{
    
}