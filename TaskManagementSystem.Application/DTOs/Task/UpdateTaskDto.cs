namespace TaskManagementSystem.Application.DTOs.Task;

public class UpdateTaskDto : ITaskDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = null!;
}