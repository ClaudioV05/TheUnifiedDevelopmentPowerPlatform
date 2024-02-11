using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Architectures.
    /// </summary>
    [ComplexType]
    public class Architectures
    {
        /// <summary>
        /// Enum type for entitie Architecture.
        /// </summary>
        public enum EnumArchitecture : int
        {
            [Description("Not Defined")]
            NotDefined = 0,
            [Description("Domain Driven Design")]
            DomainDrivenDesign = 1
        }

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumArchitecture IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}