﻿using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.File;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using static UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Databases;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
{
    /// <summary>
    /// Service databases.
    /// </summary>
    public class ServiceDatabases : IServiceDatabases
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceCrypto _serviceCrypto;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceDirectory _serviceDirectory;
        private readonly IServiceEnumerated _serviceEnumerated;
        private readonly IServiceFuncString _serviceFuncString;
        private readonly IServiceMetadataField _serviceMetadataField;

        /// <summary>
        /// The constructor of service databases.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceFile"></param>
        /// <param name="serviceCrypto"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceDirectory"></param>
        /// <param name="serviceEnumerated"></param>
        /// <param name="serviceFuncString"></param>
        /// <param name="serviceMetadataField"></param>
        public ServiceDatabases(IServiceLog serviceLog,
                                IServiceFile serviceFile,
                                IServiceCrypto serviceCrypto,
                                IServiceMessage serviceMessage,
                                IServiceDirectory serviceDirectory,
                                IServiceEnumerated serviceEnumerated,
                                IServiceFuncString serviceFuncString,
                                IServiceMetadataField serviceMetadataField)
        {
            _serviceLog = serviceLog;
            _serviceFile = serviceFile;
            _serviceCrypto = serviceCrypto;
            _serviceMessage = serviceMessage;
            _serviceDirectory = serviceDirectory;
            _serviceEnumerated = serviceEnumerated;
            _serviceFuncString = serviceFuncString;
            _serviceMetadataField = serviceMetadataField;
        }

        public List<Databases> UDPSelectParametersTheKindsOfDatabases()
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDatabases.CallStartToTheSelectParametersTheKindsOfDatabases), _serviceFuncString.Empty);

            List<Databases> listItems = new List<Databases>();

            try
            {
                if (Enum.GetValues(typeof(EnumeratedDatabases)) != null && Enum.GetValues(typeof(EnumeratedDatabases)).Length > 0)
                {
                    for (int i = 0; i < Enum.GetValues(typeof(EnumeratedDatabases)).Length; i++)
                    {
                        listItems.Add(new Databases()
                        {
                            Id = (long)(EnumeratedDatabases)i,
                            IdEnumeration = (EnumeratedDatabases)i,
                            NameEnumeration = Enum.GetName(typeof(EnumeratedDatabases), i),
                            Name = _serviceEnumerated.UDPGetEnumeratedDescription((EnumeratedDatabases)i)
                        });
                    }
                }

                if (listItems.Any())
                {
                    _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDatabases.SuccessToTheSelectParametersTheKindsOfDatabases), _serviceFuncString.Empty);
                }
            }
            catch (OverflowException) { }

            return listItems;
        }

        public void UDPSaveIdentifierToTheDatabasesFromMetadata(MetadataOwner metadata)
        {
            string data = _serviceFuncString.Empty;
            string directoryConfiguration = _serviceFuncString.Empty;

            if (metadata.Databases.Any())
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDatabases.CallStartToTheSaveIdentifierToTheDatabasesFromMetadata), _serviceFuncString.Empty);

                directoryConfiguration = _serviceDirectory.UDPObtainDirectory(DirectoryRootType.Configuration);
                data = _serviceCrypto.UPDEncryptData(Convert.ToString(metadata.Databases.FirstOrDefault().Id));
                _serviceFile.UDPAppendAllText($"{directoryConfiguration}{DirectoryStandard.Log}{FileStandard.IdDatabases}{FileExtension.Txt}", data);

                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDatabases.SuccessToTheSaveIdentifierToTheDatabasesFromMetadata), _serviceFuncString.Empty);
            }
        }

        public void UDPSaveMetricsOfTheGenerationOfTablesAndFields(List<Tables> listOfTables)
        {
            long quantityOfTables = 0;

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataTable.CallStartToTheSaveMetricsOfTheGenerationOfTablesAndFields), _serviceFuncString.Empty);

            if (listOfTables is not null && listOfTables.Any())
            {
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDatabases.TheMetricsOfQuantitiesOfTables), Convert.ToString(this.UDPGetMetricsOfQuantitiesOfTables(listOfTables)));
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDatabases.TheMetricsOfQuantitiesOfFields), Convert.ToString(_serviceMetadataField.UDPGetMetricsOfQuantitiesOfFields(listOfTables, quantityOfTables)));
                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeDatabases.TheMetricsOfTotalSizeOfDirectoryByParallelProcessing), Convert.ToString(_serviceDirectory.GetMetricsOfTheTotalSizeOfDirectoryByParallelProcessing(new DirectoryInfo(_serviceDirectory.UDPObtainDirectory(DirectoryRootType.App)))));

                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataTable.SuccessToTheSaveMetricsOfTheGenerationOfTablesAndFields), _serviceFuncString.Empty);
            }
        }

        public long UDPGetMetricsOfQuantitiesOfTables(List<Tables> listOfTables)
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataTable.CallStartToTheGetMetricsOfQuantitiesOfTables), _serviceFuncString.Empty);

            long quantityOfTables = 0;
            quantityOfTables = listOfTables.Where(element => !element.Id.Equals(0)).Distinct().LongCount();

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataTable.SuccessToTheGetMetricsOfQuantitiesOfTables), _serviceFuncString.Empty);

            return quantityOfTables;
        }
    }
}