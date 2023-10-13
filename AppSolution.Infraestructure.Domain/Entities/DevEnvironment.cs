using AppSolution.Infraestructure.Domain.Enums;
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
        /// Id of Types.
        /// </summary>
        public DevEnvironmentTypes Type { get; set; } = 0;
    }
}