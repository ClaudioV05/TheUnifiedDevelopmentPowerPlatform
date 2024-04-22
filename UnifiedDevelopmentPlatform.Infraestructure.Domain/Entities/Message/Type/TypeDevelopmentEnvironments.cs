using System.ComponentModel;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Type
{
    /// <summary>
    /// The type to the development environments.
    /// </summary>
    public enum TypeDevelopmentEnvironments : int
    {
        [Description("The Message type do not specified")] DoNotSpecified = 0,
        [Description("Call start to the get data type from table at script metadata")] CallStartToTheGetDataTypeFromTableInScriptMetadata = 1,
        [Description("Success to the get data type from table at script metadata")] SuccessToTheGetDataTypeFromTableInScriptMetadata = 2,
        [Description("Error to the get data type from table at script metadata")] ErrorToTheGetDataTypeFromTableInScriptMetadata = 3,
        [Description("Call start to get data type C-Sharp at script metadata")] CallStartToGetDataTypeOfCSharp = 4,
        [Description("Success to get data type C-Sharp at script metadata")] SuccessToGetDataTypeOfCSharp = 5,
        [Description("Error to get data type C-Sharp at script metadata")] ErrorToGetDataTypeOfCSharp = 6,
        [Description("Call start to get data type Pascal at script metadata")] CallStartToGetDataTypeOfPascal = 7,
        [Description("Success to get data type Pascal at script metadata")] SuccessToGetDataTypeOfPascal = 8,
        [Description("Error to get data type Pascal at script metadata")] ErrorToGetDataTypeOfPascal = 9,
        [Description("Call start to the select parameters the kinds of development enviroment")] CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment = 10,
        [Description("Success to the select parameters the kinds of development enviroment")] SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment = 11,
        [Description("Call start to the save identifier to the development enviroments from metadata")] CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata = 12,
        [Description("Success to the save identifier to the development enviroments from metadata")] SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata = 13
    }
}