using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;
using TaskTrackr.Application.UseCases;

namespace TaskTrack.Presentation.Commands
{
    public class DeleteCommand : Command
    {
        public DeleteCommand(IServiceProvider serviceProvider) : base("delete", "Delete a todo item")
        {
            var idArgument = new Argument<int>("id", "The ID of the todo item");
            AddArgument(idArgument);

            this.SetHandler(async (int id) =>
            {
                using var scope = serviceProvider.CreateScope();
                var useCase = scope.ServiceProvider.GetRequiredService<DeleteTodoUseCase>();
                await useCase.ExecuteAsync(id);
                Console.WriteLine($"Deleted todo with ID: {id}");
            }, idArgument);
        }
    }
}
