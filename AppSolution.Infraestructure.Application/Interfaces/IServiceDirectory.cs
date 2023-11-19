namespace AppSolution.Application.Interfaces
{
    public interface IServiceDirectory
    {
        void CreateDefaultDirectory();

        void CreateAppDirectory(string? path);
        void SaveAppDirectory(string? path);
    }
}