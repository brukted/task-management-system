using TaskStatus = TaskManagementSystem.Domain.TaskStatus;

namespace TaskManagementSystem.Application.DTOs.Task;

public interface ITaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TaskStatus Status { get; set; }
}