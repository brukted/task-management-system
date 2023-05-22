using AutoMapper;
using MediatR;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.CheckItem;
using TaskManagementSystem.Application.Features.CheckItem.Requests.Queries;

namespace TaskManagementSystem.Application.Features.CheckItem.Handlers.Queries;

public class GetAllCheckItemsRequestHandler : IRequestHandler<GetAllCheckItemsRequest, List<CheckItemDto>>
{
    private readonly ICheckItemRepository _checkItemRepository;
    private readonly IMapper _mapper;

    public GetAllCheckItemsRequestHandler(ICheckItemRepository checkItemRepository, IMapper mapper)
    {
        _checkItemRepository = checkItemRepository;
        _mapper = mapper;
    }

    public async Task<List<CheckItemDto>> Handle(GetAllCheckItemsRequest request, CancellationToken cancellationToken)
    {
        var checkItems = await _checkItemRepository.GetAll();

        var checkItemDtos = _mapper.Map<List<CheckItemDto>>(checkItems);

        return checkItemDtos;
    }
}