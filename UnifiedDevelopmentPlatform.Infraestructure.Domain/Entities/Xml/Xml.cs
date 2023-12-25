using System.Xml.Serialization;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Xml
{
    /// <summary>
    /// Extensible Markup Language - XML for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    [XmlRoot("ExtensibleMarkupLanguage", Namespace = "http://www.claudiomildo.com", IsNullable = true)]
    public static class Xml
    {
        public const string ELEMENT_NAME = "path";

        public const string SECTION_DIRECTORIES_NAME = "directories";

        [XmlElement(IsNullable = true)]
        public const string FILENAME_CONFIGURATION = "\\configuration";

        [XmlElement(IsNullable = true)]
        public const string FILENAME_APP = "\\app";

        [XmlElement(IsNullable = true)]
        public const string FILENAME_DIRECTORY = "\\directory";
        
        [XmlElement(IsNullable = true)]
        public const string FILENAME_FRONT_END = "Frontend";
    }
}