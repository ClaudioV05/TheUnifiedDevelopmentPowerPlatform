using System.Xml.Linq;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.ExtensibleMarkupLanguage;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceExtensibleMarkupLanguage : IServiceExtensibleMarkupLanguage
    {
        private const string UDP_DIRECTORY = "udp_directorys";

        public void TreeXmlSaveConfigurationFile(string path, List<string> items)
        {
            XElement root = null;

            foreach (string item in items)
            {
                root = new XElement(string.Empty);

                root.Add(new XElement("Teste", item));
            }

            root.Save($"{path}\\{ExtensibleMarkupLanguage.FILENAME_CONFIGURATION}.xml", SaveOptions.None);
        }

        public void TreeXmlSaveDirectoriesFile(string path, List<string> items)
        {
            XElement root = new XElement(UDP_DIRECTORY);

            root.Add(new XElement("Child", "child content"));
            root.Save($"{path}\\Root.xml", SaveOptions.None);

            //treeDirectorySaveToXml.Add(new XElement("PM", PossibleModules.Select(s => s.ToXml("M"))));
        }
    }
}