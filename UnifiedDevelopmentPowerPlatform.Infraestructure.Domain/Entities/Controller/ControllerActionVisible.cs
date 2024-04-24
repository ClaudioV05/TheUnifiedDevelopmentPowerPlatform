using System.ComponentModel.DataAnnotations.Schema;

namespace UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Controller
{
    [ComplexType]
    /// <summary>
    /// Controller Action Visible for UNIFIED DEVELOPMENT PLATFORM.
    /// </summary>
    public static class ControllerActionVisible
    {
        /// <summary>
        /// Controller action visible.
        /// </summary>
        public const bool Visible = true;

        /// <summary>
        /// Controller action not visible.
        /// </summary>
        public const bool NotVisible = false;
    }
}