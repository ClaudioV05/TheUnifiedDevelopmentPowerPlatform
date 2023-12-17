using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceFile : IServiceFile
    {
        public bool UDPFileExists(string rootDirectory)
        {
            return File.Exists(rootDirectory);
        }

        public string UDPReadAllText(string rootDirectory)
        {
            return File.ReadAllText(rootDirectory);
        }

        public IEnumerable<string>? UDPLinesRead(string rootDirectory)
        {
            return File.ReadAllLines(rootDirectory);
        }

        public void UDPLinesGenerate(string rootDirectory, IEnumerable<string> informations)
        {
            File.WriteAllLines(rootDirectory, informations);
        }
    }
}