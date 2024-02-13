namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service enumerated.
    /// </summary>
    public interface IServiceEnumerated<T, U> where T : struct where U : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MyEnum"></param>
        /// <returns></returns>
        List<U> UDPObtainListItem(T UdpEnumerated, U obj);
    }
}