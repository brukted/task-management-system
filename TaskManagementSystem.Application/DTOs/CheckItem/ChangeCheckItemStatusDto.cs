using TaskManagementSystem.Application.DTOs.Common;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.DTOs.CheckItem;

public class ChangeCheckItemStatusDto : BaseDto
{
    public CheckItemStatus Status { get; set; }
}