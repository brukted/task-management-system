using TaskManagementSystem.Application.DTOs.Common;
using TaskStatus = TaskManagementSystem.Domain.TaskStatus;

namespace TaskManagementSystem.Application.DTOs.Task;

public class UpdateTaskDto : BaseDto, ITaskDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TaskStatus Status { get; set; }
}