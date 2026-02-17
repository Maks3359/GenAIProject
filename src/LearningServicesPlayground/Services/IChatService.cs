namespace LearningServicesPlayground.Services;

public interface IChatService
{
    string Name { get; }
    string Description { get; }
    Task<string> RunAsync(string message, CancellationToken cancellationToken);
}
