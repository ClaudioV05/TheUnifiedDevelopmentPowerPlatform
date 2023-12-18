using System.Text;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceFile : IServiceFile
    {
        public bool UDPFileExists(string? path)
        {
            return File.Exists(path);
        }

        public string UDPReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public IEnumerable<string>? UDPLinesRead(string path)
        {
            return File.ReadAllLines(path);
        }

        public void UDPLinesGenerate(string path, IEnumerable<string> contents)
        {
            File.WriteAllLines(path, contents, Encoding.UTF8);
        }

        public void UDPCreateAndSaveInitialFile(string path)
        {
            using (FileStream fs = File.Create(path)) { };
        }
    }
}