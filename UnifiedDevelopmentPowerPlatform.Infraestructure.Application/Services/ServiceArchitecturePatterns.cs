using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.ArchitecturePatterns;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service architecture patterns.
/// </summary>
public class ServiceArchitecturePatterns : IServiceArchitecturePatterns
{
    private readonly IServiceLog _serviceLog;
    private readonly IServiceFile _serviceFile;
    private readonly IServiceCrypto _serviceCrypto;
    private readonly IServiceMessage _serviceMessage;
    private readonly IServiceDirectory _serviceDirectory;
    private readonly IServiceEnumerated _serviceEnumerated;
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// The constructor of service architecture patterns.
    /// </summary>
    /// <param name="serviceLog"></param>
    /// <param name="serviceFile"></param>
    /// <param name="serviceCrypto"></param>
    /// <param name="serviceMessage"></param>
    /// <param name="serviceDirectory"></param>
    /// <param name="serviceEnumerated"></param>
    /// <param name="serviceFuncString"></param>
    public ServiceArchitecturePatterns(IServiceLog serviceLog,
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

    public List<ArchitecturePatterns> UDPToSelectParametersTheKindsOfArchitecturePatterns()
    {
        _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeArchitecturePatterns.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns), _serviceFuncString.Empty);

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

            if (listItems.Any())
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeArchitecturePatterns.SuccessToTheSelectParametersTheKindsOfArchitecturePatterns), _serviceFuncString.Empty);
            }
        }
        catch (OverflowException) { }

        return listItems;
    }

    public void UDPToSaveIdentifierToTheArchitecturePatternsFromMetadata(MetadataOwner metadata)
    {
        string data = _serviceFuncString.Empty;
        string directoryConfiguration = _serviceFuncString.Empty;

        if (metadata.ArchitecturePatterns.Any())
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeArchitecturePatterns.CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata), _serviceFuncString.Empty);

            directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
            data = _serviceCrypto.UPDEncryptData(Convert.ToString(metadata.ArchitecturePatterns.FirstOrDefault().Id));
            _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdArchitecturePatterns}{FileExtension.Txt}", data);

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeArchitecturePatterns.SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata), _serviceFuncString.Empty);
        }
    }

    public EnumeratedArchitecturePatterns UDPToReadIdentifierToTheArchitecturePatternsFromMetadata()
    {
        string data = _serviceFile.UDPGetDataFileFromDirectoryConfiguration(DirectoryStandard.Log, $"{FileStandard.IdArchitecturePatterns}{FileExtension.Txt}");
        data = _serviceCrypto.UPDDecryptData(data);
        return int.TryParse(data, out var idArchitecturePatterns) ? (EnumeratedArchitecturePatterns)idArchitecturePatterns : EnumeratedArchitecturePatterns.NotDefined;
    }

    public void UDPGenerateBackendProject(List<Tables> tables)
    {
        throw new NotImplementedException();
    }

    public void UDPGenerateFrontEndProject(List<Tables> tables)
    {
        throw new NotImplementedException();
    }
}