namespace LearningServicesPlayground.Services;

public sealed class ReverseService : IChatService
{
    public string Name => "reverse";
    public string Description => "Reverses your message text.";

    public Task<string> RunAsync(string message, CancellationToken cancellationToken)
    {
        var chars = message.ToCharArray();
        Array.Reverse(chars);
        return Task.FromResult(new string(chars));
    }
}
