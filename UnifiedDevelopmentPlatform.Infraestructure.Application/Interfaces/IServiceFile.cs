namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service File.
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
        /// Create and save initial file with class File.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        void UDPCreateAndSaveFile(string path);

        /// <summary>
        /// Create and save file whit Class StreamWrite.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        void UDPCreateAndSaveFileWithStreamWrite(string path);

        /// <summary>
        /// Open and read all text.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>FileStream with the data.</returns>
        FileStream UDPOpenRead(string path);

        /// <summary>
        /// Append all text in existing file.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        void UDPAppendAllText(string path, string content);

        /// <summary>
        /// Get the file name.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string UDPGetFileName(string path);

        /// <summary>
        /// Count lines using StreamReader.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>The number of lines.</returns>
        int UDPCountLines(string fileName);
    }
}