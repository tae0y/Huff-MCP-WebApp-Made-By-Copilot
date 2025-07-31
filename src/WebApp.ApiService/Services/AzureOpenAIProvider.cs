using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

namespace WebApp.ApiService.Services
{
    public class AzureOpenAIProvider : IAIProvider
    {
        private readonly string _apiKey;
        private readonly string _endpoint;
        private readonly string _deploymentName;

        public string Name => "AzureOpenAI";

        public AzureOpenAIProvider(string apiKey, string endpoint, string deploymentName)
        {
            _apiKey = apiKey;
            _endpoint = endpoint;
            _deploymentName = deploymentName;
        }

        public async Task<string> GetTextCompletionAsync(string prompt)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", _apiKey);
            var url = $"{_endpoint}/openai/deployments/{_deploymentName}/chat/completions?api-version=2024-02-15-preview";
            var body = new
            {
                messages = new[] { new { role = "user", content = prompt } },
                max_tokens = 512
            };
            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(result);
                var text = doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                return text ?? "";
            }
            catch (Exception ex)
            {
                return $"[AzureOpenAI 오류] {ex.Message}";
            }
        }

        public Task<byte[]> GetImageAsync(string prompt)
        {
            return Task.FromResult(Array.Empty<byte>());
        }

        public Task<IAsyncEnumerable<string>> GetStreamingCompletionAsync(string prompt)
        {
            async IAsyncEnumerable<string> Stream()
            {
                yield return await GetTextCompletionAsync(prompt);
            }
            return Task.FromResult(Stream());
        }
    }
}
