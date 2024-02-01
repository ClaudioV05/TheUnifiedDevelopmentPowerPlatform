namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service enumerated.
    /// </summary>
    public interface IServiceEnumerated
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string GetEnumDescription(Enum value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MyEnum"></param>
        /// <returns></returns>
        List<Enum> ListOfEnumerated(Enum MyEnum);
    }
}