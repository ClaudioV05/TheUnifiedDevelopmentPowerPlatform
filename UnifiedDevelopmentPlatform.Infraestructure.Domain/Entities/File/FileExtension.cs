namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File
{
    /// <summary>
    /// File with extension for the application.
    /// </summary>
    public abstract class FileExtension
    {
        /// <summary>
        /// Text document file.
        /// </summary>
        public const string TXT = ".txt";

        /// <summary>
        /// Extensible markup language file.
        /// </summary>
        public const string XML = ".xml";

        /// <summary>
        /// JavaScript object notation file.
        /// </summary>
        public const string JSON = ".json";
    }
}