using System.Reflection;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Json;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service Directory.
    /// </summary>
    public class ServiceDirectory : IServiceDirectory
    {
        private string? _directory;
        private readonly IServiceXml _serviceXml;
        private readonly IServiceFile _serviceFile;
        private readonly IServiceJson _serviceJson;
        private readonly IServiceLinq _serviceLinq;
        private readonly Queue<string> _queueDirectory;
        private readonly List<string> _listDirectory;
        private readonly IServiceFuncString _serviceFuncStrings;

        public ServiceDirectory(IServiceXml serviceXml, /*IServiceLog serviceLog,*/ IServiceFile serviceFile, IServiceJson serviceJson, IServiceLinq serviceLinq, IServiceFuncString serviceFuncStrings)
        {
            _serviceXml = serviceXml;
            //_serviceLog = serviceLog;
            _serviceFile = serviceFile;
            _serviceJson = serviceJson;
            _serviceLinq = serviceLinq;
            _queueDirectory = new Queue<string>();
            _listDirectory = new List<string>();
            _serviceFuncStrings = serviceFuncStrings;
        }

        public void UPDBuildDirectoryStandardOfSolution()
        {
            try
            {
                this.LoadDirectoryRootPath(this.UDPGetRootDirectory());
                //this.UDPDeleteAllRootDirectoryOfSolution(_directory);

                this.UDPLoadDirectory(DirectoryRoot.App);
                this.UDPLoadDirectory(DirectoryRoot.Configuration);
                this.UDPLoadDirectory(DirectoryRoot.Json);
                this.UDPLoadDirectory(DirectoryRoot.Log);
                this.UDPLoadDirectory(DirectoryRoot.Xml);
                this.UDPCreateDirectory();
            }
            catch (Exception)
            {
                //this.UDPDeleteAllRootDirectoryOfSolution(_directory);
                throw;
            }
        }

        public void UPDCreateDirectoryProjectOfSolution()
        {
            string[] directories = new string[] { DirectoryStandard.Backend, DirectoryStandard.Frontend };

            try
            {
                this.LoadDirectoryRootPath(this.UDPGetRootDirectory());

                this.CreateRootPathPresentation(directories);
                this.CreateRootPathApplication(directories);
                this.CreateRootPathDomain(directories);
                this.CreateRootPathInfrastructure(directories);
                this.UDPCreateAllRootPath(_queueDirectory);

            }
            catch (IOException)
            {
                this.UDPDeleteAllRootDirectoryOfSolution(_directory);
                throw new IOException();
            }
        }

        private string UDPGetRootDirectory()
        {
            Regex? regex = null;
            string? exeRootDirectory = _serviceFuncStrings.Empty;
            string? rootDirectoryOfSolution = _serviceFuncStrings.Empty;

            try
            {
                regex = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+unifieddevelopmentplatform.presentation.api)");
                exeRootDirectory = _serviceFuncStrings.UDPLower(Assembly.GetExecutingAssembly().Location);

                if (regex.IsMatch(exeRootDirectory ?? _serviceFuncStrings.Empty))
                {
                    rootDirectoryOfSolution = regex.Match(exeRootDirectory ?? _serviceFuncStrings.Empty).Value;
                }

                return rootDirectoryOfSolution;
            }
            catch (IOException)
            {
                return _serviceFuncStrings.Empty;
            }
        }

        private void LoadDirectoryRootPath(string rootPath)
        {
            DirectoryRoot.DirectoryRootPath = rootPath;
        }

        private void UDPLoadDirectory(string rootPath)
        {
            _listDirectory.Add(rootPath);
        }

        private void UDPCreateDirectory()
        {
            try
            {
                if (_listDirectory != null && _listDirectory.Any())
                {
                    Parallel.ForEach(_listDirectory, directory =>
                    {
                        if (_serviceFuncStrings.UDPNullOrEmpty(directory))
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Directory.CreateDirectory(directory);
                        }
                    });
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        #region Private Methods.

        [Obsolete("Remove this method", false)]
        /// <summary>
        /// Delete all root directory of solution.
        /// </summary>
        /// <returns></returns>
        private bool UDPDeleteAllRootDirectoryOfSolution(string? rootDirectory)
        {
            try
            {
                if (!_serviceFuncStrings.UDPNullOrEmpty(rootDirectory ?? string.Empty))
                {
                    if (Directory.Exists($"{rootDirectory}{DirectoryStandard.App}"))
                    {
                        Directory.Delete($"{rootDirectory}{DirectoryStandard.App}", true);
                    }
                }
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }

        [Obsolete("Remove this method", false)]
        /// <summary>
        /// Create all root path of solution.
        /// </summary>
        /// <returns></returns>
        private void UDPCreateAllRootPath(Queue<string> queueDirectory)
        {
            try
            {
                if (queueDirectory != null && queueDirectory.Any())
                {
                    foreach (var dir in _queueDirectory)
                    {
                        if (_serviceFuncStrings.UDPNullOrEmpty(dir))
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Directory.CreateDirectory(dir ?? string.Empty);
                        }
                    }
                }
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        #region Presentation.

        /// <summary>
        /// Create root path presentation of solution.
        /// </summary>
        /// <param name="backendFrontend"></param>
        /// <returns></returns>
        private void CreateRootPathPresentation(string[] backendFrontend)
        {
            for (int i = 0; i < backendFrontend.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Properties}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Controllers}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Extensions}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Filters}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Models}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryPresentation.Presentation}{DirectoryPresentation.Swagger}");
            }
        }

        #endregion Presentation.

        #region Application.

        /// <summary>
        /// Create root path application of solution.
        /// </summary>
        /// <param name="backendFrontend"></param>
        /// <returns></returns>
        private void CreateRootPathApplication(string[] backendFrontend)
        {
            for (int i = 0; i < backendFrontend.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.Application}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.Application}{DirectoryApplication.Interfaces}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryApplication.Application}{DirectoryApplication.Services}");
            }
        }

        #endregion Application.

        #region Domain.

        /// <summary>
        /// Create root path domain of solution.
        /// </summary>
        /// <param name="backendFrontend"></param>
        /// <returns></returns>
        private void CreateRootPathDomain(string[] backendFrontend)
        {
            for (int i = 0; i < backendFrontend.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.Domain}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.Domain}{DirectoryDomain.Interfaces}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryDomain.Domain}{DirectoryDomain.Entities}");
            }
        }

        #endregion Domain.

        #region Infrastructure.

        /// <summary>
        /// Create root path infrastructure of solution.
        /// </summary>
        /// <param name="backendFrontend"></param>
        /// <returns></returns>
        private void CreateRootPathInfrastructure(string[] backendFrontend)
        {
            for (int i = 0; i < backendFrontend.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.Infrastructure}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.CrossCutting}");
                _queueDirectory.Enqueue($"{_directory}{backendFrontend[i]}{DirectoryInfrastructure.Infrastructure}{DirectoryInfrastructure.Data}");
            }
        }

        #endregion Infrastructure.

        #endregion Private Methods.
    }
}