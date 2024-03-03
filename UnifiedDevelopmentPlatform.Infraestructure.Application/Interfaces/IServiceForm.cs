using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service forms.
    /// </summary>
    public interface IServiceForm
    {
        /// <summary>
        /// Select parameters the kinds of forms.
        /// </summary>
        /// <returns>Return the complete list of forms.</returns>
        List<Forms> UDPSelectParametersTheKindsOfForms();

        /// <summary>
        /// Save identifier to the form from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        void UDPSaveIdentifierToTheFormFromMetadata(MetadataOwner metadata);
    }
}