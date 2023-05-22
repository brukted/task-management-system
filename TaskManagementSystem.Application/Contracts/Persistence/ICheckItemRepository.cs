using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Application.Contracts.Persistence;

public interface ICheckItemRepository : IGenericRepository<CheckItem>
{
    Task<List<CheckItem>> GetCheckItemsForTask(int requestTaskId);
}