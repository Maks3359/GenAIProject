# Agentic Company Assistant

A .NET 8 learning and portfolio solution for building a secure company-specific AI assistant that evolves from web chat into role-aware RAG, business tools, ordering workflows, and phone automation.

## Current scaffold

- ASP.NET Core web UI and `/api/chat` endpoint
- Application abstraction: `ICompanyAssistant`
- Infrastructure demo implementation
- Role selector: Customer, Employee, Manager, Admin
- Domain, Application, Infrastructure, Web, and Tests projects

## Run

```bash
cd AgenticCompanyAssistant/src/AgenticCompanyAssistant.Web
dotnet restore
dotnet run
```

Open the URL printed by ASP.NET Core.

## Architecture direction

```text
Web / Phone Channels
        |
Authentication + User Context
        |
Application / Agent Orchestration
        |
+----------------+----------------+----------------+
|                |                |                |
Knowledge/RAG    Product Tools    Order Tools      Customer Tools
|                                 |
Azure AI Search                  Business APIs / Database
        |
Microsoft Foundry / Agent Framework
```

## Learning roadmap

1. Establish the .NET 8 UI and application architecture.
2. Add `Microsoft.Extensions.AI` / `IChatClient` concepts.
3. Connect a Microsoft Foundry model.
4. Introduce Microsoft Agent Framework.
5. Add company-specific instructions and grounded answers.
6. Add document ingestion and Azure AI Search RAG.
7. Add citations in the UI.
8. Add Microsoft Entra authentication.
9. Implement role/group-aware security trimming.
10. Add product and inventory tools.
11. Add order creation with explicit user confirmation.
12. Add agent sessions and conversation state.
13. Add specialized agents and workflows.
14. Add MCP tools.
15. Add tracing, evaluation, and Application Insights.
16. Add Azure Communication Services / voice channel.
17. Reuse the same application/agent layer for phone ordering.
18. Add human transfer and production security controls.

## Security rule

Role authorization must be enforced in retrieval and business services, not merely by prompting the language model. The current role dropdown is only a learning scaffold and is **not authentication**.

## Next implementation

Replace `DemoCompanyAssistant` with the first real model-backed implementation while keeping `ICompanyAssistant` stable. Then introduce a small company knowledge dataset so we can compare unrestricted chat with role-filtered grounded responses.
