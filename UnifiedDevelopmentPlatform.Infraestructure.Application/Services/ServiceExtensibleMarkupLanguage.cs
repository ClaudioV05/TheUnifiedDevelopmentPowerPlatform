using System.Xml.Linq;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceExtensibleMarkupLanguage : IServiceExtensibleMarkupLanguage
    {
        private const string UDP_DIRECTORY = "udp_directorys";

        public bool TreeDirectorySave(string path, List<string> items)
        {
            try
            {
                XElement root = new XElement(UDP_DIRECTORY);

                root.Add(new XElement("Child", "child content"));

                root.Save($"{path}\\Root.xml", SaveOptions.None);

                //treeDirectorySaveToXml.Add(new XElement("PM", PossibleModules.Select(s => s.ToXml("M"))));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}