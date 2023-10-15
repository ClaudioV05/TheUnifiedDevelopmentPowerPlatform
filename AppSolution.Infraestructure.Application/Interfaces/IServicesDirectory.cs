namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IServicesDirectory
    {
        void CreateDefaultDirectory();
        void CreateAppDirectory(string? path);
        void CreateConfigDirectory(string? path);
    }
}