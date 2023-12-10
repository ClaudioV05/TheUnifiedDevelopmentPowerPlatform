using System.Xml.Serialization;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.ExtensibleMarkupLanguage
{
    /// <summary>
    /// Extensible Markup Language - XML for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    [XmlRoot("ExtensibleMarkupLanguage", Namespace = "http://www.claudiomildo.com", IsNullable = true)]
    public static class ExtensibleMarkupLanguage
    {
        [XmlElement(IsNullable = true)]
        public const string FILENAME_CONFIGURATION = "_config.configuration";
        
        [XmlElement(IsNullable = true)]
        public const string FILENAME_DIRECTORY = "_config.directory";
        
        [XmlElement(IsNullable = true)]
        public const string FILENAME_FRONT_END = "Frontend";
    }
}