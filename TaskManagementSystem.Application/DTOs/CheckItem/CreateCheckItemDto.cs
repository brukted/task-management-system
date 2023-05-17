namespace TaskManagementSystem.Application.DTOs.CheckItem;

public class CreateCheckItemDto : ICheckItemDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int TaskId { get; set; }
}