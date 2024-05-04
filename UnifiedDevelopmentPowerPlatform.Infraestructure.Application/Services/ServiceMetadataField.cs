using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Message.Type;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.MetaCharacter;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.Sql;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

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

    public string UDPPGetTheFieldName(string text)
    {
        int positionWithSpace = 0;
        string field = _serviceFuncString.Empty;

        field = _serviceFuncString.UDPPLower(text);
        field = _serviceFuncString.UDPPRemoveSpecialCaracter(field);

        positionWithSpace = _serviceFuncString.UDPPIndexOf(field, MetaCharacterSymbols.HorizontalTab);
        field = _serviceFuncString.UDPPRemoveWhitespaceAtStart(field);

        if (positionWithSpace == -1)
        {
            positionWithSpace = 0;
            positionWithSpace = _serviceFuncString.UDPPIndexOf(field, MetaCharacterSymbols.WhiteSpace);
        }

        field = _serviceFuncString.UDPPRemoveWhitespaceAtStart(field);
        field = _serviceFuncString.UDPPSubString(field, 0, positionWithSpace);
        return _serviceFuncString.UDPPUpper(_serviceFuncString.UDPPRemoveAnyWhiteSpace(field));
    }

    public string UDPPGetTheTypeOfFieldName(string text)
    {
        int positionWithSpace = 0;
        int positionConstraintDefault = 0;
        string typeField = _serviceFuncString.Empty;

        typeField = _serviceFuncString.UDPPLower(text);
        typeField = _serviceFuncString.UDPPReplace(typeField, MetaCharacterSymbols.Comma, _serviceFuncString.Empty);
        typeField = _serviceFuncString.UDPPReplace(typeField, SqlConfiguration.KeyNot, _serviceFuncString.Empty);
        typeField = _serviceFuncString.UDPPReplace(typeField, SqlConfiguration.SqlConstraintNull, _serviceFuncString.Empty);
        typeField = _serviceFuncString.UDPPReplace(typeField, SqlConfiguration.SqlConstraintNotNull, _serviceFuncString.Empty);
        typeField = _serviceFuncString.UDPPReplace(typeField, SqlConfiguration.KeyAutoIncrement, _serviceFuncString.Empty);
        typeField = _serviceFuncString.UDPPReplace(typeField, SqlConfiguration.SqlConstraintCollate, _serviceFuncString.Empty);
        typeField = _serviceFuncString.UDPPReplace(typeField, SqlConfiguration.Utf8WithMb4GeneralCi, _serviceFuncString.Empty);
        typeField = _serviceFuncString.UDPPReplace(typeField, MetaCharacterSymbols.LeftSquareBracket, _serviceFuncString.Empty);
        typeField = _serviceFuncString.UDPPReplace(typeField, MetaCharacterSymbols.RightSquareBracket, _serviceFuncString.Empty);

        if (_serviceFuncString.UDPPContains(typeField, SqlConfiguration.SqlConstraintDefault))
        {
            positionConstraintDefault = _serviceFuncString.UDPPLastIndexOf(typeField, SqlConfiguration.SqlConstraintDefault);
            typeField = _serviceFuncString.UDPPSubString(typeField, 0, positionConstraintDefault + SqlConfiguration.SqlConstraintDefault.Length);
            typeField = _serviceFuncString.UDPPReplace(typeField, SqlConfiguration.SqlConstraintDefault, _serviceFuncString.Empty);
        }

        positionWithSpace = _serviceFuncString.UDPPIndexOf(typeField, MetaCharacterSymbols.HorizontalTab);
        typeField = _serviceFuncString.UDPPRemoveWhitespaceAtStart(typeField);

        if (positionWithSpace.Equals(-1))
        {
            positionWithSpace = 0;
            positionWithSpace = _serviceFuncString.UDPPIndexOf(typeField, MetaCharacterSymbols.WhiteSpace);
        }

        typeField = _serviceFuncString.UDPPRemoveWhitespaceAtStart(typeField);
        typeField = _serviceFuncString.UDPPSubString(typeField, positionWithSpace, Math.Abs(positionWithSpace - typeField.Length));
        typeField = _serviceFuncString.UDPPRemoveSpecialCaracter(typeField);

        return _serviceFuncString.UDPPUpper(_serviceFuncString.UDPPRemoveAnyWhiteSpace(typeField));
    }

    public string UDPPGetThePrimaryKeyFieldName(string text)
    {
        int positionPrimaryKey = 0;
        string field = _serviceFuncString.Empty;

        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.CallStartToTheGetThePrimaryKeyFieldName), _serviceFuncString.Empty);

        field = text;
        positionPrimaryKey = _serviceFuncString.UDPPIndexOf(field, SqlConfiguration.PrimaryKey);
        field = _serviceFuncString.UDPPSubString(field, positionPrimaryKey, Math.Abs(positionPrimaryKey - text.Length));
        field = _serviceFuncString.UDPPReplace(field, SqlConfiguration.PrimaryKey, _serviceFuncString.Empty);
        field = _serviceFuncString.UDPPReplace(field, MetaCharacterSymbols.LeftParenthese, _serviceFuncString.Empty);
        field = _serviceFuncString.UDPPReplace(field, MetaCharacterSymbols.RightParenthese, _serviceFuncString.Empty);
        field = _serviceFuncString.UDPPReplace(field, MetaCharacterSymbols.LeftSquareBracket, _serviceFuncString.Empty);
        field = _serviceFuncString.UDPPReplace(field, MetaCharacterSymbols.RightSquareBracket, _serviceFuncString.Empty);
        field = _serviceFuncString.UDPPReplace(field, MetaCharacterSymbols.SingleQuote, _serviceFuncString.Empty);
        field = _serviceFuncString.UDPPReplace(field, MetaCharacterSymbols.DoubleQuote, _serviceFuncString.Empty);
        field = _serviceFuncString.UDPPRemoveAnyWhiteSpace(field);
        field = _serviceFuncString.UDPPUpper(field);

        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.SuccessToTheGetThePrimaryKeyFieldName), _serviceFuncString.Empty);

        return field;
    }

    public bool UDPPTheFieldIsNotNull(string text)
    {
        return _serviceFuncString.UDPPContains(text, SqlConfiguration.SqlConstraintNotNull);
    }

    public int? UDPPGetFieldLenght(string text)
    {
        int? returnValue = null;
        string data = _serviceFuncString.Empty;

        try
        {
            data = text;
            data = _serviceFuncString.UDPPLower(data);
            data = _serviceFuncString.UDPPOnlyNumber(data);

            if (!_serviceFuncString.UDPPNullOrEmpty(data) && _serviceFuncString.UDPPIsOnlyDigit(data))
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

    public void UDPPLoadTheFieldsAtTable(ref List<Tables> listTables, int idTable, string text)
    {
        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.CallStartToTheLoadTheFieldAtTable), _serviceFuncString.Empty);

        Fields fields = new Fields()
        {
            IdTables = idTable,
            Name = this.UDPPGetTheFieldName(text),
            AutoCreate = true,
            IsNull = this.UDPPTheFieldIsNotNull(text),
            IsPrimaryKey = false,
            FieldLenght = this.UDPPGetFieldLenght(this.UDPPGetTheTypeOfFieldName(text)),
            TypeField = _serviceDevelopmentEnvironments.UDPPGetDataTypeFromTableInScriptMetadata(this.UDPPGetTheTypeOfFieldName(text))
        };

        listTables.Where(element => element.Id.Equals(idTable)).First().Fields.Add(fields);

        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.SuccessToTheLoadTheFieldAtTable), _serviceFuncString.Empty);
    }

    public void UDPPLoadTheFieldsPrimarykeyAtTable(ref List<Tables> listTables, int idTable, string fieldsPrimaryKey)
    {
        string primaryKeys = _serviceFuncString.Empty;
        string[]? listOfFieldsPrimaryKey;

        primaryKeys = this.UDPPGetThePrimaryKeyFieldName(fieldsPrimaryKey);
        listOfFieldsPrimaryKey = _serviceFuncString.UDPPParseLine(new[] { MetaCharacterSymbols.Comma }, primaryKeys);

        if (listOfFieldsPrimaryKey is not null && listOfFieldsPrimaryKey.Any())
        {
            if (listTables is not null && listTables.Any(element => element.Id.Equals(idTable)))
            {
                _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.CallStartToTheLoadTheFieldsPrimarykeyAtTable), _serviceFuncString.Empty);

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

                    _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.SuccessToTheLoadTheFieldsPrimarykeyAtTable), _serviceFuncString.Empty);
                }
            }
        }
    }

    public long UDPPGetMetricsOfQuantitiesOfFields(List<Tables> listOfTables, long quantityOfTables)
    {
        long quantityOfFields = 0;

        _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.CallStartToTheGetMetricsOfQuantitiesOfFields), _serviceFuncString.Empty);

        try
        {
            for (int i = 0; i < quantityOfTables; i++)
            {
                quantityOfFields += listOfTables.Where(element => !element.Id.Equals(0) && element.Id.Equals(i + 1)).First().Fields
                                                .Where(element => !element.IdTables.Equals(0) && element.IdTables.Equals(i + 1))
                                                .LongCount();
            }

            _serviceLog.UDPPRegisterLog(_serviceMessage.UDPGetMessage(TypeMetadataFields.SuccessToTheGetMetricsOfQuantitiesOfFields), _serviceFuncString.Empty);

        }
        catch (Exception) { }

        return quantityOfFields;
    }
}