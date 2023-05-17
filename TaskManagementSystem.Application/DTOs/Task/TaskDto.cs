using TaskManagementSystem.Application.DTOs.Common;
using TaskStatus = TaskManagementSystem.Domain.TaskStatus;

namespace TaskManagementSystem.Application.DTOs.Task;

public class TaskDto : BaseDto, ITaskDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TaskStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}