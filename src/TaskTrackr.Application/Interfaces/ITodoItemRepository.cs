using TaskTrackr.Domain.Entities;

namespace TaskTrackr.Application.Interfaces
{
    public interface ITodoItemRepository
    {
        Task AddAsync(TodoItem item);
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task UpdateAsync(TodoItem item);
        Task DeleteAsync(int id);
    }
}
