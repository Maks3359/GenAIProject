# .NET Learning Services Playground (with Azure AI Foundry)

Small C#/.NET project where you can add services one by one and test them in a simple chatbot-style UI.

## Stack

- ASP.NET Core Minimal API (.NET 8)
- Vanilla HTML/CSS/JS chat UI
- Azure AI Foundry chat model integration (`Azure.AI.Inference`)

## Project structure

- `src/LearningServicesPlayground/Program.cs` - API + app startup
- `src/LearningServicesPlayground/Services/` - service implementations
- `src/LearningServicesPlayground/wwwroot/` - chatbot UI

## Run

```bash
cd src/LearningServicesPlayground
dotnet restore
dotnet run
```

Open `http://localhost:5000` (or the URL printed in terminal).

## Configure Azure AI Foundry model

Set values in `appsettings.Development.json` or use environment variables:

```json
"AzureFoundry": {
  "Endpoint": "https://<your-resource>.services.ai.azure.com/models",
  "ApiKey": "<your-api-key>",
  "DeploymentName": "<your-model-deployment-name>"
}
```

When configured, choose service `foundry` in the UI to send prompts to your Azure AI Foundry deployment.

## Starter services included

- `echo`
- `reverse`
- `word_count`
- `foundry` (Azure AI Foundry model)

## Add a new service

1. Create a class in `Services/` implementing `IChatService`.
2. Register it in `Program.cs`:

```csharp
builder.Services.AddSingleton<IChatService, YourService>();
```

It will appear in the UI service dropdown automatically.
