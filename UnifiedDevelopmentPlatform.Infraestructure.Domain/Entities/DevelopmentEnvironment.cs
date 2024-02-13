using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Development Environment.
    /// </summary>
    [ComplexType]
    public class DevelopmentEnvironment
    {
        /// <summary>
        /// Enum type for entitie DevelopmentEnvironment.
        /// </summary>
        public enum EnumDevelopmentEnvironment : int
        {
            [Description("Not Defined")]
            NotDefined = 0,
            [Description("DelphiXe10")]
            DelphiXe10 = 1,
            [Description("VisualStudio")]
            VisualStudio = 2
        }

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumDevelopmentEnvironment IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}