using Newtonsoft.Json.Linq;
using UnifiedDevelopmentPlatform.Application.Interfaces;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceAppSettings : IServiceAppSettings
    {
        private readonly IServiceFile _serviceFile;
        private readonly IServiceJson _serviceJson;

        public ServiceAppSettings(IServiceFile serviceFile, IServiceJson serviceJson, IServiceJson serviceJavaScriptObjectNotation)
        {
            _serviceFile = serviceFile;
            _serviceJson = serviceJson;
        }

        public void UPDAddAppSettings(string path, string key, string value)
        {
            try
            {
                JObject jsonReturn;

                string json = _serviceFile.UDPReadAllText(path);

                if (_serviceJson.ContainsKey(json, key))
                {
                    _serviceJson.RemoveAll(json, key);
                }

                jsonReturn = _serviceJson.AddValue(json, key, value);

                File.WriteAllText(path, jsonReturn.ToString());
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}