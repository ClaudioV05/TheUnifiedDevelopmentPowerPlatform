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
        /// Text document file - TXT.
        /// </summary>
        public static string Txt { get; } = ".txt";

        /// <summary>
        /// Extensible markup language file - XML.
        /// </summary>
        public static string Xml { get; } = ".xml";

        /// <summary>
        /// JavaScript object notation file - JSON.
        /// </summary>
        public static string Json { get; } = ".json";

        /// <summary>
        /// C Sharp file - CS.
        /// </summary>
        public static string Cs { get; } = ".cs";

        /// <summary>
        /// C Sharp Project file - Cs Project.
        /// </summary>
        public static string CSharpProj { get; } = ".csproj";

        /// <summary>
        /// Sln file - Solution.
        /// </summary>
        public static string Sln { get; } = ".sln";

        /// <summary>
        /// HyperText Markup Language - HTML.
        /// </summary>
        public static string Html { get; } = ".html";

        /// <summary>
        /// JavaScript.
        /// </summary>
        public static string JavaScript { get; } = ".js";

        /// <summary>
        /// TypeScript.
        /// </summary>
        public static string TypeScript { get; } = ".ts";

        /// <summary>
        /// Cascading Style Sheets - Css.
        /// </summary>
        public static string Css { get; } = ".css";
    }
}