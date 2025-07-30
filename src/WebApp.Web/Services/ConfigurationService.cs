using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using WebApp.Web.Models;

namespace WebApp.Web.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IDataProtector _protector;
        private readonly string _settingsPath;

        public ConfigurationService(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("SettingsProtection");
            _settingsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "settings.json");
        }

        public async Task SaveSettingsAsync(SettingsModel model)
        {
            var protectedModel = new SettingsModel
            {
                Provider = model.Provider,
                ApiKey = _protector.Protect(model.ApiKey),
                Endpoint = model.Endpoint
            };
            var json = JsonSerializer.Serialize(protectedModel);
            await File.WriteAllTextAsync(_settingsPath, json);
        }

        public async Task<SettingsModel?> LoadSettingsAsync()
        {
            if (!File.Exists(_settingsPath)) return null;
            var json = await File.ReadAllTextAsync(_settingsPath);
            var protectedModel = JsonSerializer.Deserialize<SettingsModel>(json);
            if (protectedModel == null) return null;
            protectedModel.ApiKey = _protector.Unprotect(protectedModel.ApiKey);
            return protectedModel;
        }
    }
}
