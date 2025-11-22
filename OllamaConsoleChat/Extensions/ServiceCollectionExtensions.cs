namespace OllamaChat.Extensions;

/// <summary>
/// Registers everything needed for the Ollama chat app in one place.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOllamaChatServices(this IServiceCollection services,
                                                          IConfiguration configuration)
    {
        services.Configure<OllamaOptions>(configuration.GetSection("Ollama"));

        services.AddSingleton(sp => sp.GetRequiredService<IOptions<OllamaOptions>>().Value);

        services.AddSingleton<IChatService, ChatService>();

        return services;
    }
}