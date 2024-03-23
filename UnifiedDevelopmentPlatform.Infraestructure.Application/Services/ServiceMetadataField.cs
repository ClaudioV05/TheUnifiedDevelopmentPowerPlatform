using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Message;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Sql;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service MetadataField.
    /// </summary>
    public class ServiceMetadataField : IServiceMetadataField
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceFuncString _serviceFuncString;
        private readonly IServiceDevelopmentEnvironments _serviceDevelopmentEnvironments;

        /// <summary>
        /// The constructor of ServiceMetadataField.
        /// </summary>
        /// <param name="serviceLog"></param>
        /// <param name="serviceMessage"></param>
        /// <param name="serviceFuncString"></param>
        /// <param name="serviceDevelopmentEnvironments"></param>
        public ServiceMetadataField(IServiceLog serviceLog,
                                    IServiceMessage serviceMessage,
                                    IServiceFuncString serviceFuncString,
                                    IServiceDevelopmentEnvironments serviceDevelopmentEnvironments)
        {
            _serviceLog = serviceLog;
            _serviceMessage = serviceMessage;
            _serviceFuncString = serviceFuncString;
            _serviceDevelopmentEnvironments = serviceDevelopmentEnvironments;
        }

        public string UDPGetTheFieldName(string text)
        {
            int positionWithSpace = 0;
            string field = _serviceFuncString.Empty;

            field = _serviceFuncString.UDPLower(text);
            field = _serviceFuncString.UDPRemoveSpecialCaracter(field);

            positionWithSpace = _serviceFuncString.UDPIndexOf(field, MetaCharacterSymbols.HorizontalTab);
            field = _serviceFuncString.UDPRemoveWhitespaceAtStart(field);

            if (positionWithSpace == -1)
            {
                positionWithSpace = 0;
                positionWithSpace = _serviceFuncString.UDPIndexOf(field, MetaCharacterSymbols.WhiteSpace);
            }

            field = _serviceFuncString.UDPRemoveWhitespaceAtStart(field);
            field = _serviceFuncString.UDPSubString(field, 0, positionWithSpace);
            return _serviceFuncString.UDPUpper(_serviceFuncString.UDPRemoveAnyWhiteSpace(field));
        }

        public string UDPGetTheTypeOfFieldName(string text)
        {
            int positionWithSpace = 0;
            string typeField = _serviceFuncString.Empty;

            typeField = _serviceFuncString.UDPLower(text);
            typeField = _serviceFuncString.UDPReplace(typeField, MetaCharacterSymbols.Comma, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNot, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNullValue, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNotNullValue, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyAutoIncrement, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, MetaCharacterSymbols.LeftSquareBracket, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, MetaCharacterSymbols.RightSquareBracket, _serviceFuncString.Empty);
            positionWithSpace = _serviceFuncString.UDPIndexOf(typeField, MetaCharacterSymbols.HorizontalTab);

            typeField = _serviceFuncString.UDPRemoveWhitespaceAtStart(typeField);

            if (positionWithSpace == -1)
            {
                positionWithSpace = 0;
                positionWithSpace = _serviceFuncString.UDPIndexOf(typeField, MetaCharacterSymbols.WhiteSpace);
            }

            typeField = _serviceFuncString.UDPRemoveWhitespaceAtStart(typeField);
            typeField = _serviceFuncString.UDPSubString(typeField, positionWithSpace, Math.Abs(positionWithSpace - typeField.Length));
            typeField = _serviceFuncString.UDPRemoveSpecialCaracter(typeField);
            return _serviceFuncString.UDPUpper(_serviceFuncString.UDPRemoveAnyWhiteSpace(typeField));
        }

        public string UDPGetThePrimaryKeyFieldName(string text)
        {
            int positionPrimaryKey = 0;
            string field = _serviceFuncString.Empty;

            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheGetThePrimaryKeyFieldName), _serviceFuncString.Empty);

            field = text;
            positionPrimaryKey = _serviceFuncString.UDPIndexOf(field, SqlConfiguration.PrimaryKey);
            field = _serviceFuncString.UDPSubString(field, positionPrimaryKey, Math.Abs(positionPrimaryKey - text.Length));
            field = _serviceFuncString.UDPReplace(field, SqlConfiguration.PrimaryKey, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.LeftParenthese, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.RightParenthese, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.LeftSquareBracket, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.RightSquareBracket, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.SingleQuote, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPReplace(field, MetaCharacterSymbols.DoubleQuote, _serviceFuncString.Empty);
            field = _serviceFuncString.UDPRemoveAnyWhiteSpace(field);
            field = _serviceFuncString.UDPUpper(field);

            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheGetThePrimaryKeyFieldName), _serviceFuncString.Empty);

            return field;
        }

        public bool UDPTheFieldIsNotNull(string text)
        {
            return _serviceFuncString.UDPContains(text, SqlConfiguration.KeyNotNullValue);
        }

        public void UDPLoadTheFieldsAtTable(ref List<Tables> listTables, int idTable, string text)
        {
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheLoadTheFieldAtTable), _serviceFuncString.Empty);

            listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Add(new Fields()
            {
                IdTables = idTable,
                Name = this.UDPGetTheFieldName(text),
                IsNull = this.UDPTheFieldIsNotNull(text),
                IsPrimaryKey = false,
                TypeField = _serviceDevelopmentEnvironments.UDPGetTheTypeOfCSharp(this.UDPGetTheTypeOfFieldName(text))
            });

            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheLoadTheFieldAtTable), _serviceFuncString.Empty);
        }

        public void UDPLoadTheFieldsPrimarykeyAtTable(ref List<Tables> listTables, int idTable, string[]? listOfFieldsPrimaryKey)
        {
            if (listTables is not null && listTables.Any(element => element.Id.Equals(idTable)))
            {
                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheLoadTheFieldsPrimarykeyAtTable), _serviceFuncString.Empty);

                if (listOfFieldsPrimaryKey is not null && listOfFieldsPrimaryKey.Any())
                {
                    for (int i = 0; i < listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Count; i++)
                    {
                        for (int j = 0; j < listOfFieldsPrimaryKey.Length; j++)
                        {
                            if (listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Where(element => element.Name.Contains(listOfFieldsPrimaryKey[j])).Any())
                            {
                                listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Where(element => element.Name.Contains(listOfFieldsPrimaryKey[j])).FirstOrDefault().IsPrimaryKey = true;
                            }
                        }
                    }

                    _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheLoadTheFieldsPrimarykeyAtTable), _serviceFuncString.Empty);
                }
            }
        }

        public long UDPGetMetricsOfQuantitiesOfFields(List<Tables> listOfTables, long quantityOfTables)
        {
            long quantityOfFields = 0;
            _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.CallStartToTheGetMetricsOfQuantitiesOfFields), _serviceFuncString.Empty);

            try
            {
                for (int i = 0; i < quantityOfTables; i++)
                {
                    quantityOfFields += listOfTables.Where(element => !element.Id.Equals(0) && element.Id.Equals(i + 1)).First().Fields
                                                    .Where(element => !element.IdTables.Equals(0) && element.IdTables.Equals(i + 1))
                                                    .LongCount();
                }

                _serviceLog.UDPLogReport(_serviceMessage.UDPMensagem(MessageType.SuccessToTheGetMetricsOfQuantitiesOfFields), _serviceFuncString.Empty);

            }
            catch (Exception) { }

            return quantityOfFields;
        }
    }
}