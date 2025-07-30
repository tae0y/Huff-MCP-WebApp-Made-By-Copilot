using System.ComponentModel.DataAnnotations;

namespace WebApp.Web.Models
{
    public class SettingsModel
    {
        [Required(ErrorMessage = "AI Provider는 필수입니다.")]
        public string Provider { get; set; } = "AzureOpenAI";

        [Required(ErrorMessage = "API Key는 필수입니다.")]
        public string ApiKey { get; set; } = string.Empty;

        [Required(ErrorMessage = "Endpoint는 필수입니다.")]
        public string Endpoint { get; set; } = string.Empty;
    }
}
