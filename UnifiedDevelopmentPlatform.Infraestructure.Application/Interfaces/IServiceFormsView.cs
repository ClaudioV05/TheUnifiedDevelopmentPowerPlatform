using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service forms view.
    /// </summary>
    public interface IServiceFormsView
    {
        /// <summary>
        /// Select parameters the kinds of the forms view.
        /// </summary>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns>Return the complete list of forms.</returns>
        List<FormsView> UDPSelectParametersTheKindsOfFormsView();

        /// <summary>
        /// Save identifier to the forms view from metadata.
        /// </summary>
        /// <param name="metadata"></param>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        void UDPSaveIdentifierToTheFormsViewFromMetadata(MetadataOwner metadata);
    }
}