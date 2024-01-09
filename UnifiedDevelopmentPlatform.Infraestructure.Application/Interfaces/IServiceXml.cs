namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for Extensible Markup Language - XML.
    /// </summary>
    public interface IServiceXml
    {
        /// <summary>
        /// Save tree xml for configuration file with name 'App' and 'Configuration'.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameSection"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        void UPDTreeXmlSave(string path, string nameSection, string item);

        /// <summary>
        /// Save tree xml with all directories. For example: 1-Presentation, 2-Application, 3-Domain, 4-Infrastructure.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameSection"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        void UPDTreeXmlSave(string path, string nameSection, List<string> items);
    }
}