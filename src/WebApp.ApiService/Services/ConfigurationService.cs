using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.ApiService.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ConcurrentDictionary<string, string> _settings = new();

        // 예시: Provider별 필수 설정 키
        private static readonly Dictionary<string, string[]> RequiredKeys = new()
        {
            ["AzureOpenAI"] = new[] { "AzureOpenAI:ApiKey", "AzureOpenAI:Endpoint" },
            ["HuggingFace"] = new[] { "HuggingFace:Token" }
        };

        public Task<string?> GetSettingAsync(string key)
        {
            _settings.TryGetValue(key, out var value);
            return Task.FromResult(value);
        }

        public Task SetSettingAsync(string key, string value)
        {
            _settings[key] = value;
            return Task.CompletedTask;
        }

        public Task<bool> RemoveSettingAsync(string key)
        {
            return Task.FromResult(_settings.TryRemove(key, out _));
        }

        public Task<IDictionary<string, string>> GetAllSettingsAsync()
        {
            return Task.FromResult((IDictionary<string, string>)_settings);
        }

        // Provider별 필수 설정값이 모두 존재하는지 검증
        public bool IsProviderConfigured(string providerName)
        {
            if (!RequiredKeys.TryGetValue(providerName, out var keys)) return false;
            return keys.All(k => _settings.ContainsKey(k) && !string.IsNullOrWhiteSpace(_settings[k]));
        }
    }
}
