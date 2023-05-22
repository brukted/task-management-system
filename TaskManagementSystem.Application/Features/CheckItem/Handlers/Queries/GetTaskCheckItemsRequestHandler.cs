using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Application.DTOs.CheckItem;
using TaskManagementSystem.Application.Exceptions;
using TaskManagementSystem.Application.Features.CheckItem.Requests.Queries;

namespace TaskManagementSystem.Application.Features.CheckItem.Handlers.Queries;

public class GetTaskCheckItemsRequestHandler : IRequestHandler<GetTaskCheckItemsRequest, List<CheckItemDto>>
{
    private readonly ICheckItemRepository _checkItemRepository;
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;


    public GetTaskCheckItemsRequestHandler(ICheckItemRepository checkItemRepository, ITaskRepository taskRepository,
        IMapper mapper)
    {
        _checkItemRepository = checkItemRepository;
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<List<CheckItemDto>> Handle(GetTaskCheckItemsRequest request, CancellationToken cancellationToken)
    {
        var task = await _taskRepository.Get(request.TaskId);

        if (task == null)
        {
            // Handle the case where the task with the specified ID doesn't exist
            throw new NotFoundException(nameof(Task), request.TaskId);
        }

        // Perform any other necessary logic to retrieve the check items for the task
        // For example:
        var checkItems = await _checkItemRepository.GetCheckItemsForTask(request.TaskId);
        return checkItems.ConvertAll(checkItem => _mapper.Map<CheckItemDto>(checkItem));
    }
}