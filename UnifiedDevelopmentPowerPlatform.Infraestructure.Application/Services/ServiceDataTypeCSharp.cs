using UnifiedDevelopmentPowerPlatform.Application.Interfaces;
using UnifiedDevelopmentPowerPlatform.Infraestructure.Domain.Entities.DataTypes;

namespace UnifiedDevelopmentPowerPlatform.Application.Services;

/// <summary>
/// Service data type c-sharp.
/// </summary>
public class ServiceDataTypeCSharp : IServiceDataTypeCSharp
{
    private readonly IServiceFuncString _serviceFuncString;

    /// <summary>
    /// The constructor of service data type c-sharp.
    /// </summary>
    /// <param name="serviceFuncString" />
    public ServiceDataTypeCSharp(IServiceFuncString serviceFuncString)
    {
        _serviceFuncString = serviceFuncString;
    }

    public bool UDPPByIndexEnumTypeIsDefined(int index)
    {
        return Enum.IsDefined(typeof(AnsiSql.DataType), index);
    }

    public CSharp.DataType UDPPGetAsEnumeratedTheEnumType(int index)
    {
        return (CSharp.DataType)index;
    }

    public int UDPPReturnIndexFromTheListOfDataTypes(string dataType)
    {
        string type = _serviceFuncString.Empty;

        try
        {
            type = dataType;
            type = _serviceFuncString.UDPPLower(type);
            type = _serviceFuncString.UDPPOnlyLetter(type);

            return Enum.GetNames(typeof(CSharp.DataType))
                       .ToList()
                       .FindIndex(element => _serviceFuncString.UDPPContains(_serviceFuncString.UDPPLower(element), type));
        }
        catch (Exception)
        {
            return Convert.ToInt32("0");
        }
    }

    public string UDPPGetAsStringTheEnumType(CSharp.DataType dataType)
    {
        return Enum.GetName(typeof(CSharp.DataType), dataType) ?? _serviceFuncString.Empty;
    }
}