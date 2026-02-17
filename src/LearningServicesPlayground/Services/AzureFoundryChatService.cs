using Azure;
using Azure.AI.Inference;
using LearningServicesPlayground.Settings;
using Microsoft.Extensions.Options;

namespace LearningServicesPlayground.Services;

public sealed class AzureFoundryChatService : IChatService
{
    private readonly ILogger<AzureFoundryChatService> _logger;
    private readonly AzureFoundryOptions _options;

    public AzureFoundryChatService(IOptions<AzureFoundryOptions> options, ILogger<AzureFoundryChatService> logger)
    {
        _logger = logger;
        _options = options.Value;
    }

    public string Name => "foundry";
    public string Description => "Uses your Azure AI Foundry model deployment to answer prompts.";

    public async Task<string> RunAsync(string message, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_options.Endpoint)
            || string.IsNullOrWhiteSpace(_options.ApiKey)
            || string.IsNullOrWhiteSpace(_options.DeploymentName))
        {
            return "Azure Foundry is not configured yet. Set AzureFoundry:Endpoint, AzureFoundry:ApiKey, and AzureFoundry:DeploymentName in appsettings.Development.json or environment variables.";
        }

        try
        {
            var client = new ChatCompletionsClient(new Uri(_options.Endpoint), new AzureKeyCredential(_options.ApiKey));

            var response = await client.CompleteAsync(
                new ChatCompletionsOptions
                {
                    Model = _options.DeploymentName,
                    Temperature = 0.3f,
                    MaxTokens = 500,
                    Messages =
                    {
                        new ChatRequestSystemMessage("You are a helpful learning assistant for .NET developers."),
                        new ChatRequestUserMessage(message)
                    }
                },
                cancellationToken);

            return response.Value.Content.FirstOrDefault()?.Text?.Trim()
                   ?? "No response was returned by the model.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Azure Foundry request failed.");
            return $"Azure Foundry call failed: {ex.Message}";
        }
    }
}
