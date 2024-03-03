using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.ArchitecturePatterns;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service architecture patterns.
    /// </summary>
    public class ServiceArchitecturePatterns : IServiceArchitecturePatterns
    {
        private readonly IServiceFile _serviceFile;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnumerated _serviceEnumerated;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service architecture patterns.
        /// </summary>
        /// <param name="serviceFile"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnumerated"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceArchitecturePatterns(IServiceFile serviceFile,
                                           IServiceCrypto serviceCrypto,
                                           IServiceDirectory serviceDirectory,
                                           IServiceEnumerated serviceEnumerated,
                                           IServiceFuncString serviceFuncString)
        {
            _serviceFile = serviceFile;
            _serviceCrypto = serviceCrypto;
            _serviceDirectory = serviceDirectory;
            _serviceEnumerated = serviceEnumerated;
            _serviceFuncString = serviceFuncString;
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

        public void UDPSaveIdentifierToTheArchitecturePatternsFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (metadata.ArchitecturePatterns.Any())
            {
                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncrypt(Convert.ToString(metadata.ArchitecturePatterns.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdArchitecturePatterns}{FileExtension.Txt}", data);
            }
        }
    }
}