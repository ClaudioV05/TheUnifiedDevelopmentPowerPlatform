using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for App Settings.
    /// </summary>
    public class ServiceAppSettings : IServiceAppSettings
    {
        /// <summary>
        /// The constructor of Service App Settings.
        /// </summary>
        public ServiceAppSettings()
        {

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