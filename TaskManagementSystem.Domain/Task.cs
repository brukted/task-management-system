using TaskManagementSystem.Domain.Common;

namespace TaskManagementSystem.Domain;

public class Task : BaseDomainEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = null!;
}