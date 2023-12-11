namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceExtensibleMarkupLanguage
    {
        /// <summary>
        /// Tree xml save configuration file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        void UPDTreeXmlSaveConfigurationFile(string path, List<string> items);

        /// <summary>
        /// Tree xml save directory file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        void UPDTreeXmlSaveDirectoriesFile(string path, List<string> items);
    }
}