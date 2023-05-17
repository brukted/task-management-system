using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.DTOs.CheckItem;

public interface ICheckItemDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public CheckItemStatus Status { get; set; }
}