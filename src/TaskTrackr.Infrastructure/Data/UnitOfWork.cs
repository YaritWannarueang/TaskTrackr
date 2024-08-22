using TaskTrackr.Application.Interfaces;

namespace TaskTrackr.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoContext _context;
        private ITodoItemRepository _todoItemRepository;

        public UnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public ITodoItemRepository TodoItems => _todoItemRepository ??= new TodoItemRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
