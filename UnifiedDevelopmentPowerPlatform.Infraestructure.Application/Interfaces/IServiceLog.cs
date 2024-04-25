using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service log.
    /// </summary>
    public interface IServiceLog
    {
        /// <summary>
        /// Logging of debug.
        /// </summary>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPLogDebug(string message);

        /// <summary>
        /// Error of debug.
        /// </summary>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPLogError(string message);

        /// <summary>
        /// Information of debug.
        /// </summary>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPLogInformation(string message);

        /// <summary>
        /// Warning of debug.
        /// </summary>
        /// <param name="message"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPLogWarning(string message);

        /// <summary>
        /// Make the register of log general for all application.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="additionalMessage"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPRegisterLog(string message, string additionalMessage);
    }
}