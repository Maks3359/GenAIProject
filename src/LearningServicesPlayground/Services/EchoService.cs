namespace LearningServicesPlayground.Services;

public sealed class EchoService : IChatService
{
    public string Name => "echo";
    public string Description => "Returns the same message.";

    public Task<string> RunAsync(string message, CancellationToken cancellationToken)
        => Task.FromResult($"Echo: {message}");
}
