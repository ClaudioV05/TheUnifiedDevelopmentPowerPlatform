using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Xml
{
    [ComplexType]
    /// <summary>
    /// Extensible Markup Language - XML for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    [XmlRoot("ExtensibleMarkupLanguage", Namespace = "http://www.claudiomildo.com", IsNullable = true)]
    public static class Xml
    {
        /// <summary>
        /// Element name.
        /// </summary>
        public static string ElementName { get; } = "path";

        /// <summary>
        /// Section directories name.
        /// </summary>
        public static string SectionDirectoriesName { get; } = "directories";

        /// <summary>
        /// Filename configuration.
        /// </summary>
        [XmlElement(IsNullable = true)]
        public static string FilenameConfiguration { get; } = "\\configuration";

        /// <summary>
        /// Filename app.
        /// </summary>
        [XmlElement(IsNullable = true)]
        public static string FilenameApp { get; } = "\\app";

        /// <summary>
        /// Filename directory.
        /// </summary>
        [XmlElement(IsNullable = true)]
        public static string FilenameDirectory { get; } = "\\directory";

        /// <summary>
        /// Filename frontend.
        /// </summary>
        [XmlElement(IsNullable = true)]
        public static string FilenameFrontend { get; } = "Frontend";

        /// <summary>
        /// Filename backend.
        /// </summary>
        [XmlElement(IsNullable = true)]
        public static string FilenameBackend { get; } = "Backend";
    }
}