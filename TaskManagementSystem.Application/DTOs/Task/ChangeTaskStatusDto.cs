using TaskManagementSystem.Application.DTOs.Common;
using TaskStatus = TaskManagementSystem.Domain.TaskStatus;

namespace TaskManagementSystem.Application.DTOs.Task;

public class ChangeTaskStatusDto : BaseDto
{
    public TaskStatus Status { get; set; }
}