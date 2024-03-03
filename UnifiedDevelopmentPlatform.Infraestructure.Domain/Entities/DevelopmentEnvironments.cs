using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Interfaces;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity Development Environments.
    /// </summary>
    [ComplexType]
    public class DevelopmentEnvironments : IEntity
    {
        /// <summary>
        /// Enum type for entitie development environments.
        /// </summary>
        [Flags]
        public enum EnumeratedDevelopmentEnvironments : int
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
        public EnumeratedDevelopmentEnvironments IdEnumeration { get; set; } = 0;

        /// <summary>
        /// Name of enumeration.
        /// </summary>
        public string? NameEnumeration { get; set; }
    }
}