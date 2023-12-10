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
        void TreeXmlSaveConfigurationFile(string path, List<string> items);

        /// <summary>
        /// Tree xml save directory file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        void TreeXmlSaveDirectoriesFile(string path, List<string> items);
    }
}