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
        private readonly IServiceEnumerated _serviceEnumerated;

        /// <summary>
        /// The constructor of Service development environment.
        /// </summary>
        /// <param name="serviceEnumerated"></param>
        public ServiceDevelopmentEnvironment(IServiceEnumerated serviceEnumerated)
        {
            _serviceEnumerated = serviceEnumerated;
        }

        public List<DevelopmentEnvironment> UDPSelectParametersTheKindsOfDevelopmentEnviroment()
        {
            List<DevelopmentEnvironment> listItems = new List<DevelopmentEnvironment>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedDevelopmentEnvironment)) != null && Enum.GetValues(typeof(EnumeratedDevelopmentEnvironment)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedDevelopmentEnvironment)).Length; i++)
                    {
                        listItems.Add(new DevelopmentEnvironment()
                        { 
                            Id = (long)(EnumeratedDevelopmentEnvironment)i,
                            IdEnumeration = (EnumeratedDevelopmentEnvironment)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedDevelopmentEnvironment), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedDevelopmentEnvironment)i)
                        });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}