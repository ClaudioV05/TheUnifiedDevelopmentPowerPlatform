namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceAppSettings.
    /// </summary>
    public interface IServiceAppSettings
    {
        /// <summary>
        /// Add information to appSettings file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UPDAddAppSettings(string path, string key, string value);
    }
}