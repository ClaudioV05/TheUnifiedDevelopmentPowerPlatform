using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Databases;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service database.
    /// </summary>
    public class ServiceDatabase : IServiceDatabase
    {
        private readonly IServiceEnumerated _serviceEnumerated;

        /// <summary>
        /// The constructor of Service database.
        /// </summary>
        /// <param name="serviceEnumerated"></param>
        public ServiceDatabase(IServiceEnumerated serviceEnumerated)
        {
            _serviceEnumerated = serviceEnumerated;
        }

        public List<Databases> UDPSelectParametersTheKindsOfDatabases()
        {
            List<Databases> listItems = new List<Databases>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedDatabases)) != null && Enum.GetValues(typeof(EnumeratedDatabases)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedDatabases)).Length; i++)
                    {
                        listItems.Add(new Databases()
                        {
                            Id = (long)(EnumeratedDatabases)i,
                            IdEnumeration = (EnumeratedDatabases)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedDatabases), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedDatabases)i)
                        });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}