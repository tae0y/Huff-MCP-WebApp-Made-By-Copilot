using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ModelContextProtocol;
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

        private async Task<McpClient?> CreateMcpClientAsync()
        {
            _settings ??= await _configService.LoadSettingsAsync();
            if (string.IsNullOrWhiteSpace(_settings.HuggingFaceToken)) return null;
            var hfHeaders = new Dictionary<string, string>
            {
                { "Authorization", $"Bearer {_settings.HuggingFaceToken}" }
            };
            var clientTransport = new SseClientTransport(new()
            {
                Name = "HF Server",
                Endpoint = new Uri(_settings.McpServerEndpoint ?? "https://huggingface.co/mcp"),
                AdditionalHeaders = hfHeaders
            });
            return await McpClientFactory.CreateAsync(clientTransport);
        }

        public async Task<AIResponse> SendPromptAsync(string prompt)
        {
            try
            {
                await using var mcpClient = await CreateMcpClientAsync();
                if (mcpClient == null)
                {
                    return new AIResponse { IsError = true, ErrorMessage = "Hugging Face Token이 필요합니다." };
                }
                var tools = await mcpClient.ListToolsAsync();
                var chatOptions = new ChatOptions
                {
                    Tools = [.. tools],
                    ModelId = _settings?.ModelName ?? "gpt-4.1-mini"
                };
                var result = await mcpClient.GetResponseAsync(prompt, chatOptions);
                // 이미지 URL 추출(예시: markdown, http/https)
                var imageUrls = ExtractImageUrls(result);
                return new AIResponse
                {
                    Text = result,
                    ImageUrls = imageUrls,
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
            try
            {
                await using var mcpClient = await CreateMcpClientAsync();
                if (mcpClient == null) return new List<string>();
                var tools = await mcpClient.ListToolsAsync();
                var toolNames = new List<string>();
                foreach (var tool in tools)
                {
                    toolNames.Add(tool.Name);
                }
                return toolNames;
            }
            catch
            {
                return new List<string>();
            }
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
