using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory.DomainDrivenDesign;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DevelopmentEnvironments;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
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

        public List<DevelopmentEnvironments> UDPSelectParametersTheKindsOfDevelopmentEnviroment()
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.CallStartToTheSelectParametersTheKindsOfDevelopmentEnviroment), _serviceFuncString.Empty);

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
                    _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.SuccessToTheSelectParametersTheKindsOfDevelopmentEnviroment), _serviceFuncString.Empty);
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
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.CallStartToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata), _serviceFuncString.Empty);

                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncryptData(Convert.ToString(metadata.DevelopmentEnvironments.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDevelopmentEnvironment}{FileExtension.Txt}", data);

                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.SuccessToTheSaveIdentifierToTheDevelopmentEnviromentsFromMetadata), _serviceFuncString.Empty);
            }
        }

        public string UDPGetDataTypeFromTableInScriptMetadata(string type)
        {
            int idDevelopmentEnvironment = 0;
            string data = _serviceFuncString.Empty;
            string? returnType = _serviceFuncString.Empty;

            try
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.CallStartToTheGetDataTypeFromTableInScriptMetadata), _serviceFuncString.Empty);
                data = _serviceFile.UDPGetDataFileFromDirectoryConfiguration(DirectoryStandard.Log, $"{FileStandard.IdDevelopmentEnvironment}{FileExtension.Txt}");
                data = _serviceCrypto.UPDDecryptData(data);

                if (int.TryParse(data, out idDevelopmentEnvironment))
                {
                    returnType = (EnumeratedDevelopmentEnvironments)idDevelopmentEnvironment switch
                    {
                        EnumeratedDevelopmentEnvironments.NotDefined => _serviceFuncString.Empty,
                        EnumeratedDevelopmentEnvironments.DelphiXe10 => _serviceFuncString.Empty,
                        EnumeratedDevelopmentEnvironments.VisualStudio => this.UDPGetDataTypeOfCSharp(type),
                        _ => _serviceFuncString.Empty
                    };
                }

                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.SuccessToTheGetDataTypeFromTableInScriptMetadata), _serviceFuncString.Empty);
                return returnType;
            }
            catch (Exception ex)
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.ErrorToTheGetDataTypeFromTableInScriptMetadata), ex.Message);
                return _serviceFuncString.Empty;
            }
        }

        private string UDPGetDataTypeOfCSharp(string type)
        {
            int returnValueType = 0;
            string? returnType = _serviceFuncString.Empty;

            try
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.CallStartToGetDataTypeOfCSharp), _serviceFuncString.Empty);

                returnType = _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Undefined);

                if (!_serviceFuncString.UDPNullOrEmpty(type))
                {
                    returnValueType = _serviceDataTypeAnsiSql.UDPReturnIndexFromTheListOfDataTypes(type);

                    if (returnValueType != -1)
                    {
                        if (_serviceDataTypeAnsiSql.UDPByIndexEnumTypeIsDefined(returnValueType))
                        {
                            returnType = _serviceDataTypeAnsiSql.UDPGetAsEnumeratedTheEnumType(returnValueType) switch
                            {
                                AnsiSql.DataType.Varchar => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.String),
                                AnsiSql.DataType.Char => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Char),
                                AnsiSql.DataType.Smallint => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Int),
                                AnsiSql.DataType.Integer => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Int),
                                AnsiSql.DataType.Decimal => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Decimal),
                                AnsiSql.DataType.Float => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Float),
                                AnsiSql.DataType.DoublePrecision => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Double),
                                AnsiSql.DataType.Real => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Double),
                                AnsiSql.DataType.Timestamp => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.DateTime),
                                _ => _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Undefined)
                            };
                        }
                    }
                }

                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.SuccessToGetDataTypeOfCSharp), _serviceFuncString.Empty);
                return _serviceFuncString.UDPLower(returnType);
            }
            catch (Exception ex)
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDevelopmentEnvironments.ErrorToGetDataTypeOfCSharp), ex.Message);
                return _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Undefined);
            }
        }
    }
}