namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
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