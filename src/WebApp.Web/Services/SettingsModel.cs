using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Services
{
    public class SettingsModel
    {
        [Required]
        public string? HuggingFaceToken { get; set; }
        public string ModelName { get; set; } = "gpt-4.1-mini";
        public string? GitHubModelToken { get; set; }
        public string? AzureOpenAIEndpoint { get; set; }
        public string? AzureOpenAIApiKey { get; set; }
        public string McpServerEndpoint { get; set; } = "https://huggingface.co/mcp";
    }
}
