namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service Date.
    /// </summary>
    public interface IServiceDate
    {
        /// <summary>
        /// Get the date time now with string format.
        /// </summary>
        /// <returns></returns>
        string UDPGetDateTimeNowFormat();

        /// <summary>
        /// Date time to long time.
        /// </summary>
        /// <returns></returns>
        string UDPGetDateTimeToLongTime();
    }
}