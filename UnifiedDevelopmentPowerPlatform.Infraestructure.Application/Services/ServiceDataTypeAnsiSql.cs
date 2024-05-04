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

    public bool UDPPByIndexEnumTypeIsDefined(int index)
    {
        return Enum.IsDefined(typeof(AnsiSql.DataType), index);
    }

    public AnsiSql.DataType UDPPGetAsEnumeratedTheEnumType(int index)
    {
        return (AnsiSql.DataType)index;
    }

    public int UDPPReturnIndexFromTheListOfDataTypes(string dataType)
    {
        string resultDataType = _serviceFuncString.Empty;

        try
        {
            resultDataType = dataType;
            resultDataType = _serviceFuncString.UDPPLower(resultDataType);
            resultDataType = _serviceFuncString.UDPPOnlyLetter(resultDataType);

            return Enum.GetNames(typeof(AnsiSql.DataType))
                       .ToList()
                       .FindIndex(element => _serviceFuncString.UDPPContains(_serviceFuncString.UDPPLower(element), resultDataType));
        }
        catch (Exception)
        {
            return Convert.ToInt32("0");
        }
    }

    public string UDPPGetAsStringTheEnumType(AnsiSql.DataType dataType)
    {
        return Enum.GetName(typeof(CSharp.DataType), dataType) ?? _serviceFuncString.Empty;
    }
}