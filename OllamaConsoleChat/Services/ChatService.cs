namespace OllamaChat.Services;

public class ChatService : IChatService
{
    private readonly Kernel _kernel;

    public ChatService(IOptions<OllamaOptions> options)
    {
        var ollamaOptions = options.Value;
        _kernel = Kernel.CreateBuilder().AddOllamaChatCompletion(ollamaOptions.ModelName, new Uri(ollamaOptions.Endpoint)).Build();
    }

    public async Task<FunctionResult> SendMessageAsync(string question)
    {
        return await _kernel.InvokePromptAsync(question);
    }
}