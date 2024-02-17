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
        /// <summary>
        /// The constructor of Service database engine.
        /// </summary>
        public ServiceDatabaseEngine() { }

        public List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine()
        {
            List<DatabasesEngine> listItems = new List<DatabasesEngine>();

            try
            {
                if (Enum.GetValues(typeof(EnumDatabasesEngine)) != null && Enum.GetValues(typeof(EnumDatabasesEngine)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumDatabasesEngine)).Length; i++)
                    {
                        listItems.Add(new DatabasesEngine() { IdEnumeration = (EnumDatabasesEngine)i, NameEnumeration = Enum.GetName(typeof(EnumDatabasesEngine), i) });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}