using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceMessage.
    /// </summary>
    public interface IServiceMessage
    {
        /// <summary>
        /// Log mensagem.
        /// </summary>
        /// <param name="messageEnumerated"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>String with message of error.</returns>
        string UDPMensagem(MessageType messageEnumerated);
    }
}