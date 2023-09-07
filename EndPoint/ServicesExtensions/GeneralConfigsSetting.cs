using Domain.Models;

namespace EndPoint.ServicesExtensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneralConfigsSetting
    {
        public static GeneralSettings GetGeneralSettings(IConfiguration configuration)
        {
            var generalSettings = configuration.GetSection("GeneralSettings").Get<GeneralSettings>();
            if (generalSettings is null) throw new NullReferenceException();
            generalSettings.Url += generalSettings.Port;
            return generalSettings;
        }
    }
}