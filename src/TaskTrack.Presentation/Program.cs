using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.CommandLine;
using TaskTrack.Presentation.Commands;
using TaskTrackr.Application.Interfaces;
using TaskTrackr.Application.UseCases;
using TaskTrackr.Infrastructure.Data;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<TodoContext>(option => option.UseSqlite("Data Source=todo.db"));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<AddTodoUseCase>();
        services.AddScoped<ListTodosUseCase>();
        services.AddScoped<CompleteTodoUseCase>();
        services.AddScoped<DeleteTodoUseCase>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
        logging.SetMinimumLevel(LogLevel.Warning);
    })
    .Build();

using var scope = host.Services.CreateScope();
var serviceProvider = scope.ServiceProvider;

var rootCommand = new RootCommand
{
    new AddCommand(serviceProvider),
    new ListCommand(serviceProvider),
    new CompleteCommand(serviceProvider),
    new DeleteCommand(serviceProvider)
};

return await rootCommand.InvokeAsync(args);