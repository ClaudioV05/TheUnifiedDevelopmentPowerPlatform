using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DatabasesEngine;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service database engine.
    /// </summary>
    public class ServiceDatabaseEngine : IServiceDatabaseEngine
    {
        private readonly IServiceEnumerated _serviceEnumerated;

        /// <summary>
        /// The constructor of Service database engine.
        /// </summary>
        /// <param name="serviceEnumerated"></param>
        public ServiceDatabaseEngine(IServiceEnumerated serviceEnumerated)
        {
            _serviceEnumerated = serviceEnumerated;
        }

        public List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine()
        {
            List<DatabasesEngine> listItems = new List<DatabasesEngine>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedDatabasesEngine)) != null && Enum.GetValues(typeof(EnumeratedDatabasesEngine)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedDatabasesEngine)).Length; i++)
                    {
                        listItems.Add(new DatabasesEngine()
                        {
                            Id = (long)(EnumeratedDatabasesEngine)i,
                            IdEnumeration = (EnumeratedDatabasesEngine)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedDatabasesEngine), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedDatabasesEngine)i)
                        });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}