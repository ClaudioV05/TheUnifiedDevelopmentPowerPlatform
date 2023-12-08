namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceExtensibleMarkupLanguage
    {
        /// <summary>
        /// Create the tree directory save.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        bool TreeDirectorySave(string path, List<string> items);
    }
}