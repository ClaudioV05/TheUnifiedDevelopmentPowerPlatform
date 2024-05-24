using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface of service message.
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceMessage
{
    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeGlobal type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeDevelopmentEnvironments type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeArchitecturePatterns type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeDatabasesEngine type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeDatabases type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeFormsView type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeCrypto type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeMetadata type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeMetadataFields type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeMetadataTable type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeDirectory type);

    /// <summary>
    /// The get message.
    /// </summary>
    /// <param name="type"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>The description of message.</returns>
    string UDPPGetMessage(TypeValidation type);
}