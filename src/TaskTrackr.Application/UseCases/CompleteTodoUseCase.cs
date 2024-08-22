using TaskTrackr.Application.Interfaces;

namespace TaskTrackr.Application.UseCases
{
    public class CompleteTodoUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompleteTodoUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(int id)
        {
            var todo = await _unitOfWork.TodoItems.GetByIdAsync(id);

            if (todo == null)
            {
                todo.IsCompleted = true;
                await _unitOfWork.TodoItems.UpdateAsync(todo);
                await _unitOfWork.CompleteAsync();
            }
        }
    }
}
