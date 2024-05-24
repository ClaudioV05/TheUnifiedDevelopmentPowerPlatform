using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;

namespace UnifiedDevelopmentPowerPlatform.Application.Interfaces;

/// <summary>
/// Interface service forms view.
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceFormsView
{
    /// <summary>
    /// Select parameters the kinds of the forms view.
    /// </summary>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns>Return the complete list of forms.</returns>
    List<FormsView> UDPPSelectParametersTheKindsOfFormsView();

    /// <summary>
    /// Save identifier to the forms view from metadata.
    /// </summary>
    /// <param name="metadata"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    void UDPPSaveIdentifierToTheFormsViewFromMetadata(MetadataOwner metadata);
}