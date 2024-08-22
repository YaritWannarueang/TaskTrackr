using TaskTrackr.Application.Interfaces;

namespace TaskTrackr.Application.UseCases
{
    public class DeleteTodoUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTodoUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(int id)
        {
            await _unitOfWork.TodoItems.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
