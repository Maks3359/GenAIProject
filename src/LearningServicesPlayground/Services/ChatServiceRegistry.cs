using LearningServicesPlayground.Models;

namespace LearningServicesPlayground.Services;

public sealed class ChatServiceRegistry
{
    private readonly Dictionary<string, IChatService> _services;

    public ChatServiceRegistry(IEnumerable<IChatService> services)
    {
        _services = services.ToDictionary(s => s.Name, StringComparer.OrdinalIgnoreCase);
    }

    public IReadOnlyCollection<ServiceDefinition> GetDefinitions()
        => _services.Values
            .Select(s => new ServiceDefinition(s.Name, s.Description))
            .OrderBy(s => s.Name)
            .ToArray();

    public bool TryGetService(string name, out IChatService service)
        => _services.TryGetValue(name, out service!);
}
