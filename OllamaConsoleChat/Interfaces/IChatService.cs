namespace OllamaChat.Interfaces;

public interface IChatService
{
    Task<FunctionResult> SendMessageAsync(string question);
}