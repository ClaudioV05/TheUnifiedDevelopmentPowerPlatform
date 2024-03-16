using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service guid.
    /// </summary>
    public class ServiceGuid : IServiceGuid
    {
        /// <summary>
        /// The constructor of service guid.
        /// </summary>
        /// <param name=""></param>
        public ServiceGuid() { }

        public string UDPGenerateTheNewGuidObject()
        {
            return Guid.NewGuid().ToString();
        }
    }
}