using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (App Settings).
    /// </summary>
    public class ServiceAppSettings : IServiceAppSettings
    {
        private readonly IServiceFile _serviceFile;
        private readonly IServiceJson _serviceJson;

        public ServiceAppSettings(IServiceFile serviceFile, IServiceJson serviceJson, IServiceJson serviceJavaScriptObjectNotation)
        {
            _serviceFile = serviceFile;
            _serviceJson = serviceJson;
        }

        public void UPDAddAppSettings(string path, string key, string value)
        {
            try
            {

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}