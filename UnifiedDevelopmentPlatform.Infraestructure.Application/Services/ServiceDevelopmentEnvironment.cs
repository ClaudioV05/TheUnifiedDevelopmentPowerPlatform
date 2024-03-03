using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DevelopmentEnvironment;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service development environment.
    /// </summary>
    public class ServiceDevelopmentEnvironment : IServiceDevelopmentEnvironment
    {
        private readonly IServiceFile _serviceFile;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnumerated _serviceEnumerated;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of Service development environment.
        /// </summary>
        /// <param name="serviceFile"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnumerated"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceDevelopmentEnvironment(IServiceFile serviceFile,
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

        public void UDPSaveIdentifierToTheDevelopmentEnviromentFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (metadata.Forms.Any())
            {
                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncrypt(Convert.ToString(metadata.DevelopmentEnvironment.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdentifierTheDevelopmentEnvironment}{FileExtension.Txt}", data);
            }
        }
    }
}