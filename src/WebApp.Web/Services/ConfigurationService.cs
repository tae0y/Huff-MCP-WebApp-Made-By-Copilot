using System.Threading.Tasks;

namespace WebApp.Web.Services
{
    public interface IConfigurationService
    {
        Task<SettingsModel> LoadSettingsAsync();
        Task SaveSettingsAsync(SettingsModel settings);
    }

    public class ConfigurationService : IConfigurationService
    {
        private static SettingsModel? _settings;

        public async Task<SettingsModel> LoadSettingsAsync()
        {
            // TODO: 실제 User Secrets/환경별 저장소 연동
            await Task.Delay(100);
            return _settings ?? new SettingsModel();
        }

        public async Task SaveSettingsAsync(SettingsModel settings)
        {
            // TODO: 실제 User Secrets/환경별 저장소 연동
            await Task.Delay(100);
            _settings = settings;
        }
    }
}
