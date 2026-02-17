using LearningServicesPlayground.Models;
using LearningServicesPlayground.Services;
using LearningServicesPlayground.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AzureFoundryOptions>(
    builder.Configuration.GetSection(AzureFoundryOptions.SectionName));

builder.Services.AddSingleton<IChatService, EchoService>();
builder.Services.AddSingleton<IChatService, ReverseService>();
builder.Services.AddSingleton<IChatService, WordCountService>();
builder.Services.AddSingleton<IChatService, AzureFoundryChatService>();
builder.Services.AddSingleton<ChatServiceRegistry>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/api/services", (ChatServiceRegistry registry) => Results.Ok(registry.GetDefinitions()));

app.MapPost("/api/chat", async (ChatRequest request, ChatServiceRegistry registry, CancellationToken ct) =>
{
    if (string.IsNullOrWhiteSpace(request.Message))
    {
        return Results.BadRequest(new { error = "Message is required." });
    }

    if (!registry.TryGetService(request.Service, out var service))
    {
        return Results.NotFound(new { error = $"Service '{request.Service}' not found." });
    }

    var output = await service.RunAsync(request.Message, ct);
    return Results.Ok(new { service = request.Service, output });
});

app.Run();
