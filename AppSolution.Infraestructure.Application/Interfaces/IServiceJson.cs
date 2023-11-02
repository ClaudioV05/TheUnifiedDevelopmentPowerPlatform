namespace AppSolution.Application.Interfaces
{
    public interface IServiceJson
    {
        string Serializer(object obj);
        object DesSerializer(object obj, string json);
    }
}