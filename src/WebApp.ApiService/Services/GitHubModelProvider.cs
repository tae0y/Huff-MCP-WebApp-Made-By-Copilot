using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace WebApp.ApiService.Services
{
    public class GitHubModelProvider : IAIProvider
    {
        public string Name => "GitHubModel";
        public Task<string> GetTextCompletionAsync(string prompt) => Task.FromResult($"[GitHubModel] 응답: {prompt}");
        public Task<byte[]> GetImageAsync(string prompt) => Task.FromResult(new byte[0]);
        public Task<IAsyncEnumerable<string>> GetStreamingCompletionAsync(string prompt) => Task.FromResult(GetStream(prompt));
        private async IAsyncEnumerable<string> GetStream(string prompt)
        {
            yield return $"[GitHubModel] 스트리밍 응답: {prompt}";
            await Task.CompletedTask;
        }
    }
}
