using TaskManagementSystem.Application.Contracts.Persistence;
using Task = TaskManagementSystem.Domain.Task;

namespace TaskManagementSystem.Persistence.Repositories;

public class TaskRepository : GenericRepository<Task>, ITaskRepository
{
    public TaskRepository(TaskManagementDbContext dbContext) : base(dbContext)
    {
    }
}