using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DatabasesEngine;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service database engine.
    /// </summary>
    public class ServiceDatabaseEngine : IServiceDatabaseEngine
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnumerated _serviceEnumerated;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service databases engine.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceFile"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnumerated"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceDatabaseEngine(IServiceLog serviceLog,
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

        public List<DatabasesEngine> UDPSelectParametersTheKindsOfDatabasesEngine()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfDatabasesEngine), _serviceFuncString.Empty);

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

                if (listItems.Any())
                {
                    _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheSelectParametersTheKindsOfDatabasesEngine), _serviceFuncString.Empty);
                }
            }
            catch (OverflowException) { }

            return listItems;
        }

        public void UDPSaveIdentifierToTheDatabasesEngineFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (metadata.DatabasesEngine.Any())
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata), _serviceFuncString.Empty);

                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncrypt(Convert.ToString(metadata.DatabasesEngine.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabasesEngine}{FileExtension.Txt}", data);

                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata), _serviceFuncString.Empty);
            }
        }
    }
}