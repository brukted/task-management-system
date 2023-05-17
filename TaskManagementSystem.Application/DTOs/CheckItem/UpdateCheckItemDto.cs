using TaskManagementSystem.Application.DTOs.Common;

namespace TaskManagementSystem.Application.DTOs.CheckItem;

public class UpdateCheckItemDto : BaseDto, ICheckItemDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
}