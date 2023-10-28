using AppSolution.Infraestructure.Application.Interfaces;
using System.Text.Json;

namespace AppSolution.Infraestructure.Application.Services
{
    public class ServiceJson : IServiceJson
    {
        public object DesSerializer(object obj, string json)
        {
            return JsonSerializer.Deserialize<object>(json);
        }

        public string Serializer(object obj)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(obj, options);
        }
    }
}