namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceXml
    {
        /// <summary>
        /// Save tree xml for configuration file with name 'App' and 'Configuration'.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        void UPDTreeXmlSaveConfigurationFile(string path, List<string> items);

        /// <summary>
        /// Save tree xml with all directories. For example: 1-Presentation, 2-Application, 3-Domain, 4-Infrastructure.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        void UPDTreeXmlSaveDirectoriesFile(string path, List<string> items);
    }
}