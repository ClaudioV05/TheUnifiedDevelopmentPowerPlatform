using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceDirectory : IServiceDirectory
    {
        #region Fields.
        private string? _directory;
        private readonly Queue<string> _queueDirectory;
        #endregion Fields.

        public ServiceDirectory()
        {
            _queueDirectory = new Queue<string>();
        }

        public bool CreateAllDirectoryOfSolution()
        {
            /*
            try
            {
                _directory = this.GetRootDirectoryOfSolution();

                if (!string.IsNullOrEmpty(_directory))
                {
                    if (this.DeleteAllDirectoryOfSolution(_directory))
                    {
                        // 1° Create the Default Directorys.

                        // 1.1 Create the Default App.
                        this.CreateAppDirectory();

                        // 1.2 Create the Default Config.
                        this.CreateConfigDirectory();

                        // 2° Create the Presentation Directorys.
                        this.CreatePresentation();
                        // 3° Create the Application Directorys.
                        this.CreateApplication();
                        // 4° Create the Domain Directorys.
                        this.CreateDomainDirectory();
                        // 5° Create the Infrastructure Directorys.
                        this.CreateInfrastructure();
                    }
                }
            }
            catch (Exception)
            {
                this.DeleteAllDirectoryOfSolution(_directory);
                return false;
            }
            */
            return true;
        }
        /*
        private bool DeleteAllDirectoryOfSolution(string? rootDirectory)
        {
            try
            {
                if (!string.IsNullOrEmpty(rootDirectory))
                {
                    DirectoryInfo di = new DirectoryInfo(rootDirectory);
                    DirectoryInfo[] Directories = di.GetDirectories("*", SearchOption.AllDirectories);

                    if (Directory.Exists($"{rootDirectory}{DirectoryStandard.APP}") && Directories.Count() > 0)
                    {
                        Directory.Delete($"{rootDirectory}{DirectoryStandard.APP}", true);
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }

        private string? GetRootDirectoryOfSolution()
        {
            try
            {
                string? exerootDirectory = Assembly.GetExecutingAssembly().Location;
                Regex appRegexMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
                exerootDirectory = exerootDirectory?.ToLowerInvariant();
                return appRegexMatcher.Match(exerootDirectory ?? string.Empty).Value;
            }
            catch (IOException)
            {
                return string.Empty;
            }
        }

        private string? RemoverCaracteresInvalidosArquivo(string path)
        {
            if (!string.IsNullOrEmpty(path) && path.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            {
                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    path = path.Replace(c.ToString(), string.Empty);
                }
            }

            return path;
        }

        private void CreateQueueDirectory(Queue<string> queueDirectory)
        {
            try
            {
                if (queueDirectory != null && queueDirectory.Count > 0)
                {
                    foreach (var dir in _queueDirectory)
                    {
                        Directory.CreateDirectory(RemoverCaracteresInvalidosArquivo(dir) ?? string.Empty);
                    }
                }
            }
            catch (IOException)
            {

            }
        }

        #region Standard Directorys.
        private void CreateAppDirectory()
        {
            _queueDirectory.Clear();
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}");
            CreateQueueDirectory(_queueDirectory);
        }

        private void CreateConfigDirectory()
        {
            _queueDirectory.Clear();
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIG}");
            CreateQueueDirectory(_queueDirectory);
        }
        #endregion Standard Directorys.

        #region Presentation Directorys.
        private void CreatePresentation()
        {
            _queueDirectory.Clear();
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryPresentation.PRESENTATION}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.PROPERTIES}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.CONTROLLERS}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.EXTENSIONS}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.FILTERS}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.MODELS}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.SWAGGER}");
            CreateQueueDirectory(_queueDirectory);
        }
        #endregion Presentation Directorys.

        #region Application Directorys.
        private void CreateApplication()
        {
            _queueDirectory.Clear();
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryApplication.APPLICATION}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryApplication.APPLICATION}{DirectoryApplication.INTERFACES}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryApplication.APPLICATION}{DirectoryApplication.SERVICES}");
            CreateQueueDirectory(_queueDirectory);
        }
        #endregion Application Directorys.

        #region Domain Directorys.
        private void CreateDomainDirectory()
        {
            _queueDirectory.Clear();
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryDomain.DOMAIN}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryDomain.DOMAIN}{DirectoryDomain.INTERFACES}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP} {DirectoryDomain.DOMAIN} {DirectoryDomain.ENTITIES}");
            CreateQueueDirectory(_queueDirectory);
        }
        #endregion Domain Directorys.

        #region Infrastructure Directorys.
        private void CreateInfrastructure()
        {
            _queueDirectory.Clear();
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryInfrastructure.INFRASTRUCTURE}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryInfrastructure.INFRASTRUCTURE}{DirectoryInfrastructure.CROSSCUTTING}");
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryInfrastructure.INFRASTRUCTURE}{DirectoryInfrastructure.DATA}");
            CreateQueueDirectory(_queueDirectory);
        }
        #endregion Infrastructure Directorys.
        */
    }
}