using AppSolution.Application.Interfaces;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AppSolution.Application.Services
{
    public class ServiceDirectory : IServiceDirectory
    {
        private const string NAME_DIRECTORY_BIN = "bin";
        private const string NAME_DIRECTORY_APP = "\\app";
        private const string NAME_DIRECTORY_DEBUG = "debug";
        private const string NAME_DIRECTORY_CONFIG = "\\config";

        public ServiceDirectory()
        {

        }

        public void CreateDefaultDirectory()
        {
            try
            {
                int posRootDirectory = 0;
                string? rootDirectory = GetRootPath();

                if (!string.IsNullOrEmpty(rootDirectory) && rootDirectory.Contains(NAME_DIRECTORY_DEBUG))
                {
                    posRootDirectory = rootDirectory.IndexOf(NAME_DIRECTORY_DEBUG);
                }
                else if (!string.IsNullOrEmpty(rootDirectory) && rootDirectory.Contains(NAME_DIRECTORY_BIN))
                {
                    posRootDirectory = rootDirectory.IndexOf(NAME_DIRECTORY_BIN);
                }

                string? path = rootDirectory?.Substring(0, posRootDirectory - 1).ToLowerInvariant();

                if (!string.IsNullOrEmpty(path))
                {
                    CreateAppDirectory(path);
                }
            }
            catch (Exception)
            {

            }
        }

        private string? GetRootPath()
        {
            string? exePath = string.IsNullOrEmpty(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) ? string.Empty : Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Regex appRegexMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            exePath = exePath?.ToLowerInvariant();
            return appRegexMatcher.Match(exePath ?? string.Empty).Value;
        }

        #region App Directory.
        public void CreateAppDirectory(string? path)
        {
            if (Directory.Exists($"{path}{NAME_DIRECTORY_APP}"))
            {
                Directory.Delete($"{path}{NAME_DIRECTORY_APP}", true);
            }

            Directory.CreateDirectory($"{path}{NAME_DIRECTORY_APP}");
        }

        public void SaveAppDirectory(string? path)
        {
            throw new NotImplementedException();
        }
        #endregion App Directory.

        #region Config Directory.

        #endregion Config Directory.
    }
}