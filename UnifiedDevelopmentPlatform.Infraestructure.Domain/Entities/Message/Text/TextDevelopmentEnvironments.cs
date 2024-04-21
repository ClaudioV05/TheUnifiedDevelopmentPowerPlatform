using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message.Text
{
    [ComplexType]
    /// <summary>
    /// The text to the development environments.
    /// </summary>
    public static class TextDevelopmentEnvironments
    {
        /// <summary>
        /// Message type do not specified.
        /// </summary>
        public static string DoNotSpecified => "THE MESSAGE TYPE DO NOT SPECIFIED.";

        /// <summary>
        /// Call start to the get data type from table at script metadata.
        /// </summary>  
        public static string CallStartToTheGetDataTypeFromTableInScriptMetadata => "CALL START TO THE GET DATA TYPE FROM TABLE AT SCRIPT METADATA.";

        /// <summary>
        /// Success to the get data type from table at script metadata.
        /// </summary>
        public static string SuccessToTheGetDataTypeFromTableInScriptMetadata => "SUCCESS TO THE GET DATA TYPE FROM TABLE AT SCRIPT METADATA.";

        /// <summary>
        /// Error to the get data type from table at script metadata.
        /// </summary>
        public static string ErrorToTheGetDataTypeFromTableInScriptMetadata => "ERROR TO THE GET DATA TYPE FROM TABLE AT SCRIPT METADATA.";

        /// <summary>
        /// Call start to get data type C-Sharp at script metadata.
        /// </summary>  
        public static string CallStartToGetDataTypeOfCSharp => "CALL START TO GET DATA TYPE C-SHARP AT SCRIPT METADATA.";

        /// <summary>
        /// Success to get data type C-Sharp at script metadata.
        /// </summary>
        public static string SuccessToGetDataTypeOfCSharp => "SUCCESS TO GET DATA TYPE C-SHARP AT SCRIPT METADATA.";

        /// <summary>
        /// Error to get data type C-Sharp at script metadata.
        /// </summary>
        public static string ErrorToGetDataTypeOfCSharp => "ERROR TO GET DATA TYPE C-SHARP AT SCRIPT METADATA.";

        /// <summary>
        /// Call start to get data type Pascal at script metadata.
        /// </summary>  
        public static string CallStartToGetDataTypeOfPascal => "CALL START TO GET DATA TYPE PASCAL AT SCRIPT METADATA.";

        /// <summary>
        /// Success to get data type Pascal at script metadata.
        /// </summary>
        public static string SuccessToGetDataTypeOfPascal => "SUCCESS TO GET DATA TYPE PASCAL AT SCRIPT METADATA.";

        /// <summary>
        /// Error to get data type Pascal at script metadata.
        /// </summary>
        public static string ErrorToGetDataTypeOfPascal => "ERROR TO GET DATA TYPE PASCAL AT SCRIPT METADATA.";

        /// <summary>
        /// Call start to the Select parameters the kinds of development enviroment.
        /// </summary>
        public static string CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment => "CALL START TO THE SELECT PARAMETERS THE KINDS OF DEVELOPMENT ENVIROMENT.";

        /// <summary>
        /// Success to the Select parameters the kinds of development enviroment.
        /// </summary>
        public static string SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment => "SUCCESS TO THE SELECT PARAMETERS THE KINDS OF DEVELOPMENT ENVIROMENT.";

        /// <summary>
        /// Call start to the save identifier to the development enviroments from metadata.
        /// </summary>
        public static string CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata => "CALL START TO THE SAVE IDENTIFIER TO THE DEVELOPMENT ENVIROMENTS FROM METADATA.";

        /// <summary>
        /// Success to the save identifier to the development enviroments from metadata.
        /// </summary>
        public static string SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata => "SUCCESS TO THE SAVE IDENTIFIER TO THE DEVELOPMENT ENVIROMENTS FROM METADATA.";
    }
}