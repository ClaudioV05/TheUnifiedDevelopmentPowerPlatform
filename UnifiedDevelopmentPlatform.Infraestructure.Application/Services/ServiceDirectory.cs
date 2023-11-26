using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceDirectory : IServiceDirectory
    {
        /// <summary>
        /// Names of Directory for App Solution.
        /// </summary>
        private record StandardDirectory
        {
            public const string DIR_APP = "\\App";
            public const string DIR_CONFIG = "\\Config";

            public const string DIR_PRESENTATION = "\\1-Presentation";
            public const string DIR_APPLICATION = "\\2-Application";
            public const string DIR_DOMAIN = "\\3-Domain";
            public const string DIR_INFRASTRUCTURE = "\\4-Infrastructure";
        }

        #region App.
        public bool CreateAppDirectory()
        {
            bool createDir = false;
            try
            {
                string? rootDirectory = GetRootDirectory();

                if (!string.IsNullOrEmpty(rootDirectory))
                {
                    if (Directory.Exists($"{rootDirectory}{StandardDirectory.DIR_APP}"))
                    {
                        Directory.Delete($"{rootDirectory}{StandardDirectory.DIR_APP}", true);
                    }

                    Directory.CreateDirectory($"{rootDirectory}{StandardDirectory.DIR_APP}");
                    createDir = true;
                }
            }
            catch (IOException)
            {

            }

            return createDir;
        }

        public string? ReadAppDirectory()
        {
            string? dir = string.Empty;
            try
            {
                string? rootDirectory = GetRootDirectory();
                dir = $"{rootDirectory}{StandardDirectory.DIR_APP}";
            }
            catch (IOException)
            {

            }

            return dir;
        }
        #endregion App.

        #region Config.
        public bool CreateConfigDirectory()
        {
            bool createDir = false;
            try
            {
                string? rootDirectory = GetRootDirectory();

                if (!string.IsNullOrEmpty(rootDirectory))
                {
                    if (Directory.Exists($"{rootDirectory}{StandardDirectory.DIR_APP}{StandardDirectory.DIR_CONFIG}"))
                    {
                        Directory.Delete($"{rootDirectory}{StandardDirectory.DIR_APP}{StandardDirectory.DIR_CONFIG}", true);
                    }

                    Directory.CreateDirectory($"{rootDirectory}{StandardDirectory.DIR_APP}{StandardDirectory.DIR_CONFIG}");
                    createDir = true;
                }
            }
            catch (IOException)
            {

            }

            return createDir;
        }

        public string? ReadConfigDirectory()
        {
            string? dir = string.Empty;
            try
            {
                string? rootDirectory = GetRootDirectory();
                dir = $"{rootDirectory}{StandardDirectory.DIR_APP}{StandardDirectory.DIR_CONFIG}";
            }
            catch (IOException)
            {

            }

            return dir;
        }
        #endregion Config.

        #region Presentation.
        public bool CreatePresentationDirectory()
        {
            bool createDir = false;
            try
            {
                string? rootDirectory = GetRootDirectory();

                if (!string.IsNullOrEmpty(rootDirectory))
                {
                    if (Directory.Exists($"{rootDirectory}{StandardDirectory.DIR_APP}{StandardDirectory.DIR_PRESENTATION}"))
                    {
                        Directory.Delete($"{rootDirectory}{StandardDirectory.DIR_APP}{StandardDirectory.DIR_PRESENTATION}", true);
                    }

                    Directory.CreateDirectory($"{rootDirectory}{StandardDirectory.DIR_APP} {StandardDirectory.DIR_PRESENTATION}");
                    createDir = true;
                }
            }
            catch (IOException)
            {

            }

            return createDir;
        }

        public string? ReadPresentationDirectory()
        {
            string? dir = string.Empty;
            try
            {
                string? rootDirectory = GetRootDirectory();
                dir = $"{rootDirectory}{StandardDirectory.DIR_APP} {StandardDirectory.DIR_PRESENTATION}";
            }
            catch (IOException)
            {

            }

            return dir;
        }
        #endregion Presentation.

        private string? GetRootDirectory()
        {
            /*
            string? exerootDirectory = string.IsNullOrEmpty(rootDirectory.GetDirectoryName(Assembly.GetExecutingAssembly().Location)) ? string.Empty : rootDirectory.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Regex appRegexMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            exerootDirectory = exerootDirectory?.ToLowerInvariant();
            return appRegexMatcher.Match(exerootDirectory ?? string.Empty).Value;
            */
            return null;
        }
    }
}