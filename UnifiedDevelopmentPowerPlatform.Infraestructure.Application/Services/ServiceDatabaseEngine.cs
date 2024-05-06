using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DatabasesEngine;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

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

    public List<DatabasesEngine> UDPPSelectParametersTheKindsOfDatabasesEngine()
    {
        List<DatabasesEngine> listItems = new List<DatabasesEngine>();

        try
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeDatabasesEngine.CallStartToTheSelectParametersTheKindsOfDatabasesEngine), _serviceFuncString.Empty);

            for (int i = 0; i < Enum.GetValues(typeof(EnumeratedDatabasesEngine)).Length; i++)
            {
                listItems.Add(new DatabasesEngine()
                {
                    Id = (long)(EnumeratedDatabasesEngine)i,
                    IdEnumeration = (EnumeratedDatabasesEngine)i,
                    NameEnumeration = Enum.GetName(typeof(EnumeratedDatabasesEngine), i),
                    Name = _serviceEnumerated.UDPPGetEnumeratedDescription((EnumeratedDatabasesEngine)i)
                });
            }

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeDatabasesEngine.SuccessToTheSelectParametersTheKindsOfDatabasesEngine), _serviceFuncString.Empty);
        }
        catch (OverflowException) { }

        return listItems;
    }

    public void UDPPSaveIdentifierToTheDatabasesEngineFromMetadata(MetadataOwner metadata)
    {
        string data = _serviceFuncString.Empty;
        string directoryConfiguration = _serviceFuncString.Empty;

        if (metadata.DatabasesEngine.Any())
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeDatabasesEngine.CallStartToTheSaveIdentifierToTheDatabasesEngineFromMetadata), _serviceFuncString.Empty);

            directoryConfiguration = _serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Configuration);
            data = _serviceCrypto.UDPPEncryptData(Convert.ToString(metadata.DatabasesEngine.FirstOrDefault().Id));
            _serviceFile.UDPPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabasesEngine}{FileExtension.Txt}", data);

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeDatabasesEngine.SuccessToTheSaveIdentifierToTheDatabasesEngineFromMetadata), _serviceFuncString.Empty);
        }
    }
}