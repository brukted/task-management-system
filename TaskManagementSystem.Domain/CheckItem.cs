using TaskManagementSystem.Domain.Common;

namespace TaskManagementSystem.Domain;

public class CheckItem : BaseDomainEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public CheckItemStatus Status { get; set; }
}