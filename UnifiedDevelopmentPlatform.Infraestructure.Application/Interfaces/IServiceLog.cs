namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for (Log).
    /// </summary>
    public interface IServiceLog
    {
        /// <summary>
        /// Logging of debug.
        /// </summary>
        /// <param name="message"></param>
        void UDPLogDebug(string message);

        /// <summary>
        /// Error of debug.
        /// </summary>
        /// <param name="message"></param>
        void UDPLogError(string message);

        /// <summary>
        /// Information of debug.
        /// </summary>
        /// <param name="message"></param>
        void UDPLogInformation(string message);

        /// <summary>
        /// Warning of debug.
        /// </summary>
        /// <param name="message"></param>
        void UDPLogWarning(string message);
    }
}