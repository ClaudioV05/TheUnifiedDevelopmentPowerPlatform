using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DevelopmentEnvironments;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service development environments.
    /// </summary>
    public class ServiceDevelopmentEnvironments : IServiceDevelopmentEnvironments
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnumerated _serviceEnumerated;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service development environments.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceFile"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnumerated"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceDevelopmentEnvironments(IServiceLog serviceLog,
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

        public List<DevelopmentEnvironments> UDPSelectParametersTheKindsOfDevelopmentEnviroment()
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment), _serviceFuncString.Empty);

            List<DevelopmentEnvironments> listItems = new List<DevelopmentEnvironments>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedDevelopmentEnvironments)) != null && Enum.GetValues(typeof(EnumeratedDevelopmentEnvironments)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedDevelopmentEnvironments)).Length; i++)
                    {
                        listItems.Add(new DevelopmentEnvironments()
                        {
                            Id = (long)(EnumeratedDevelopmentEnvironments)i,
                            IdEnumeration = (EnumeratedDevelopmentEnvironments)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedDevelopmentEnvironments), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedDevelopmentEnvironments)i)
                        });
                    }
                }

                if (listItems.Any())
                {
                    _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment), _serviceFuncString.Empty);
                }
            }
            catch (OverflowException) { }

            return listItems;
        }

        public void UDPSaveIdentifierToTheDevelopmentEnviromentsFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (metadata.DevelopmentEnvironments.Any())
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata), _serviceFuncString.Empty);

                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncrypt(Convert.ToString(metadata.DevelopmentEnvironments.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDevelopmentEnvironment}{FileExtension.Txt}", data);

                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata), _serviceFuncString.Empty);
            }
        }

        static string Main(string type)
        {
            string message;
            // create object type.

            return type switch
            {
                "integer" => System.Data.DbType.Int32.ToString(),
                "double" => System.Data.DbType.Double.ToString(),
                "date" => System.Data.DbType.Date.ToString(),
                "time" => System.Data.DbType.Time.ToString(),
                "varchar" => System.Data.DbType.String.ToString()
            };
        }
    }
}