using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Sql;

namespace UnifiedDevelopmentPowerPlatform.Application.Services
{
    /// <summary>
    /// Service metadata field.
    /// </summary>
    public class ServiceMetadataField : IServiceMetadataField
    {
        private readonly IServiceLog _serviceLog;
        private readonly IServiceMessage _serviceMessage;
        private readonly IServiceFuncString _serviceFuncString;
        private readonly IServiceDevelopmentEnvironments _serviceDevelopmentEnvironments;

        /// <summary>
        /// The constructor of service metadata field.
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
            int positionConstraintDefault = 0;
            string typeField = _serviceFuncString.Empty;

            typeField = _serviceFuncString.UDPLower(text);
            typeField = _serviceFuncString.UDPReplace(typeField, MetaCharacterSymbols.Comma, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyNot, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.SqlConstraintNull, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.SqlConstraintNotNull, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.KeyAutoIncrement, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.SqlConstraintCollate, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.Utf8WithMb4GeneralCi, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, MetaCharacterSymbols.LeftSquareBracket, _serviceFuncString.Empty);
            typeField = _serviceFuncString.UDPReplace(typeField, MetaCharacterSymbols.RightSquareBracket, _serviceFuncString.Empty);

            if (_serviceFuncString.UDPContains(typeField, SqlConfiguration.SqlConstraintDefault))
            {
                positionConstraintDefault = _serviceFuncString.UDPLastIndexOf(typeField, SqlConfiguration.SqlConstraintDefault);
                typeField = _serviceFuncString.UDPSubString(typeField, 0, positionConstraintDefault + SqlConfiguration.SqlConstraintDefault.Length);
                typeField = _serviceFuncString.UDPReplace(typeField, SqlConfiguration.SqlConstraintDefault, _serviceFuncString.Empty);
            }

            positionWithSpace = _serviceFuncString.UDPIndexOf(typeField, MetaCharacterSymbols.HorizontalTab);
            typeField = _serviceFuncString.UDPRemoveWhitespaceAtStart(typeField);

            if (positionWithSpace.Equals(-1))
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

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.CallStartToTheGetThePrimaryKeyFieldName), _serviceFuncString.Empty);

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

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.SuccessToTheGetThePrimaryKeyFieldName), _serviceFuncString.Empty);

            return field;
        }

        public bool UDPTheFieldIsNotNull(string text)
        {
            return _serviceFuncString.UDPContains(text, SqlConfiguration.SqlConstraintNotNull);
        }

        public int? UDPGetFieldLenght(string text)
        {
            int? returnValue = null;
            string data = _serviceFuncString.Empty;

            try
            {
                data = text;
                data = _serviceFuncString.UDPLower(data);
                data = _serviceFuncString.UDPOnlyNumber(data);

                if (!_serviceFuncString.UDPNullOrEmpty(data) && _serviceFuncString.UDPIsOnlyDigit(data))
                {
                    returnValue = Convert.ToInt32(data);
                }

                return returnValue;
            }
            catch (Exception)
            {
                return returnValue;
            }
        }

        public void UDPLoadTheFieldsAtTable(ref List<Tables> listTables, int idTable, string text)
        {
            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.CallStartToTheLoadTheFieldAtTable), _serviceFuncString.Empty);

            Fields fields = new Fields()
            {
                IdTables = idTable,
                Name = this.UDPGetTheFieldName(text),
                AutoCreate = true,
                IsNull = this.UDPTheFieldIsNotNull(text),
                IsPrimaryKey = false,
                FieldLenght = this.UDPGetFieldLenght(this.UDPGetTheTypeOfFieldName(text)),
                TypeField = _serviceDevelopmentEnvironments.UDPGetDataTypeFromTableInScriptMetadata(this.UDPGetTheTypeOfFieldName(text))
            };

            listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Add(fields);

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.SuccessToTheLoadTheFieldAtTable), _serviceFuncString.Empty);
        }

        public void UDPLoadTheFieldsPrimarykeyAtTable(ref List<Tables> listTables, int idTable, string fieldsPrimaryKey)
        {
            string primaryKeys = _serviceFuncString.Empty;
            string[]? listOfFieldsPrimaryKey;

            primaryKeys = this.UDPGetThePrimaryKeyFieldName(fieldsPrimaryKey);
            listOfFieldsPrimaryKey = _serviceFuncString.UDPParseLine(new[] { MetaCharacterSymbols.Comma }, primaryKeys);

            if (listOfFieldsPrimaryKey is not null && listOfFieldsPrimaryKey.Any())
            {
                if (listTables is not null && listTables.Any(element => element.Id.Equals(idTable)))
                {
                    _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.CallStartToTheLoadTheFieldsPrimarykeyAtTable), _serviceFuncString.Empty);

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

                        _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.SuccessToTheLoadTheFieldsPrimarykeyAtTable), _serviceFuncString.Empty);
                    }
                }
            }
        }

        public long UDPGetMetricsOfQuantitiesOfFields(List<Tables> listOfTables, long quantityOfTables)
        {
            long quantityOfFields = 0;

            _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.CallStartToTheGetMetricsOfQuantitiesOfFields), _serviceFuncString.Empty);

            try
            {
                for (int i = 0; i < quantityOfTables; i++)
                {
                    quantityOfFields += listOfTables.Where(element => !element.Id.Equals(0) && element.Id.Equals(i + 1)).First().Fields
                                                    .Where(element => !element.IdTables.Equals(0) && element.IdTables.Equals(i + 1))
                                                    .LongCount();
                }

                _serviceLog.UDPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.SuccessToTheGetMetricsOfQuantitiesOfFields), _serviceFuncString.Empty);

            }
            catch (Exception) { }

            return quantityOfFields;
        }
    }
}