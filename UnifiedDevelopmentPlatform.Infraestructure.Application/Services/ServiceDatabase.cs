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
        private readonly IServiceLinq _serviceLinq;

        /// <summary>
        /// The constructor of Service database.
        /// </summary>
        public ServiceDatabase(IServiceLinq serviceLinq)
        {
            _serviceLinq = serviceLinq;
        }

        public List<Databases> UDPObtainTheListOfDatabases()
        {
            List<Databases> listItems = new List<Databases>();

            try
            {
                if (Enum.GetValues(typeof(EnumDatabases)) != null && Enum.GetValues(typeof(EnumDatabases)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumDatabases)).Length; i++)
                    {
                        listItems.Add(new Databases() { IdEnumeration = (EnumDatabases)i, NameEnumeration = Enum.GetName(typeof(EnumDatabases), i) });
                    }

                    listItems = _serviceLinq.UDPOrderBy(listItems);
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}