using System.Threading.Tasks;

namespace WebApp.ApiService.Services
{
    public interface IConfigurationService
    {
        Task<string?> GetSettingAsync(string key);
        Task SetSettingAsync(string key, string value);
        Task<bool> RemoveSettingAsync(string key);
        Task<IDictionary<string, string>> GetAllSettingsAsync();
    }
}
