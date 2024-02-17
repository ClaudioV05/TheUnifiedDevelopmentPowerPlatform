using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.ArchitecturePatterns;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service architecture patterns.
    /// </summary>
    public class ServiceArchitecturePatterns : IServiceArchitecturePatterns
    {
        private readonly IServiceEnumerated _serviceEnumerated;

        /// <summary>
        /// The constructor of Service architecture patterns.
        /// </summary>
        /// <param name="serviceEnumerated"></param>
        public ServiceArchitecturePatterns(IServiceEnumerated serviceEnumerated)
        {
            _serviceEnumerated = serviceEnumerated;
        }

        public List<ArchitecturePatterns> UDPSelectParametersTheKindsOfArchitecturePatterns()
        {
            List<ArchitecturePatterns> listItems = new List<ArchitecturePatterns>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedArchitecturePatterns)) != null && Enum.GetValues(typeof(EnumeratedArchitecturePatterns)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedArchitecturePatterns)).Length; i++)
                    {
                        listItems.Add(new ArchitecturePatterns()
                        {
                            Id = (long)(EnumeratedArchitecturePatterns)i,
                            IdEnumeration = (EnumeratedArchitecturePatterns)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedArchitecturePatterns), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedArchitecturePatterns)i)
                        });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }
    }
}