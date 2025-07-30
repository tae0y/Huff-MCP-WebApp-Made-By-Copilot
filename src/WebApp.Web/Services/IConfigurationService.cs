
using System.Threading.Tasks;
using WebApp.Web.Models;

namespace WebApp.Web.Services
{
    public interface IConfigurationService
    {
        Task SaveSettingsAsync(SettingsModel model);
        Task<SettingsModel?> LoadSettingsAsync();
    }
}
