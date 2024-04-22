using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type of informations.
    /// </summary>
    public enum TypeInformations : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("The initial message")] TheInitialMessage = 1,
        [Description("The message default when occurred error")] TheGlobalErrorMessage = 2,
        [Description("Error filter action context controller")] ErrorFilterActionContextController = 3,
        [Description("Error filter action Context tables")] ErrorFilterActionContextTables = 4,
        [Description("Error filter action Context fields")] ErrorFilterActionContextFields = 5
    }
}