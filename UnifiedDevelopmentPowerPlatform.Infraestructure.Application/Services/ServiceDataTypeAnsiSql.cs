using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service data type ansi sql.
/// </summary>
public class ServiceDataTypeAnsiSql : IServiceDataTypeAnsiSql
{
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// The constructor of service data type ansi sql.
    /// </summary>
    /// <param name="serviceFuncString" />
    public ServiceDataTypeAnsiSql(IServiceFuncString serviceFuncString)
    {
        _serviceFuncString = serviceFuncString;
    }

    public bool UDPByIndexEnumTypeIsDefined(int index)
    {
        return Enum.IsDefined(typeof(AnsiSql.DataType), index);
    }

    public AnsiSql.DataType UDPGetAsEnumeratedTheEnumType(int index)
    {
        return (AnsiSql.DataType)index;
    }

    public int UDPReturnIndexFromTheListOfDataTypes(string dataType)
    {
        string resultDataType = _serviceFuncString.Empty;

        try
        {
            resultDataType = dataType;
            resultDataType = _serviceFuncString.UDPLower(resultDataType);
            resultDataType = _serviceFuncString.UDPOnlyLetter(resultDataType);

            return Enum.GetNames(typeof(AnsiSql.DataType))
                       .ToList()
                       .FindIndex(element => _serviceFuncString.UDPContains(_serviceFuncString.UDPLower(element), resultDataType));
        }
        catch (Exception)
        {
            return Convert.ToInt32("0");
        }
    }

    public string UDPGetAsStringTheEnumType(AnsiSql.DataType dataType)
    {
        return Enum.GetName(typeof(CSharp.DataType), dataType) ?? _serviceFuncString.Empty;
    }
}