using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Logging
{
    public static class LogConfiguration
    {
        /// <summary>
        /// The identifier of log.
        /// </summary>
        public static string Identifier => $"Identifier{MetaCharacterSymbols.Colon}{MetaCharacterSymbols.WhiteSpace}";

        /// <summary>
        /// File name of the log.
        /// </summary>
        public static string FileName => $"File{MetaCharacterSymbols.Colon}{MetaCharacterSymbols.WhiteSpace}";

        /// <summary>
        /// Method name of the log.
        /// </summary>
        public static string MethodName => $"Method name{MetaCharacterSymbols.Colon}{MetaCharacterSymbols.WhiteSpace}";

        /// <summary>
        /// Line number of the log.
        /// </summary>
        public static string LineNumber => $"Line number{MetaCharacterSymbols.Colon}{MetaCharacterSymbols.WhiteSpace}";

        /// <summary>
        /// Line column of the log.
        /// </summary>
        public static string LineColumn => $"Line column{MetaCharacterSymbols.Colon}{MetaCharacterSymbols.WhiteSpace}";

        /// <summary>
        /// Message of the log.
        /// </summary>
        public static string Message => $"Message{MetaCharacterSymbols.Colon}{MetaCharacterSymbols.WhiteSpace}";

        /// <summary>
        /// Additional message of the log.
        /// </summary>
        public static string AdditionalMessage => $"Additional message{MetaCharacterSymbols.Colon}{MetaCharacterSymbols.WhiteSpace}";

        /// <summary>
        /// The datetime of log.
        /// </summary>
        public static string Datetime => $"DateTime{MetaCharacterSymbols.Colon}{MetaCharacterSymbols.WhiteSpace}";
    }
}