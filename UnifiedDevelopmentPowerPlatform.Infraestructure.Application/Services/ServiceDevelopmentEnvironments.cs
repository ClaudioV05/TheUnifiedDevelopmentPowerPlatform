using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DevelopmentEnvironments;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

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
    private readonly IServiceDataTypeCSharp _serviceDataTypeCSharp;
    private readonly IServiceDataTypeAnsiSql _serviceDataTypeAnsiSql;

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
    /// <param name="serviceDataTypeCSharp"></param>
    /// <param name="serviceDataTypeAnsiSql"></param>
    public ServiceDevelopmentEnvironments(IServiceLog serviceLog,
                                          IServiceFile serviceFile,
                                          IServiceCrypto serviceCrypto,
                                          IServiceMessage serviceMessage,
                                          IServiceDirectory serviceDirectory,
                                          IServiceEnumerated serviceEnumerated,
                                          IServiceFuncString serviceFuncString,
                                          IServiceDataTypeCSharp serviceDataTypeCSharp,
                                          IServiceDataTypeAnsiSql serviceDataTypeAnsiSql)
    {
        _serviceLog = serviceLog;
        _serviceFile = serviceFile;
        _serviceCrypto = serviceCrypto;
        _serviceMessage = serviceMessage;
        _serviceDirectory = serviceDirectory;
        _serviceEnumerated = serviceEnumerated;
        _serviceFuncString = serviceFuncString;
        _serviceDataTypeCSharp = serviceDataTypeCSharp;
        _serviceDataTypeAnsiSql = serviceDataTypeAnsiSql;
    }

    public List<DevelopmentEnvironments> UDPPSelectParametersTheKindsOfDevelopmentEnviroment()
    {
        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment), _serviceFuncString.Empty);

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
                        Name = _serviceEnumerated.UDPPGetEnumeratedDescription((EnumeratedDevelopmentEnvironments)i)
                    });
                }
            }

            if (listItems.Any())
            {
                _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment), _serviceFuncString.Empty);
            }
        }
        catch (OverflowException) { }

        return listItems;
    }

    public void UDPPSaveIdentifierToTheDevelopmentEnviromentsFromMetadata(MetadataOwner metadata)
    {
        string data = _serviceFuncString.Empty;
        string directoryConfiguration = _serviceFuncString.Empty;

        if (metadata.DevelopmentEnvironments.Any())
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata), _serviceFuncString.Empty);

            directoryConfiguration = _serviceDirectory.UDPPObtainDirectory(DirectoryRootType.Configuration);
            data = _serviceCrypto.UDPPEncryptData(Convert.ToString(metadata.DevelopmentEnvironments.FirstOrDefault().Id));
            _serviceFile.UDPPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDevelopmentEnvironment}{FileExtension.Txt}", data);

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata), _serviceFuncString.Empty);
        }
    }

    public string UDPPGetDataTypeFromTableInScriptMetadata(string type)
    {
        string data = _serviceFuncString.Empty;
        string? returnType = _serviceFuncString.Empty;

        try
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.CallStartToTheGetDataTypeFromTableInScriptMetadata), _serviceFuncString.Empty);
            data = _serviceFile.UDPPGetDataFileFromDirectoryConfiguration(DirectoryStandard.Log, $"{FileStandard.IdDevelopmentEnvironment}{FileExtension.Txt}");
            data = _serviceCrypto.UDPPDecryptData(data);

            if (int.TryParse(data, out var idDevelopmentEnvironment))
            {
                returnType = (EnumeratedDevelopmentEnvironments)idDevelopmentEnvironment switch
                {
                    EnumeratedDevelopmentEnvironments.NotDefined => _serviceFuncString.Empty,
                    EnumeratedDevelopmentEnvironments.DelphiXe10 => _serviceFuncString.Empty,
                    EnumeratedDevelopmentEnvironments.VisualStudio => this.UDPGetDataTypeOfCSharp(type),
                    _ => _serviceFuncString.Empty
                };
            }

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.SuccessToTheGetDataTypeFromTableInScriptMetadata), _serviceFuncString.Empty);
            return returnType;
        }
        catch (Exception ex)
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.ErrorToTheGetDataTypeFromTableInScriptMetadata), ex.Message);
            return _serviceFuncString.Empty;
        }
    }

    private string UDPGetDataTypeOfCSharp(string type)
    {
        int returnValueType = 0;
        string? returnType = _serviceFuncString.Empty;

        try
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.CallStartToGetDataTypeOfCSharp), _serviceFuncString.Empty);

            returnType = _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Undefined);

            if (!_serviceFuncString.UDPPNullOrEmpty(type))
            {
                returnValueType = _serviceDataTypeAnsiSql.UDPPReturnIndexFromTheListOfDataTypes(type);

                if (returnValueType != -1)
                {
                    if (_serviceDataTypeAnsiSql.UDPPByIndexEnumTypeIsDefined(returnValueType))
                    {
                        returnType = _serviceDataTypeAnsiSql.UDPPGetAsEnumeratedTheEnumType(returnValueType) switch
                        {
                            AnsiSql.DataType.Varchar => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.String),
                            AnsiSql.DataType.Char => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Char),
                            AnsiSql.DataType.Smallint => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Int),
                            AnsiSql.DataType.Integer => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Int),
                            AnsiSql.DataType.Decimal => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Decimal),
                            AnsiSql.DataType.Float => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Float),
                            AnsiSql.DataType.DoublePrecision => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Double),
                            AnsiSql.DataType.Real => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Double),
                            AnsiSql.DataType.Timestamp => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.DateTime),
                            _ => _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Undefined)
                        };
                    }
                }
            }

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.SuccessToGetDataTypeOfCSharp), _serviceFuncString.Empty);
            return _serviceFuncString.UDPPLower(returnType);
        }
        catch (Exception ex)
        {
            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.ErrorToGetDataTypeOfCSharp), ex.Message);
            return _serviceDataTypeCSharp.UDPPGetAsStringTheEnumType(CSharp.DataType.Undefined);
        }
    }
}