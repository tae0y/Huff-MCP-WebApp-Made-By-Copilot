using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Web.Services
{
    public class AIResponse
    {
        public string? Text { get; set; }
        public List<string> ImageUrls { get; set; } = new();
        public bool IsError { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public interface IAIService
    {
        Task<AIResponse> SendPromptAsync(string prompt);
        Task<List<string>> GetMcpToolsAsync();
    }
}
