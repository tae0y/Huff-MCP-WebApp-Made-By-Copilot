using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace WebApp.ApiService.Services
{
    public class AIService : IAIService
    {
        private readonly IDictionary<string, IAIProvider> _providers;
        private readonly string _defaultProvider;

        public AIService(IEnumerable<IAIProvider> providers, string defaultProvider = "AzureOpenAI")
        {
            _providers = providers.ToDictionary(p => p.Name);
            _defaultProvider = defaultProvider;
        }

        public IEnumerable<string> GetAvailableProviders() => _providers.Keys;

    public async Task<string> GetTextCompletionAsync(string prompt, string? provider = null)
        {
            var selected = provider ?? _defaultProvider;
            if (_providers.TryGetValue(selected, out var p))
                return await p.GetTextCompletionAsync(prompt);
            // 폴백: 첫 Provider 사용
            return await _providers.Values.First().GetTextCompletionAsync(prompt);
        }

    public async Task<byte[]> GetImageAsync(string prompt, string? provider = null)
        {
            var selected = provider ?? _defaultProvider;
            if (_providers.TryGetValue(selected, out var p))
                return await p.GetImageAsync(prompt);
            return await _providers.Values.First().GetImageAsync(prompt);
        }

    public async Task<IAsyncEnumerable<string>> GetStreamingCompletionAsync(string prompt, string? provider = null)
        {
            var selected = provider ?? _defaultProvider;
            if (_providers.TryGetValue(selected, out var p))
                return await p.GetStreamingCompletionAsync(prompt);
            return await _providers.Values.First().GetStreamingCompletionAsync(prompt);
        }
    }

    public interface IAIProvider
    {
        string Name { get; }
        Task<string> GetTextCompletionAsync(string prompt);
        Task<byte[]> GetImageAsync(string prompt);
        Task<IAsyncEnumerable<string>> GetStreamingCompletionAsync(string prompt);
    }
}
