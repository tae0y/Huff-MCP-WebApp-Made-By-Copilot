using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Net.ServerSentEvents;
using System.Text.Json;
using System.Net.Http;

namespace WebApp.Web.Services
{
    public class AIService : IAIService
    {
        private readonly IConfigurationService _configService;
        private SettingsModel? _settings;

        public AIService(IConfigurationService configService)
        {
            _configService = configService;
        }

        private async Task<ServerSentEventsClient> CreateSseClientAsync()
        {
            _settings ??= await _configService.LoadSettingsAsync();
            if (string.IsNullOrWhiteSpace(_settings.HuggingFaceToken))
                throw new InvalidOperationException("Hugging Face Token이 필요합니다.");
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_settings.HuggingFaceToken}");
            var endpoint = _settings.McpServerEndpoint ?? "https://huggingface.co/mcp";
            return new ServerSentEventsClient(new Uri(endpoint), httpClient);
        }

        public async Task<AIResponse> SendPromptAsync(string prompt)
        {
            try
            {
                var sseClient = await CreateSseClientAsync();
                var requestData = new { prompt = prompt, model = _settings?.ModelName };
                var content = new StringContent(JsonSerializer.Serialize(requestData), System.Text.Encoding.UTF8, "application/json");
                string resultText = "";
                await foreach (var evt in sseClient.GetEventsAsync(content))
                {
                    if (!string.IsNullOrWhiteSpace(evt.Data))
                        resultText += evt.Data;
                }
                return new AIResponse
                {
                    Text = resultText,
                    ImageUrls = ExtractImageUrls(resultText),
                    IsError = false
                };
            }
            catch (Exception ex)
            {
                return new AIResponse { IsError = true, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<string>> GetMcpToolsAsync()
        {
            // MCP 서버에서 툴 목록을 가져오는 API가 별도로 제공되는 경우에만 구현
            // 현재는 빈 목록 반환
            await Task.Delay(100);
            return new List<string>();
        }

        private List<string> ExtractImageUrls(string response)
        {
            var urls = new List<string>();
            // Markdown 이미지, http/https 이미지 URL 추출(간단 예시)
            var lines = response.Split('\n');
            foreach (var line in lines)
            {
                if (line.Contains("![](") && line.Contains(")"))
                {
                    var start = line.IndexOf("![](") + 4;
                    var end = line.IndexOf(")", start);
                    if (end > start)
                    {
                        var url = line.Substring(start, end - start);
                        urls.Add(url);
                    }
                }
                else if (line.StartsWith("http") && (line.EndsWith(".png") || line.EndsWith(".jpg") || line.EndsWith(".jpeg")))
                {
                    urls.Add(line.Trim());
                }
            }
            return urls;
        }
    }
}
