using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebApp.ApiService.Services
{
    public interface IAIService
    {
    Task<string> GetTextCompletionAsync(string prompt, string? provider = null);
    Task<byte[]> GetImageAsync(string prompt, string? provider = null);
    Task<IAsyncEnumerable<string>> GetStreamingCompletionAsync(string prompt, string? provider = null);
        // Provider 목록 반환
        IEnumerable<string> GetAvailableProviders();
    }
}
