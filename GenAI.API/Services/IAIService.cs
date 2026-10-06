namespace GenAI.API.Services
{
    public interface IAIService
    {
        Task<string> GenerateAsync(string prompt);
    }
}
