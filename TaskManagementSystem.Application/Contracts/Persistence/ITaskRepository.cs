using Task = TaskManagementSystem.Domain.Task;

namespace TaskManagementSystem.Application.Contracts.Persistence;

public interface ITaskRepository : IGenericRepository<Task>
{
}