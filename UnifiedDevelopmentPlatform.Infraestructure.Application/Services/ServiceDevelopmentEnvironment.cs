using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DevelopmentEnvironment;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service development environment.
    /// </summary>
    public class ServiceDevelopmentEnvironment : IServiceDevelopmentEnvironment
    {
        /// <summary>
        /// The constructor of Service development environment.
        /// </summary>
        public ServiceDevelopmentEnvironment() { }

        public List<DevelopmentEnvironment> UDPSelectParametersTheKindsOfDevelopmentEnviroment()
        {
            List<DevelopmentEnvironment> listItems = new List<DevelopmentEnvironment>();

            try
            {
                if (Enum.GetValues(typeof(EnumDevelopmentEnvironment)) != null && Enum.GetValues(typeof(EnumDevelopmentEnvironment)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumDevelopmentEnvironment)).Length; i++)
                    {
                        listItems.Add(new DevelopmentEnvironment() { IdEnumeration = (EnumDevelopmentEnvironment)i, NameEnumeration = Enum.GetName(typeof(EnumDevelopmentEnvironment), i) });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}