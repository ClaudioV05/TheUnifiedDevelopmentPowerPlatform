namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceFile
    {
        /// <summary>
        /// Verify if file exist.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPFileExists(string? path);

        /// <summary>
        /// Read all text.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>String with the data.</returns>
        string UDPReadAllText(string path);

        /// <summary>
        /// Reading lines from files.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Return in array of string.</returns>
        IEnumerable<string>? UDPLinesRead(string path);

        /// <summary>
        /// Create all lines and save in file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        void UDPLinesGenerate(string path, IEnumerable<string> contents);

        /// <summary>
        /// Create and save initial file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        void UDPCreateAndSaveInitialFile(string path);
    }
}