using System.Reflection;
using System.Text.RegularExpressions;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Directory;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceDirectory : IServiceDirectory
    {
        private string? _directory;
        private readonly Queue<string> _queueDirectory;
        private readonly IServiceFuncStrings _serviceFuncStrings;
        private readonly IServiceLanguageIntegratedQuery _serviceLanguageIntegratedQuery;
        private readonly IServiceExtensibleMarkupLanguage _serviceExtensibleMarkupLanguage;

        public ServiceDirectory(IServiceFuncStrings serviceFuncStrings, IServiceExtensibleMarkupLanguage serviceExtensibleMarkupLanguage, IServiceLanguageIntegratedQuery serviceLanguageIntegratedQuery)
        {
            _queueDirectory = new Queue<string>();
            _serviceFuncStrings = serviceFuncStrings;
            _serviceExtensibleMarkupLanguage = serviceExtensibleMarkupLanguage;
            _serviceLanguageIntegratedQuery = serviceLanguageIntegratedQuery;
        }

        public void UPDCreateAllDirectoryOfSolution()
        {
            string[] directories = new string[] { DirectoryStandard.BACK_END, DirectoryStandard.FRONT_END };

            try
            {
                _directory = this.GetRootDirectoryOfSolution();

                if (!_serviceFuncStrings.NullOrEmpty(_directory ?? string.Empty))
                {
                    if (this.DeleteAllDirectoryOfSolution(_directory))
                    {
                        this.CreatePathApp();

                        this.CreatePathBack();

                        this.CreatePathFront();

                        this.CreatePathConfig();

                        this.CreatePathPresentation(directories);

                        this.CreatePathApplication(directories);

                        this.CreatePathDomain(directories);

                        this.CreatePathInfrastructure(directories);

                        this.CreateAllPath(_queueDirectory);

                        this.FilterAndSavePaths(_queueDirectory);
                    }
                }
            }
            catch (IOException)
            {
                this.DeleteAllDirectoryOfSolution(_directory);
                throw new IOException();
            }
        }

        private bool DeleteAllDirectoryOfSolution(string? rootDirectory)
        {
            try
            {
                if (!_serviceFuncStrings.NullOrEmpty(rootDirectory ?? string.Empty))
                {
                    if (Directory.Exists($"{rootDirectory}{DirectoryStandard.APP}"))
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
            string? rootDirectoryOfSolution = string.Empty;

            try
            {
                string? exeRootDirectory = Assembly.GetExecutingAssembly().Location;
                Regex regex = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+unifieddevelopmentplatform.presentation.api)");
                exeRootDirectory = _serviceFuncStrings.Lower(exeRootDirectory);

                if (regex.IsMatch(exeRootDirectory ?? string.Empty))
                {
                    rootDirectoryOfSolution = regex.Match(exeRootDirectory ?? string.Empty).Value;
                }

                return rootDirectoryOfSolution;
            }
            catch (IOException)
            {
                return string.Empty;
            }
        }

        private void CreateAllPath(Queue<string> queueDirectory)
        {
            try
            {
                if (queueDirectory != null && queueDirectory.Count > 0)
                {
                    foreach (var dir in _queueDirectory)
                    {
                        Directory.CreateDirectory(dir ?? string.Empty);
                    }
                }
            }
            catch (IOException)
            {

            }
        }

        private void FilterAndSavePaths(Queue<string> queueDirectory)
        {
            string directoryDefaultToSave = string.Empty;

            try
            {
                List<string>? lstWithoutAppConfiguration = _serviceLanguageIntegratedQuery.UDPSelectRootPathWithoutAppConfiguration(queueDirectory.ToList());

                List<string>? lstWithAppConfiguration = _serviceLanguageIntegratedQuery.UDPSelectRootPathWithAppConfiguration(queueDirectory.ToList());
                List<string>? lstSectionAppAndConfiguration = _serviceLanguageIntegratedQuery.UDPSelectSectionStandard(lstWithAppConfiguration);

                List<string>? lstSectionFrontend = _serviceLanguageIntegratedQuery.UDPSelectSectionFrontend(lstWithoutAppConfiguration);
                List<string>? lstSectionBackend = _serviceLanguageIntegratedQuery.UDPSelectSectionBackend(lstWithoutAppConfiguration);

                if (lstWithoutAppConfiguration is null || lstWithAppConfiguration is null || lstSectionAppAndConfiguration is null || lstSectionFrontend is null || lstSectionBackend is null)
                {
                    throw new Exception();
                }

                _serviceExtensibleMarkupLanguage.UPDTreeXmlSaveConfigurationFile(lstWithAppConfiguration[1], lstWithAppConfiguration);
                _serviceExtensibleMarkupLanguage.UPDTreeXmlSaveDirectoriesFile(lstWithAppConfiguration[1], lstWithoutAppConfiguration);
            }
            catch (IOException)
            {
                throw new IOException();
            }
        }

        #region Standard Path.
        private void CreatePathApp()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}");
        }

        private void CreatePathConfig()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.CONFIGURATION}");
        }

        private void CreatePathBack()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.BACK_END}");
        }

        private void CreatePathFront()
        {
            _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{DirectoryStandard.FRONT_END}");
        }
        #endregion Standard Path.

        #region Presentation.
        private void CreatePathPresentation(string[] backFront)
        {
            for (int i = 0; i < backFront.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryPresentation.PRESENTATION}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.PROPERTIES}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.CONTROLLERS}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.EXTENSIONS}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.FILTERS}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.MODELS}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryPresentation.PRESENTATION}{DirectoryPresentation.SWAGGER}");
            }
        }
        #endregion Presentation.

        #region Application.
        private void CreatePathApplication(string[] backFront)
        {
            for (int i = 0; i < backFront.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryApplication.APPLICATION}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryApplication.APPLICATION}{DirectoryApplication.INTERFACES}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryApplication.APPLICATION}{DirectoryApplication.SERVICES}");
            }
        }
        #endregion Application.

        #region Domain.
        private void CreatePathDomain(string[] backFront)
        {
            for (int i = 0; i < backFront.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryDomain.DOMAIN}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryDomain.DOMAIN}{DirectoryDomain.INTERFACES}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryDomain.DOMAIN}{DirectoryDomain.ENTITIES}");
            }
        }
        #endregion Domain.

        #region Infrastructure.
        private void CreatePathInfrastructure(string[] backFront)
        {
            for (int i = 0; i < backFront.Length; i++)
            {
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryInfrastructure.INFRASTRUCTURE}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryInfrastructure.INFRASTRUCTURE}{DirectoryInfrastructure.CROSSCUTTING}");
                _queueDirectory.Enqueue($"{_directory}{DirectoryStandard.APP}{backFront[i]}{DirectoryInfrastructure.INFRASTRUCTURE}{DirectoryInfrastructure.DATA}");
            }
        }
        #endregion Infrastructure.
    }
}