namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for (The Operational System).
    /// </summary>
    public interface IServiceOperationalSystem
    {
        /// <summary>
        /// Make validation if platform is Windows.
        /// </summary>
        /// <returns>The method will return true, otherwise will return false.</returns>
        bool UPDOperationalSystemIsWindows();
    }
}