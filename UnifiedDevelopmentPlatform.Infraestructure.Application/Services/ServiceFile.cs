using System.Text;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service File.
    /// </summary>
    public class ServiceFile : IServiceFile
    {
        private readonly FileStreamOptions _fileStreamOptions = new FileStreamOptions()
        {
            Access = FileAccess.Read,
            Share = FileShare.ReadWrite,
            Mode = FileMode.OpenOrCreate
        };

        /// <summary>
        /// The constructor of Service File.
        /// </summary>
        public ServiceFile() { }

        public bool UDPFileExists(string? path)
        {
            return File.Exists(path);
        }

        public string UDPReadAllText(string path)
        {
            return File.ReadAllText(path, Encoding.UTF8);
        }

        public IEnumerable<string>? UDPReadAllLines(string path)
        {
            return File.ReadAllLines(path, Encoding.UTF8);
        }

        public void UDPWriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents, Encoding.UTF8);
        }

        public void UDPCreateAndSaveFile(string path)
        {
            using (FileStream fileStream = File.Create(path)) { };
        }

        public void UDPCreateAndSaveFileWithStreamWrite(string path)
        {
            using (StreamWriter streamWriter = File.CreateText(path)) { };
        }

        public void UDPAppendAllText(string path, string content)
        {
            File.AppendAllText(path, content);
        }

        public FileStream UDPOpenRead(string path)
        {
            using FileStream file = File.OpenRead(path);
            return file;
        }

        public string UDPGetFileName(string path)
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

        public int UDPCountLines(string fileName)
        {
            var lineCount = 0;

            if (!this.UDPFileExists(fileName))
            {
                throw new FileNotFoundException($"File not found: {fileName}");
            }

            using StreamReader reader = new(fileName);

            while (reader.ReadLine() is not null)
            {
                lineCount++;
            }

            return lineCount;
        }
    }
}