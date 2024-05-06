using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.ArchitecturePatterns;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service architecture patterns.
/// </summary>
public class ServiceArchitecturePatterns : IServiceArchitecturePatterns
{
    private readonly List<string> _aux;
    private readonly IServiceLog _serviceLog;
    private readonly IServiceFile _serviceFile;
    private readonly IServiceCrypto _serviceCrypto;
    private readonly IServiceMessage _serviceMessage;
    private readonly IServicePlataform _servicePlataform;
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
                                       IServicePlataform servicePlataform,
                                       IServiceDirectory serviceDirectory,
                                       IServiceEnumerated serviceEnumerated,
                                       IServiceFuncString serviceFuncString)
    {
        _aux = new List<string>();
        _serviceLog = serviceLog;
        _serviceFile = serviceFile;
        _serviceCrypto = serviceCrypto;
        _serviceMessage = serviceMessage;
        _servicePlataform = servicePlataform;
        _serviceDirectory = serviceDirectory;
        _serviceEnumerated = serviceEnumerated;
        _serviceFuncString = serviceFuncString;
    }

    public List<ArchitecturePatterns> UDPPToSelectParametersTheKindsOfArchitecturePatterns()
    {
        List<ArchitecturePatterns> listItems = new List<ArchitecturePatterns>();

        try
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeArchitecturePatterns.CallStartToTheSelectParametersTheKindsOfArchitecturePatterns), _serviceFuncString.Empty);

            for (int i = 0; i < Enum.GetValues(typeof(EnumeratedArchitecturePatterns)).Length; i++)
            {
                listItems.Add(new ArchitecturePatterns()
                {
                    Id = (long)(EnumeratedArchitecturePatterns)i,
                    IdEnumeration = (EnumeratedArchitecturePatterns)i,
                    NameEnumeration = Enum.GetName(typeof(EnumeratedArchitecturePatterns), i),
                    Name = _serviceEnumerated.UDPPGetEnumeratedDescription((EnumeratedArchitecturePatterns)i)
                });
            }

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeArchitecturePatterns.SuccessToTheSelectParametersTheKindsOfArchitecturePatterns), _serviceFuncString.Empty);
        }
        catch (OverflowException) { }

        return listItems;
    }

    public void UDPPToSaveIdentifierToTheArchitecturePatternsFromMetadata(MetadataOwner metadata)
    {
        string data = _serviceFuncString.Empty;
        string directoryConfiguration = _serviceFuncString.Empty;

        if (metadata.ArchitecturePatterns.Any())
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeArchitecturePatterns.CallStartToTheSaveIdentifierToTheArchitecturePatternsFromMetadata), _serviceFuncString.Empty);

            directoryConfiguration = _serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Configuration);
            data = _serviceCrypto.UDPPEncryptData(Convert.ToString(metadata.ArchitecturePatterns.FirstOrDefault().Id));
            _serviceFile.UDPPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdArchitecturePatterns}{FileExtension.Txt}", data);

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPPGetMessage(TypeArchitecturePatterns.SuccessToTheSaveIdentifierToTheArchitecturePatternsFromMetadata), _serviceFuncString.Empty);
        }
    }

    public EnumeratedArchitecturePatterns UDPPToReadIdentifierToTheArchitecturePatternsFromMetadata()
    {
        string data = _serviceFile.UDPPGetDataFileFromDirectoryConfiguration(DirectoryStandard.Log, $"{FileStandard.IdArchitecturePatterns}{FileExtension.Txt}");
        data = _serviceCrypto.UDPPDecryptData(data);
        return int.TryParse(data, out var idArchitecturePatterns) ? (EnumeratedArchitecturePatterns)idArchitecturePatterns : EnumeratedArchitecturePatterns.NotDefined;
    }

    public void UDPPGeneratesBackendSolution(List<Tables> tables)
    {
        try
        {
            if (_serviceDirectory.UDPPDirectoryExists(_serviceDirectory.UDPPObtainDirectory(DirectoryRootType.App)))
            {
                if (_serviceDirectory.UDPPDirectoryExists(_serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Backend)))
                {
                    var enumeratedArchitecturePatterns = UDPPToReadIdentifierToTheArchitecturePatternsFromMetadata();

                    switch (enumeratedArchitecturePatterns)
                    {
                        case EnumeratedArchitecturePatterns.Ddd:

                            if( this.UDPPGeneratesDomainDrivenDesignBackendSolution())
                            {
                                if (this.UDPPGeneratesDomainDrivenDesignBackendProjectPresentation())
                                {
                                    if (this.UDPPGeneratesDomainDrivenDesignBackendProjectApplication())
                                    {
                                        if (this.UDPPGeneratesDomainDrivenDesignBackendProjectDomain())
                                        {
                                            if (this.UDPPGeneratesDomainDrivenDesignBackendProjectInfrastructure())
                                            {

                                            }
                                        }
                                    }
                                }
                            }

                            break;
                    }
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UDPPGeneratesFrontendSolution(List<Tables> tables)
    {
        try
        {
            if (_serviceDirectory.UDPPDirectoryExists(_serviceDirectory.UDPPObtainDirectory(DirectoryRootType.App)))
            {
                if (_serviceDirectory.UDPPDirectoryExists(_serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Frontend)))
                {
                    // Code here.
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    #region Backend solution private methods.

    private bool UDPPGeneratesDomainDrivenDesignBackendSolution()
    {
        try
        {
            string file = _serviceFile.UDPPToCreateDataFile(DirectoryRootType.Backend, $"{MetaCharacterSymbols.Backslash}{FileSolution.App}{FileExtension.Sln}");

            _aux.Clear();
            _aux.Add("test");
            _serviceFile.UDPPAppendAllText(file, _serviceFuncString.UDPPJoin(_servicePlataform.UDPPEnvironmentAddNewLine(), [.. _aux]));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool UDPPGeneratesDomainDrivenDesignBackendProjectPresentation()
    {
        try
        {
            string file = _serviceFile.UDPPToCreateDataFile(DirectoryRootType.Backend, $"{MetaCharacterSymbols.Backslash}{FileSolution.App}{FileExtension.Sln}");

            _aux.Clear();
            _aux.Add("test");
            _serviceFile.UDPPAppendAllText(file, _serviceFuncString.UDPPJoin(_servicePlataform.UDPPEnvironmentAddNewLine(), [.. _aux]));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool UDPPGeneratesDomainDrivenDesignBackendProjectApplication()
    {
        try
        {
            string file = _serviceFile.UDPPToCreateDataFile(DirectoryRootType.Backend, $"{MetaCharacterSymbols.Backslash}{FileSolution.App}{FileExtension.Sln}");

            _aux.Clear();
            _aux.Add("test");
            _serviceFile.UDPPAppendAllText(file, _serviceFuncString.UDPPJoin(_servicePlataform.UDPPEnvironmentAddNewLine(), [.. _aux]));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool UDPPGeneratesDomainDrivenDesignBackendProjectDomain()
    {
        try
        {
            string file = _serviceFile.UDPPToCreateDataFile(DirectoryRootType.Backend, $"{MetaCharacterSymbols.Backslash}{FileSolution.App}{FileExtension.Sln}");

            _aux.Clear();
            _aux.Add("test");
            _serviceFile.UDPPAppendAllText(file, _serviceFuncString.UDPPJoin(_servicePlataform.UDPPEnvironmentAddNewLine(), [.. _aux]));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool UDPPGeneratesDomainDrivenDesignBackendProjectInfrastructure()
    {
        try
        {
            string file = _serviceFile.UDPPToCreateDataFile(DirectoryRootType.Backend, $"{MetaCharacterSymbols.Backslash}{FileSolution.App}{FileExtension.Sln}");

            _aux.Clear();
            _aux.Add("test");
            _serviceFile.UDPPAppendAllText(file, _serviceFuncString.UDPPJoin(_servicePlataform.UDPPEnvironmentAddNewLine(), [.. _aux]));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    #endregion Backend solution private methods.

    #region Frontend solution private methods.

    #endregion Frontend solution private methods.
}