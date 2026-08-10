namespace AgenticCompanyAssistant.Application.Chat;

public interface ICompanyAssistant
{
    Task<string> AskAsync(string message, string role, CancellationToken cancellationToken = default);
}
