using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.File;
using static UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Forms;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service forms.
    /// </summary>
    public class ServiceForm : IServiceForm
    {
        private readonly IServiceFile _serviceFile;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnumerated _serviceEnumerated;
        private readonly IServiceFuncString _serviceFuncString;

        /// <summary>
        /// The constructor of service form.
        /// </summary>
        /// <param name="serviceFile"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnumerated"></param>
        /// <param name="serviceFuncString"></param>
        public ServiceForm(IServiceFile serviceFile, 
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

        public List<Forms> UDPSelectParametersTheKindsOfForms()
        {
            List<Forms> listItems = new List<Forms>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedForm)) != null && Enum.GetValues(typeof(EnumeratedForm)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedForm)).Length; i++)
                    {
                        listItems.Add(new Forms()
                        {
                            Id = (long)(EnumeratedForm)i,
                            IdEnumeration = (EnumeratedForm)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedForm), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedForm)i)
                        });
                    }
                }
            }
            catch (OverflowException) { }

            return listItems;
        }

        public void UDPSaveIdentifierToTheFormFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (metadata.Forms.Any())
            {
                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncrypt(Convert.ToString(metadata.Forms.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdentifierTheForm}{FileExtension.Txt}", data);
            }
        }
    }
}