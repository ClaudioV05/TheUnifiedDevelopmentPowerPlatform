using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Log.
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

        /// <summary>
        /// Register Log general for application.
        /// </summary>
        /// <param name="message"></param>
        void UDPLogReport(string message);
    }
}