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
 
        public const string EXTENSION = ".xml";

        [XmlElement(IsNullable = true)]
        public const string FILENAME_CONFIGURATION = "_path.configuration";

        [XmlElement(IsNullable = true)]
        public const string FILENAME_APP = "_path.app";

        [XmlElement(IsNullable = true)]
        public const string FILENAME_DIRECTORY = "_path.directory";
        
        [XmlElement(IsNullable = true)]
        public const string FILENAME_FRONT_END = "Frontend";
    }
}