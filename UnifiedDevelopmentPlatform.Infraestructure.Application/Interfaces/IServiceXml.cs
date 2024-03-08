namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceXml.
    /// </summary>
    public interface IServiceXml
    {
        /// <summary>
        /// Save tree xml for configuration file with name 'App' and 'Configuration'.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameSection"></param>
        /// <param name="item"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UPDTreeXmlSave(string path, string nameSection, string item);

        /// <summary>
        /// Save tree xml with all directories. For example: 1-Presentation, 2-Application, 3-Domain, 4-Infrastructure.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="nameSection"></param>
        /// <param name="items"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UPDTreeXmlSave(string path, string nameSection, List<string> items);
    }
}