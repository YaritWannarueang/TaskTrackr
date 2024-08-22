using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using TaskTrackr.Application.UseCases;

namespace TaskTrack.Presentation.Commands
{
    public class ListCommand : Command
    {
        public ListCommand(IServiceProvider serviceProvider) : base("list", "List all todo items")
        {
            this.SetHandler(async () =>
            {
                using var scope = serviceProvider.CreateScope();
                var useCase = scope.ServiceProvider.GetRequiredService<ListTodosUseCase>();
                var todos = await useCase.ExecuteAsync();
                foreach (var todo in todos)
                {
                    Console.WriteLine($"{todo.Id}: {todo.Title} (Completed: {todo.IsCompleted})");
                }
            });
        }
    }
}
