using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Message.
    /// </summary>
    public interface IServiceMessage
    {
        /// <summary>
        /// Log mensagem.
        /// </summary>
        /// <param name="messageEnumerated"></param>
        /// <returns>String with message of error.</returns>
        string UDPMensagem(MessageType messageEnumerated);
    }
}