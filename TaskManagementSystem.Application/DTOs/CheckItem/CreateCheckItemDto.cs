using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.DTOs.CheckItem;

public class CreateCheckItemDto : ICheckItemDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public CheckItemStatus Status { get; set; }
    public int TaskId { get; set; }
}