using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File
{
    [ComplexType]
    /// <summary>
    /// File with extension for the application.
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// Text document file.
        /// </summary>
        public static string Txt { get; } = ".txt";

        /// <summary>
        /// Extensible markup language file.
        /// </summary>
        public static string Xml { get; } = ".xml";

        /// <summary>
        /// JavaScript object notation file.
        /// </summary>
        public static string Json { get; } = ".json";

        /// <summary>
        /// C Sharp file.
        /// </summary>
        public static string Cs { get; } = ".cs";

        /// <summary>
        /// C Sharp Project file.
        /// </summary>
        public static string CSharpProj { get; } = ".csproj";

        /// <summary>
        /// Sln file.
        /// </summary>
        public static string Sln { get; } = ".sln";
    }
}