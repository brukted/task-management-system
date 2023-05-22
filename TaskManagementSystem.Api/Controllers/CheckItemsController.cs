using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.DTOs.CheckItem;
using TaskManagementSystem.Application.Features.CheckItem.Requests.Commands;
using TaskManagementSystem.Application.Features.CheckItem.Requests.Queries;

namespace TaskManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CheckItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{taskId}")]
    public async Task<ActionResult<List<CheckItemDto>>> GetCheckItemsForTask(int taskId)
    {
        var request = new GetTaskCheckItemsRequest { TaskId = taskId };
        var checkItems = await _mediator.Send(request);
        return Ok(checkItems);
    }

    [HttpGet]
    public async Task<ActionResult<List<CheckItemDto>>> GetAllCheckItems()
    {
        var request = new GetAllCheckItemsRequest();
        var checkItems = await _mediator.Send(request);
        return Ok(checkItems);
    }

    [HttpPost]
    public async Task<ActionResult<CheckItemDto>> CreateCheckItem([FromBody] CreateCheckItemDto createCheckItemDto)
    {
        var command = new CreateCheckItemCommand { CreateCheckItemDto = createCheckItemDto };
        var checkItem = await _mediator.Send(command);
        return CreatedAtAction("CreateCheckItem", new { id = checkItem.Id }, checkItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CheckItemDto>> UpdateCheckItem(int id,
        [FromBody] UpdateCheckItemDto updateCheckItemDto)
    {
        updateCheckItemDto.Id = id;
        var command = new UpdateCheckItemCommand { UpdateCheckItemDto = updateCheckItemDto };
        var checkItem = await _mediator.Send(command);
        return Ok(checkItem);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCheckItem(int id)
    {
        var command = new DeleteCheckItemCommand { CheckItemId = id };
        await _mediator.Send(command);
        return NoContent();
    }
}