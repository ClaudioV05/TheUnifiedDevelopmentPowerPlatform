using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Development Environment.
    /// </summary>
    [ComplexType]
    public class DevelopmentEnvironment : IEntity
    {
        /// <summary>
        /// Enum type for entitie DevelopmentEnvironment.
        /// </summary>
        public enum EnumeratedDevelopmentEnvironment : int
        {
            [Description("Not Defined")]
            NotDefined = 0,
            [Description("DelphiXe10")]
            DelphiXe10 = 1,
            [Description("VisualStudio")]
            VisualStudio = 2
        }

        public long Id { get; set; }

        public string? Name { get; set; }

        /// <summary>
        /// Id Enumeration.
        /// </summary>
        public EnumeratedDevelopmentEnvironment IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}