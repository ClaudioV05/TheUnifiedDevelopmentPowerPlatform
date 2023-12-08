namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceSearchLinq
    {

        /// <summary>
        /// Select all directorys default.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="defaultDirectory"></param>
        /// <returns>List contains the directories</returns>
        List<string>? SelectAllPathFromDirectory(List<string> items, string defaultDirectory);

        /// <summary>
        /// Get root path configuration.
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Name of path configuration</returns>
        string GetPathConfiguration(List<string> items);
    }
}