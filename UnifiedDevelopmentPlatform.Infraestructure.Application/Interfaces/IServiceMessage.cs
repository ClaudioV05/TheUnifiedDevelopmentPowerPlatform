using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface of service Message.
    /// </summary>
    public interface IServiceMessage
    {
        /// <summary>
        /// The get message.
        /// </summary>
        /// <param name="enumerated"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPGetMessage(MessageType enumerated);

        /// <summary>
        /// The get message.
        /// </summary>
        /// <param name="type"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPGetMessage(TypeDevelopmentEnvironments type);

        /// <summary>
        /// The get message.
        /// </summary>
        /// <param name="type"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPGetMessage(TypeArchitecturePatterns type);

        /// <summary>
        /// The get message.
        /// </summary>
        /// <param name="type"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPGetMessage(TypeDatabasesEngine type);

        /// <summary>
        /// The get message.
        /// </summary>
        /// <param name="type"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPGetMessage(TypeDatabases type);

        /// <summary>
        /// The get message.
        /// </summary>
        /// <param name="type"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPGetMessage(TypeFormsView type);

        /// <summary>
        /// The get message.
        /// </summary>
        /// <param name="type"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>The description of message.</returns>
        string UDPGetMessage(TypeCrypto type);
    }
}