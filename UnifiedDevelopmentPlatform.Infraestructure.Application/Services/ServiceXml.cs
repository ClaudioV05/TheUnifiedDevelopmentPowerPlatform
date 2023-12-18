using System.Xml.Linq;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Xml;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceXml : IServiceXml
    {
        private const string UDP_DIRECTORY = "udp_directorys";

        public void UPDTreeXmlSaveConfigurationFile(string path, List<string> items)
        {
            XElement? root = null;

            foreach (string item in items)
            {
                root = new XElement(string.Empty);

                root.Add(new XElement("Teste", item));
            }

            root.Save($"{path}\\{Xml.FILENAME_CONFIGURATION}.xml", SaveOptions.None);
        }

        public void UPDTreeXmlSaveDirectoriesFile(string path, List<string> items)
        {
            XElement root = new XElement(UDP_DIRECTORY);

            root.Add(new XElement("Child", "child content"));
            root.Save($"{path}\\Root.xml", SaveOptions.None);

            //treeDirectorySaveToXml.Add(new XElement("PM", PossibleModules.Select(s => s.ToXml("M"))));
        }
    }
}