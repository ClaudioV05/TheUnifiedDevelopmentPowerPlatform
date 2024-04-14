using System.Xml.Linq;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.DataTypes;
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

        public string UDPGetDataTypeOfCSharp(string type)
        {
            int returnValueType = 0;
            string? returnType = _serviceFuncString.Empty;

            try
            {
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

                return _serviceFuncString.UDPLower(returnType);
            }
            catch (Exception)
            {
                return _serviceDataTypeCSharp.UDPGetAsStringTheEnumType(CSharp.DataType.Undefined);
            }
        }
    }
}

/*
    string ReturnAsStringTheDataType(string type) => "ddd";
    string ReturnTheListOfDataTypes() => "ddd";

    string CallStartToGetTheDataTypeOfFieldInScriptMetadata = "CALL START TO GET THE DATA TYPE OF FIELD IN SCRIPT METADATA.";
    string ErrorToGetTheDataTypeOfFieldInScriptMetadata = "ERROR TO GET THE DATA TYPE OF FIELD IN SCRIPT METADATA.";
    string SuccessToGetTheDataTypeOfFieldInScriptMetadata = "SUCCESS TO GET THE DATA TYPE OF FIELD IN SCRIPT METADATA.";

    string CallStartToReturnTheListOfAnsiSqlDataTypes = "CALL START TO RETURN THE LIST OF ANSI SQL DATA TYPES.";
    string SuccessToReturnTheListOfAnsiSqlDataTypes = "SUCCESS TO RETURN THE LIST OF ANSI SQL DATA TYPES.";

    string CallStartToReturnTheListOfPascalDataTypes = "CALL START TO RETURN THE LIST OF PASCAL DATA TYPES.";
    string SuccessToReturnTheListOfPascalDataTypes = "SUCCESS TO RETURN THE LIST OF PASCAL DATA TYPES.";

    string CallStartToReturnTheListOfDotNetDataTypes = "CALL START TO RETURN THE LIST OF DOT NET DATA TYPES.";
    string SuccessToReturnTheListOfDotNetDataTypes = "SUCCESS TO RETURN THE LIST OF DOT NET DATA TYPES.";

    string CallStartToReturnTheListOfSqlServerDataTypes = "CALL START TO RETURN THE LIST OF SQL SERVER DATA TYPES.";
    string SuccessToReturnTheListOfSqlServerDataTypes = "SUCCESS TO RETURN THE LIST OF SQL SERVER DATA TYPES.";

    bool HasLenghtInDataType() => true;
    int ReturnTheLenghtOfDataType() => 0;

    string CallStartToReturnTheLenghtOfDataType = "CALL START TO RETURN THE LENGHT OF DATA TYPE.";
    string SuccessToReturnTheLenghtOfDataType = "SUCCESS TO RETURN THE LENGHT OF DATA TYPE.";

    string CallStartToHasLenghtInDataType = "CALL START TO HAS LENGHT IN DATA TYPE.";
    string SuccessToHasLenghtInDataType = "SUCCESS TO HAS LENGHT IN DATA TYPE.";
*/