namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceFile
    {
        /// <summary>
        /// Create all lines and save in file.
        /// </summary>
        /// <param name="informations"></param>
        /// <param name="rootDirectory"></param>
        /// <returns></returns>
        void UDPLinesGenerate(IEnumerable<string> informations, string rootDirectory);

        /// <summary>
        /// Reading lines from files and return in array of string.
        /// </summary>
        /// <param name="rootDirectory"></param>
        /// <returns></returns>
        IEnumerable<string>? UDPLinesRead(string rootDirectory);
    }
}