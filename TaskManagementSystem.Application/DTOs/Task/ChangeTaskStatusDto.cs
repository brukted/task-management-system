using TaskManagementSystem.Application.DTOs.Common;

namespace TaskManagementSystem.Application.DTOs.Task;

public class ChangeTaskStatusDto : BaseDto
{
    public string Status { get; set; } = null!;
}