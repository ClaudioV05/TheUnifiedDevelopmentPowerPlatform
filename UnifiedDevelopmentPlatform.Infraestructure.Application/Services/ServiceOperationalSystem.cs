using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for (The Operational System).
    /// </summary>
    public class ServiceOperationalSystem : IServiceOperationalSystem
    {
        public bool UPDOperationalSystemIsWindows()
        {
            return OperatingSystem.IsWindows();
        }
    }
}