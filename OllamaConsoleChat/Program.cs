namespace OllamaChat;

class Program
{
    private static async Task Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddOllamaChatServices(context.Configuration);
            })
            .Build();

        var ollamaOptions = host.Services.GetRequiredService<IOptions<OllamaOptions>>().Value;
        var chatService = host.Services.GetRequiredService<IChatService>();

        Console.WriteLine($"⚡️  Connected to Ollama – model: {ollamaOptions.ModelName}");
        Console.WriteLine("Type your question (empty line to exit).");

        while (true)
        {
            Console.Write("Q: ");
            var question = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(question))
            {
                break;
            }

            var answer = await chatService.SendMessageAsync(question);
            Console.WriteLine($"A: {answer}");
        }
    }
}
