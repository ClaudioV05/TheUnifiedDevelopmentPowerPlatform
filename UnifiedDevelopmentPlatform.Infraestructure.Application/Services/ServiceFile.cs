using System.Text;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for File.
    /// </summary>
    public class ServiceFile : IServiceFile
    {
        /// <summary>
        /// The constructor of Service File.
        /// </summary>
        public ServiceFile()
        {

        }

        public bool UDPFileExists(string? path)
        {
            return File.Exists(path);
        }

        public string UDPReadAllText(string path)
        {
            return File.ReadAllText(path);
        }

        public IEnumerable<string>? UDPReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public void UDPWriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents, Encoding.UTF8);
        }

        public void UDPCreateAndSaveInitialFile(string path)
        {
            using (FileStream fs = File.Create(path)) { };
        }

        public void UDPAppendAllText(string pathWithFile, string content)
        {
            File.AppendAllText(pathWithFile, content);
        }

        public FileStream UDPOpenRead(string path)
        {
            using FileStream file = File.OpenRead(path);
            return file;
        }

        public string UDPGetFileName(string? path) 
        {
            try
            {
                return Path.GetFileName(path);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}