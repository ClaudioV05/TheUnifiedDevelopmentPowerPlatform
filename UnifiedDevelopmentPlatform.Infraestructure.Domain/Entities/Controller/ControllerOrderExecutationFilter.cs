using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller Order Executation Filter for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class ControllerOrderExecutationFilter
    {
        /// <summary>
        /// First order execution.
        /// </summary>
        public const int First = 1;

        /// <summary>
        /// Second order execution.
        /// </summary>
        public const int Second = 2;

        /// <summary>
        /// Third order execution.
        /// </summary>
        public const int Third = 3;
    }
}