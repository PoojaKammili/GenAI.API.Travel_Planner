using GenAI.API.Models;
using System.Net.Http.Json;

namespace GenAI.API.Services
{
    public class OllamaAIService : IAIService
    {
        private readonly HttpClient _httpClient;

        public OllamaAIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateAsync(string prompt)
        {
            var request = new
            {
                model = "llama3.2",
                prompt = prompt,
                stream = false
            };

            var response = await _httpClient.PostAsJsonAsync(
                "api/generate",
                request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadFromJsonAsync<OllamaResponse>();

            return result?.Response ?? string.Empty;
        }
    }
}
