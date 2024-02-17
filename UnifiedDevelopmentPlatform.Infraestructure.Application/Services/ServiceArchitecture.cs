using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Architectures;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service architecture.
    /// </summary>
    public class ServiceArchitecture : IServiceArchitecture
    {
        /// <summary>
        /// The constructor of Service Architecture.
        /// </summary>
        public ServiceArchitecture() { }

        public List<Architectures> UDPSelectParametersTheKindsOfArchitectures()
        {
            List<Architectures> listItems = new List<Architectures>();

            try
            {
                if (Enum.GetValues(typeof(EnumArchitecture)) != null && Enum.GetValues(typeof(EnumArchitecture)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumArchitecture)).Length; i++)
                    {
                        listItems.Add(new Architectures() { IdEnumeration = (EnumArchitecture)i, NameEnumeration = Enum.GetName(typeof(EnumArchitecture), i) });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}