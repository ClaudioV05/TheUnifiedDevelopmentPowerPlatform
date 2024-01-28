using System.Globalization;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Datetime;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Date.
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
            return DateTime.Now.ToString(DatetimeFormat.Format_13);
        }

        /// <summary>
        /// Configure the culture information.
        /// </summary>
        /// <returns></returns>
        private CultureInfo? ConfigureCultureInfo()
        {
            var culture = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            return culture;
        }
    }
}