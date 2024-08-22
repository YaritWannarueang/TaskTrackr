using TaskTrackr.Application.Interfaces;
using TaskTrackr.Domain.Entities;

namespace TaskTrackr.Application.UseCases
{
    public class ListTodosUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ListTodosUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TodoItem>> ExecuteAsync()
        {
            return await _unitOfWork.TodoItems.GetAllAsync();
        }
    }
}
