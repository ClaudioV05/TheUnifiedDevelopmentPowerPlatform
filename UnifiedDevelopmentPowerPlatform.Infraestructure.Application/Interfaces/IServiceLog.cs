using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service log.
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceLog
{
    /// <summary>
    /// Logging of debug.
    /// </summary>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPLogDebug(string message);

    /// <summary>
    /// Error of debug.
    /// </summary>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPLogError(string message);

    /// <summary>
    /// Information of debug.
    /// </summary>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPLogInformation(string message);

    /// <summary>
    /// Warning of debug.
    /// </summary>
    /// <param name="message"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPLogWarning(string message);

    /// <summary>
    /// Make the register of log general for all application.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="additionalMessage"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPRegisterLog(string message, string additionalMessage);
}