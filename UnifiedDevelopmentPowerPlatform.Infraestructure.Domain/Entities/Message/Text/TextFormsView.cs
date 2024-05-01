using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Text;

/// <summary>
/// The text to the forms view.
/// </summary>
[ComplexType]
public static class TextFormsView
{
    /// <summary>
    /// Message type do not specified.
    /// </summary>
    public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

    /// <summary>
    /// Call start to the Select parameters the kinds of forms.
    /// </summary>
    public static string CallStartToTheSelectParametersTheKindsOfForms => "CALL START TO THE SELECT PARAMETERS THE KINDS OF FORMS.";

    /// <summary>
    /// Success to the Select parameters the kinds of forms.
    /// </summary>
    public static string SuccessToTheSelectParametersTheKindsOfForms => "SUCCESS TO THE SELECT PARAMETERS THE KINDS OF FORMS.";

    /// <summary>
    /// Call start to the save identifier to the form from metadata.
    /// </summary>
    public static string CallStartToTheSaveIdentifierToTheFormFromMetadata => "CALL START TO THE SAVE IDENTIFIER TO THE FORM FROM METADATA.";

    /// <summary>
    /// Success to the save identifier to the form from metadata.
    /// </summary>
    public static string SuccessToTheSaveIdentifierToTheFormFromMetadata => "SUCCESS TO THE SAVE IDENTIFIER TO THE FORM FROM METADATA.";
}