namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for File.
    /// </summary>
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
        /// <returns>Return in IEnumerable of string.</returns>
        IEnumerable<string>? UDPReadAllLines(string path);

        /// <summary>
        /// Create all lines and save in file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="contents"></param>
        /// <returns></returns>
        void UDPWriteAllText(string path, string contents);

        /// <summary>
        /// Create and save initial file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        void UDPCreateAndSaveInitialFile(string path);

        /// <summary>
        /// Open and read all text.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>FileStream with the data.</returns>
        FileStream UDPOpenRead(string path);

        /// <summary>
        /// Append all text in existing file.
        /// </summary>
        /// <param name="pathWithFile"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        void UDPAppendAllText(string pathWithFile, string content);

        /// <summary>
        /// Get the file name.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string UDPGetFileName(string? path);
    }
}