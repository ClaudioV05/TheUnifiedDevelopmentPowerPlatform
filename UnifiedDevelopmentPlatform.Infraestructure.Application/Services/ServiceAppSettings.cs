using UnifiedDevelopmentPlatform.Application.Interfaces;
using UnifiedDevelopmentPlatform.Infraestructure.Domain.Entities.AppSetting;

namespace UnifiedDevelopmentPlatform.Application.Services
{
    public class ServiceAppSettings : IServiceAppSettings
    {
        private readonly IServiceFile _serviceFile;
        private readonly IServiceFuncStrings _serviceFuncStrings;
        private readonly IServiceJavaScriptObjectNotation _serviceJavaScriptObjectNotation;

        public ServiceAppSettings(IServiceFile serviceFile, IServiceFuncStrings serviceFuncStrings, IServiceJavaScriptObjectNotation serviceJavaScriptObjectNotation)
        {
            _serviceFile = serviceFile;
            _serviceFuncStrings = serviceFuncStrings;
            _serviceJavaScriptObjectNotation = serviceJavaScriptObjectNotation;
        }

        public void UPDAddAppSettings(string key, string value)
        {
            try
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, AppSetting.FILE_NAME);

                if (!_serviceFuncStrings.NullOrEmpty(filePath) || _serviceFile.UDPFileExists(filePath))
                {
                    string json = _serviceFile.UDPReadAllText(filePath);
                    dynamic jsonObj = _serviceJavaScriptObjectNotation.UDPDesSerializer(json);

                    var sectionPath = key.Split(":")[0];
                    /*
                    if (!string.IsNullOrEmpty(sectionPath))
                    {
                        var keyPath = key.Split(":")[1];
                        jsonObj[sectionPath][keyPath] = value;
                    }
                    else
                    {
                        jsonObj[sectionPath] = value; // if no sectionpath just set the value
                    }
                    */
                    jsonObj["kdkjdkd0"]["dsfsdf"] = "unf";
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);

                    File.WriteAllText("", output);
                }

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}