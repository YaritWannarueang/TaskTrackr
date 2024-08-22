using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using TaskTrackr.Application.UseCases;

namespace TaskTrack.Presentation.Commands
{
    public class AddCommand : Command
    {
        public AddCommand(IServiceProvider serviceProvider) : base("add", "Add a new todo item")
        {
            var titleArgument = new Argument<string>("title", "The title of the todo item");
            AddArgument(titleArgument);

            this.SetHandler(async (string title) =>
            {
                using var scope = serviceProvider.CreateScope();
                var useCase = scope.ServiceProvider.GetRequiredService<AddTodoUseCase>();
                await useCase.ExecuteAsync(title);
                Console.WriteLine($"Added todo: {title}");
            }, titleArgument);
        }
    }
}
