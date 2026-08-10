using AgenticCompanyAssistant.Application.Chat;
using AgenticCompanyAssistant.Infrastructure.Chat;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICompanyAssistant, DemoCompanyAssistant>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapPost("/api/chat", async (ChatRequest request, ICompanyAssistant assistant, CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(request.Message))
    {
        return Results.BadRequest(new { error = "Message is required." });
    }

    var answer = await assistant.AskAsync(request.Message, request.Role ?? "Customer", cancellationToken);
    return Results.Ok(new ChatResponse(answer));
});

app.Run();

public sealed record ChatRequest(string Message, string? Role);
public sealed record ChatResponse(string Answer);
