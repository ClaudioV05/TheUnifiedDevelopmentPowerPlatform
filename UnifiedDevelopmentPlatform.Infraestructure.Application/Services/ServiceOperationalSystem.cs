using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for The Operational System.
    /// </summary>
    public class ServiceOperationalSystem : IServiceOperationalSystem
    {
        /// <summary>
        /// The constructor of Service Operational System.
        /// </summary>
        public ServiceOperationalSystem()
        {

        }

        public bool UPDOperationalSystemIsWindows()
        {
            return OperatingSystem.IsWindows();
        }
    }
}