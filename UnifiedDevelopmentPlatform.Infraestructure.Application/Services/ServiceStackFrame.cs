using System.Diagnostics;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for Stack Frame.
    /// </summary>
    public class ServiceStackFrame : IServiceStackFrame
    {
        private StackFrame _stackFrame;

        /// <summary>
        /// The constructor of Service Stack Frame.
        /// </summary>
        public ServiceStackFrame()
        {

        }

        public int UDPGetFileLineNumber()
        {
            return _stackFrame.GetFileLineNumber();
        }

        public string? UDPGetFileName()
        {
            return _stackFrame.GetFileName();
        }

        public void CreateInstaceStackFrame()
        {
            _stackFrame = new StackFrame(1, true);
        }
    }
}