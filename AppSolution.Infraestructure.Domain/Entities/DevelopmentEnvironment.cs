using System.ComponentModel.DataAnnotations.Schema;

namespace AppSolution.Infraestructure.Domain.Entities
{
    /// <summary>
    /// Entitie DevelopmentEnvironment.
    /// </summary>
    [ComplexType]
    public class DevelopmentEnvironment
    {
        /// <summary>
        /// Enum type for entitie DevelopmentEnvironment.
        /// </summary>
        public enum Types : ushort
        {
            NotDefined = 0,
            DelphiXe10 = 1,
            VisualStudio = 2
        }

        /// <summary>
        /// Id of Types.
        /// </summary>
        public Types Type { get; set; } = 0;
    }
}