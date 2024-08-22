namespace TaskTrackr.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoItemRepository TodoItems {  get; }
        Task<int> CompleteAsync();
    }
}
