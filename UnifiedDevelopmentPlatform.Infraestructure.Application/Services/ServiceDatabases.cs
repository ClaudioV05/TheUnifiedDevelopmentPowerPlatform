using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Databases;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service databases.
    /// </summary>
    public class ServiceDatabases : IServiceDatabases
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnumerated _serviceEnumerated;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service databases.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceFile"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnumerated"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceDatabases(IServiceLog serviceLog,
                                IServiceFile serviceFile,
                                IServiceCrypto serviceCrypto,
                                IServiceMessage serviceMessage,
                                IServiceDirectory serviceDirectory,
                                IServiceEnumerated serviceEnumerated,
                                IServiceFuncString serviceFuncString)
        {
            _serviceLog = serviceLog;
            _serviceFile = serviceFile;
            _serviceCrypto = serviceCrypto;
            _serviceMessage = serviceMessage;
            _serviceDirectory = serviceDirectory;
            _serviceEnumerated = serviceEnumerated;
            _serviceFuncString = serviceFuncString;
        }

        public List<Databases> UDPSelectParametersTheKindsOfDatabases()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfDatabases), _serviceFuncString.Empty);

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

                if (listItems.Any())
                {
                    _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheSelectParametersTheKindsOfDatabases), _serviceFuncString.Empty);
                }
            }
            catch (OverflowException) { }

            return listItems;
        }

        public void UDPSaveIdentifierToTheDatabasesFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (metadata.Databases.Any())
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSaveIdentifierToTheDatabasesFromMetadata), _serviceFuncString.Empty);

                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncrypt(Convert.ToString(metadata.Databases.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabases}{FileExtension.Txt}", data);

                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheSaveIdentifierToTheDatabasesFromMetadata), _serviceFuncString.Empty);
            }
        }
    }
}