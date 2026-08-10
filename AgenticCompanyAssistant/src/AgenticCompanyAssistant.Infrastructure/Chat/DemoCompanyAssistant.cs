using AgenticCompanyAssistant.Application.Chat;

namespace AgenticCompanyAssistant.Infrastructure.Chat;

public sealed class DemoCompanyAssistant : ICompanyAssistant
{
    public Task<string> AskAsync(string message, string role, CancellationToken cancellationToken = default)
    {
        var normalizedRole = string.IsNullOrWhiteSpace(role) ? "Customer" : role.Trim();
        var response = normalizedRole.ToLowerInvariant() switch
        {
            "admin" => $"Admin view: I received your question: {message}",
            "manager" => $"Manager view: I received your question: {message}",
            "employee" => $"Employee view: I received your question: {message}",
            _ => $"Customer view: I received your question: {message}"
        };

        return Task.FromResult(response);
    }
}
