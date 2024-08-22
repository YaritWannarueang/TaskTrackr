using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using TaskTrackr.Application.UseCases;


namespace TaskTrack.Presentation.Commands
{
    internal class CompleteCommand : Command
    {
        public CompleteCommand(IServiceProvider serviceProvider) : base("complete", "Mark a todo item as completed")
        {
            var idArgument = new Argument<int>("id", "The ID of the todo item");
            AddArgument(idArgument);

            this.SetHandler(async (int id) =>
            {
                using var scope = serviceProvider.CreateScope();
                var useCase = scope.ServiceProvider.GetRequiredService<CompleteTodoUseCase>();
                await useCase.ExecuteAsync(id);
                Console.WriteLine($"Completed todo with ID: {id}");
            }, idArgument);
        }
    }
}
