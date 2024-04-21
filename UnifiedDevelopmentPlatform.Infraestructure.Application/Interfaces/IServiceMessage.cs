using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceMessage.
    /// </summary>
    public interface IServiceMessage
    {
        /// <summary>
        /// Log message.
        /// </summary>
        /// <param name="enumerated"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description message.</returns>
        string UDPMessage(MessageType enumerated);

        /// <summary>
        /// Log message to the development environments.
        /// </summary>
        /// <param name="enumerated"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description message.</returns>
        string UDPMessageDevelopmentEnvironments(MessageTypeDevelopmentEnvironments enumerated);
    }
}