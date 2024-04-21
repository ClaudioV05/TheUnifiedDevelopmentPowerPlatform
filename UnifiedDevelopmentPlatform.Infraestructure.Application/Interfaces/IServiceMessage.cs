using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface of Service Message.
    /// </summary>
    public interface IServiceMessage
    {
        /// <summary>
        /// The message.
        /// </summary>
        /// <param name="enumerated"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPMessage(MessageType enumerated);

        /// <summary>
        /// The message.
        /// </summary>
        /// <param name="type"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPMessage(TypeDevelopmentEnvironments type);

        /// <summary>
        /// The message.
        /// </summary>
        /// <param name="type"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPMessage(TypeArchitecturePatterns type);
    }
}