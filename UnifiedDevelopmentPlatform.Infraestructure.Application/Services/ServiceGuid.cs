using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service guid.
    /// </summary>
    public class ServiceGuid : IServiceGuid
    {
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service guid.
        /// </summary>
        /// <param name="serviceFuncString"></param>
        public ServiceGuid(IServiceFuncString serviceFuncString)
        {
            _serviceFuncString = serviceFuncString;
        }

        public string UDPGenerateTheNewGuidObject()
        {
            try
            {
                return Guid.NewGuid().ToString();
            }
            catch (Exception)
            {
                return _serviceFuncString.Empty;
            }
        }
    }
}