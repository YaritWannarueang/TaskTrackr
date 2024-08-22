using Microsoft.EntityFrameworkCore;
using TaskTrackr.Application.Interfaces;
using TaskTrackr.Domain.Entities;

namespace TaskTrackr.Infrastructure.Data
{
    internal class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _context;

        public TodoItemRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TodoItem item)
        {
            await _context.TodoItems.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
            }
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task UpdateAsync(TodoItem item)
        {
            _context.TodoItems.Update(item);
        }
    }
}
