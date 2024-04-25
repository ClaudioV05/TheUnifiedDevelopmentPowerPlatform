using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.FormsView;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
{
    /// <summary>
    /// Service forms view.
    /// </summary>
    public class ServiceFormsView : IServiceFormsView
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnumerated _serviceEnumerated;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service forms view.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceFile"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnumerated"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceFormsView(IServiceLog serviceLog,
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

        public List<FormsView> UDPSelectParametersTheKindsOfFormsView()
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeFormsView.CallStartToTheSelectParametersTheKindsOfForms), _serviceFuncString.Empty);

            List<FormsView> listItems = new List<FormsView>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedFormsView)) != null && Enum.GetValues(typeof(EnumeratedFormsView)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedFormsView)).Length; i++)
                    {
                        listItems.Add(new FormsView()
                        {
                            Id = (long)(EnumeratedFormsView)i,
                            IdEnumeration = (EnumeratedFormsView)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedFormsView), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedFormsView)i)
                        });
                    }
                }

                if (listItems.Any())
                {
                    _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeFormsView.SuccessToTheSelectParametersTheKindsOfForms), _serviceFuncString.Empty);
                }
            }
            catch (OverflowException) { }

            return listItems;
        }

        public void UDPSaveIdentifierToTheFormsViewFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (metadata.FormsView.Any())
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeFormsView.CallStartToTheSaveIdentifierToTheFormFromMetadata), _serviceFuncString.Empty);

                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncryptData(Convert.ToString(metadata.FormsView.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdForm}{FileExtension.Txt}", data);

                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeFormsView.SuccessToTheSaveIdentifierToTheFormFromMetadata), _serviceFuncString.Empty);
            }
        }
    }
}