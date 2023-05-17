using TaskManagementSystem.Application.DTOs.Common;

namespace TaskManagementSystem.Application.DTOs.CheckItem;

public class ChangeCheckItemStatusDto : BaseDto
{
    public string Status { get; set; } = null!;
}