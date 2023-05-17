namespace TaskManagementSystem.Application.DTOs.CheckItem;

public interface ICheckItemDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
}