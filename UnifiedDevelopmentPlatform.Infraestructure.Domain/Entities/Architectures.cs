using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Architectures.
    /// </summary>
    [ComplexType]
    public class Architectures : IEntity
    {
        /// <summary>
        /// Enum type for entitie Architecture.
        /// </summary>
        public enum EnumArchitecture : int
        {
            [Description("Not Defined")]
            NotDefined = 0,
            [Description("Domain Driven Design")]
            DDD = 1,
            [Description("Command Query Responsibility Segregation")]
            CQRS = 2
        }

        public long Id { get; set; }

        public string Name { get; set; }

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