using TaskTrackr.Application.Interfaces;
using TaskTrackr.Domain.Entities;

namespace TaskTrackr.Application.UseCases
{
    public class AddTodoUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddTodoUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(string title)
        {
            var todo = new TodoItem { Title = title, IsCompleted = false };
            await _unitOfWork.TodoItems.AddAsync(todo);
            await _unitOfWork.CompleteAsync();
        }
    }
}
