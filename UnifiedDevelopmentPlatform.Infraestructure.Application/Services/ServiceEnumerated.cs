using System.ComponentModel;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service enumerated.
    /// </summary>
    public class ServiceEnumerated : IServiceEnumerated
    {
        /// <summary>
        /// The constructor of Service Enumerated.
        /// </summary>
        public ServiceEnumerated() { }

        public string UDPGetEnumeratedDescription(Enum EnumeratedValue)
        {
            var fieldInfo = EnumeratedValue.GetType().GetField(EnumeratedValue.ToString());
            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : EnumeratedValue.ToString();
        }
    }
}