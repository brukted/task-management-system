using TaskManagementSystem.Application.DTOs.Common;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.DTOs.CheckItem;

public class UpdateCheckItemDto : BaseDto, ICheckItemDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public CheckItemStatus Status { get; set; }
}