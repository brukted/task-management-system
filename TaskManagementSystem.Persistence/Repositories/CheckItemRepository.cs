using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.Contracts.Persistence;
using TaskManagementSystem.Domain;

namespace TaskManagementSystem.Persistence.Repositories;

public class CheckItemRepository : GenericRepository<CheckItem>, ICheckItemRepository
{
    private readonly TaskManagementDbContext _dbContext;

    public CheckItemRepository(TaskManagementDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<CheckItem>> GetCheckItemsForTask(int requestTaskId)
    {
        return _dbContext.CheckItems.Where(x => x.TaskId == requestTaskId).ToListAsync();
    }
}