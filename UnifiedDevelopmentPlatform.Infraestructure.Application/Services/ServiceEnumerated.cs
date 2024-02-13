using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Enumerated.
    /// </summary>
    public class ServiceEnumerated<T, U> : IServiceEnumerated<T, U> where T : struct where U : class, new()
    {
        /// <summary>
        /// The constructor of Service Enumerated.
        /// </summary>
        public ServiceEnumerated() { }

        public List<U> UDPObtainListItem(T UdpEnumerated, U obj)
        {
            List<U> listItems = new List<U>();

            obj.GetType().GetProperties();

            try
            {
                if (Enum.GetValues(typeof(T)) != null && Enum.GetValues(typeof(T)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(T)).Length; i++)
                    {
                        //listItems.Add(new U() { properties[0].Name = NameEnumeration = Enum.GetName(typeof(T), i) });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}