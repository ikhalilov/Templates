**Project Name – OllamaChat Console**

| Component | Purpose | Key Files |
|-----------|---------|-----------|
| **Entry point** | Starts the host, configures services, and runs a simple console loop for chat. | `Program.cs` |
| **Dependency injection** | Registers configuration, options, and the chat service. | `ServiceCollectionExtensions.cs` |
| **Configuration** | Holds Ollama connection settings (model name, endpoint, etc.). | `OllamaOptions.cs` |
| **Chat service** | Implements `IChatService` to send messages to an Ollama model and return a `FunctionResult`. | `ChatService.cs` |
| **Interface** | Defines the contract for the chat service. | `IChatService.cs` |
| **Project files** | Build configuration, dependencies, and global usings. | OllamaChat.csproj, GlobalUsings.cs, appsettings.json, .env |

**How it works**

1. Program.cs builds a `Host` with default configuration.  
2. `AddOllamaChatServices` registers `OllamaOptions`, the singleton `OllamaOptions` instance, and the `ChatService`.  
3. The console loop reads user input, calls `SendMessageAsync` on the injected `IChatService`, and prints the response.  
4. `ChatService` (implementation not shown) uses the configured `OllamaOptions` to communicate with an Ollama model via the Semantic Kernel connector.

**Usage**

```bash
# Clone the repo
git clone <url>

# Restore dependencies
dotnet restore

# Run the console app
dotnet run
```

The application will prompt:

```
⚡️  Connected to Ollama – model: <model-name>
Type your question (empty line to exit).
Q: <your question>
A: <model response>
```

**Key Technologies**

- C# 10
- .NET Generic Host
- Microsoft.SemanticKernel.Connectors.Ollama
- Dependency Injection & Options pattern

This summary captures the core structure and flow of the OllamaChat console application.