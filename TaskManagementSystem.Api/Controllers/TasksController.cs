namespace TaskManagementSystem.Api.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Application.DTOs.Task;
using TaskManagementSystem.Application.Features.Task.Requests.Commands;
using TaskManagementSystem.Application.Features.Task.Requests.Queries;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskDto>>> GetAllTasks()
    {
        var request = new GetAllTasksCommand();
        var tasks = await _mediator.Send(request);
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDto>> GetTaskById(int id)
    {
        var request = new GetTaskDetailsCommand { Id = id };
        var task = await _mediator.Send(request);
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskDto createTaskDto)
    {
        var command = new CreateTaskCommand { CreateTaskDto = createTaskDto };
        var task = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TaskDto>> UpdateTask(int id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        updateTaskDto.Id = id;
        var command = new UpdateTaskCommand { UpdateTaskDto = updateTaskDto };
        var task = await _mediator.Send(command);
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        var command = new DeleteTaskCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}