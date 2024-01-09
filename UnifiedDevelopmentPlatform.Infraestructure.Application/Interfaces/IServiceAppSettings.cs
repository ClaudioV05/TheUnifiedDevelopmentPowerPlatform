namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for App Settings.
    /// </summary>
    public interface IServiceAppSettings
    {
        /// <summary>
        /// Add information to appSettings file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void UPDAddAppSettings(string path, string key, string value);
    }
}