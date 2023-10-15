using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entity DevelopmentEnvironment.
    /// </summary>
    [ComplexType]
    public class DevEnvironment : BaseEntity
    {
        /// <summary>
        /// Enum type for entitie DevelopmentEnvironment.
        /// </summary>
        public enum EnumDevEnvironment : ushort
        {
            NotDefined = 0,
            DelphiXe10 = 1,
            VisualStudio = 2
        }

        /// <summary>
        /// Id of Types.
        /// </summary>
        public EnumDevEnvironment Type { get; set; } = 0;
    }
}