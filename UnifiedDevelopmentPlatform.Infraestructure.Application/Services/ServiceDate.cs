using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Datetime;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for Date.
    /// </summary>
    public class ServiceDate : IServiceDate
    {
        /// <summary>
        /// The constructor of Service Date.
        /// </summary>
        public ServiceDate()
        {

        }

        public string UDPGetDateTimeNowFormat()
        {
            return DateTime.Now.ToString(DatetimeFormat.Format_11);
        }
    }
}