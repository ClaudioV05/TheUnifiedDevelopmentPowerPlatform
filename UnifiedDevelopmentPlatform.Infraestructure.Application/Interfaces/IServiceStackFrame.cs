namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    /// <summary>
    /// Interface service for Stack Frame.
    /// </summary>
    public interface IServiceStackFrame
    {
        /// <summary>
        /// Get the file line number.
        /// </summary>
        /// <returns></returns>
        int UDPGetFileLineNumber();

        /// <summary>
        /// Get the file name.
        /// </summary>
        /// <returns></returns>
        string? UDPGetFileName();

        /// <summary>
        /// Create the instace of stack frame.
        /// </summary>
        void CreateInstaceStackFrame();
    }
}