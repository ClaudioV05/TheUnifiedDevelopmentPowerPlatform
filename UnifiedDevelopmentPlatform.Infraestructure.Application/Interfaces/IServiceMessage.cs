using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface of service message.
    /// </summary>
    public interface IServiceMessage
    {
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
        string UDPGetMessage(TypeInformations type);

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
        string UDPGetMessage(TypeMetadata type);

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
        string UDPGetMessage(TypeMetadataFields type);

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
        string UDPGetMessage(TypeMetadataTable type);

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
        string UDPGetMessage(TypeDirectory type);

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
        string UDPGetMessage(TypeValidation type);
    }
}