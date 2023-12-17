namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceFile
    {
        /// <summary>
        /// Verify if file exist.
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <returns>Return true otherwise false.</returns>
        bool UDPFileExists(string rootDirectory);

        /// <summary>
        /// Read all text.
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <returns>String with the data.</returns>
        string UDPReadAllText(string rootDirectory);

        /// <summary>
        /// Reading lines from files.
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <returns>Return in array of string.</returns>
        IEnumerable<string>? UDPLinesRead(string rootDirectory);

        /// <summary>
        /// Create all lines and save in file.
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <param name="informations"></param>
        /// <returns></returns>
        void UDPLinesGenerate(string rootDirectory, IEnumerable<string> informations);
    }
}