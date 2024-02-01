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

        /// <summary>
        /// The constructor of Service database.
        /// </summary>
        public ServiceDatabase()
        {

        }

        public List<Databases> DatabasesList()
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

                    listItems = listItems.OrderBy(item => item.IdEnumeration).ToList();
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}