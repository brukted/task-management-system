using TaskManagementSystem.Application.DTOs.Common;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.DTOs.CheckItem;

public class CheckItemDto : BaseDto, ICheckItemDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public CheckItemStatus Status { get; set; }
    public int TaskId { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}