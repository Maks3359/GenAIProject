namespace LearningServicesPlayground.Services;

public sealed class WordCountService : IChatService
{
    public string Name => "word_count";
    public string Description => "Counts words in your message.";

    public Task<string> RunAsync(string message, CancellationToken cancellationToken)
    {
        var count = message.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Length;
        return Task.FromResult($"Word count: {count}");
    }
}
