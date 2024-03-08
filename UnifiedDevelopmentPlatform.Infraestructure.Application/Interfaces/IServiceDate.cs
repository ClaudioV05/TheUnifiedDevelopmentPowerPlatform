namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface ServiceDate.
    /// </summary>
    public interface IServiceDate
    {
        /// <summary>
        /// Get the date time now with string format.
        /// </summary>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        string UDPGetDateTimeNowFormat();

        /// <summary>
        /// Date time to long time.
        /// </summary>
        /// <paramref name=""/>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <exception cref=""></exception>
        /// <seealso href=""></seealso>
        /// <returns></returns>
        string UDPGetDateTimeToLongTime();
    }
}