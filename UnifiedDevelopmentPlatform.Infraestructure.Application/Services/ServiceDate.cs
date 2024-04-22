using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Datetime;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service date.
    /// </summary>
    public class ServiceDate : IServiceDate
    {
        /// <summary>
        /// The constructor of service date.
        /// </summary>
        public ServiceDate() { }

        public string UDPGetDateTimeNowFormat()
        {
            return DateTime.Now.ToString(DatetimeFormat.Format_13);
        }

        public string UDPGetDateTimeToLongTime()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}