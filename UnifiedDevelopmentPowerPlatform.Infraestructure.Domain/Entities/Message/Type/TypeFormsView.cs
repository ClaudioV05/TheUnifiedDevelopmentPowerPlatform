using System.ComponentModel;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;

/// <summary>
/// The type to the forms view.
/// </summary>
public enum TypeFormsView : int
{
    [Description("The Message type do not specified")]
    DoNotSpecified = 0,
    [Description("Call start to the Select parameters the kinds of forms")]
    CallStartToTheSelectParametersTheKindsOfForms = 1,
    [Description("Success to the select parameters the kinds of forms")]
    SuccessToTheSelectParametersTheKindsOfForms = 2,
    [Description("Call start to the save identifier to the form from metadata")]
    CallStartToTheSaveIdentifierToTheFormFromMetadata = 3,
    [Description("Success to the save identifier to the form from metadata")]
    SuccessToTheSaveIdentifierToTheFormFromMetadata = 4
}