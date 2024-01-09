using System.Xml.Linq;
using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.Xml;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    /// <summary>
    /// Service for Extensible Markup Language - XML.
    /// </summary>
    public class ServiceXml : IServiceXml
    {
        private readonly IServiceFuncStrings _serviceFuncStrings;

        /// <summary>
        /// The constructor of Service Extensible Markup Language - XML.
        /// </summary>
        public ServiceXml(IServiceFuncStrings serviceFuncStrings)
        {
            _serviceFuncStrings = serviceFuncStrings;
        }

        public void UPDTreeXmlSave(string path, string nameSection, string item)
        {
            XElement? root = new XElement(nameSection);
            root.Add(new XElement(Xml.ElementName, item));
            root.Save(path, SaveOptions.None);
        }

        public void UPDTreeXmlSave(string path, string nameSection, List<string> items)
        {
            XElement root = new XElement(nameSection);

            for (int i = 0; i < items.Count; i++)
            {
                root.Add(new XElement($"{Xml.ElementName}: {_serviceFuncStrings.UDPSelectSection(items[i])}", items[i]));
            }

            root.Save(path, SaveOptions.None);
        }
    }
}