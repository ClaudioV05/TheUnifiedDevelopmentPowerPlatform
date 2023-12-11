namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceAppSettings
    {
        /// <summary>
        /// Add information to appSettings file.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void UPDAddAppSettings(string key, string value);
    }
}