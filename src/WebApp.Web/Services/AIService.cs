using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Web.Services
{
    public class AIService : IAIService
    {
        public async Task<AIResponse> SendPromptAsync(string prompt)
        {
            // TODO: 실제 AI Provider 연동 전 더미 응답
            await Task.Delay(500);
            return new AIResponse
            {
                Text = $"AI 응답: {prompt}",
                ImageUrls = new List<string>(),
                IsError = false
            };
        }

        public async Task<List<string>> GetMcpToolsAsync()
        {
            // TODO: 실제 MCP 연동 전 더미 툴 목록
            await Task.Delay(200);
            return new List<string> { "ToolA", "ToolB", "ToolC" };
        }
    }
}
