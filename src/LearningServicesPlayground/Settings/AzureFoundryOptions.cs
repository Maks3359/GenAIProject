namespace LearningServicesPlayground.Settings;

public sealed class AzureFoundryOptions
{
    public const string SectionName = "AzureFoundry";
    public string Endpoint { get; init; } = string.Empty;
    public string ApiKey { get; init; } = string.Empty;
    public string DeploymentName { get; init; } = string.Empty;
}
