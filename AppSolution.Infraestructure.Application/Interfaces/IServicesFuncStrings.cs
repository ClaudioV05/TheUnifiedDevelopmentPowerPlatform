namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IServicesFuncStrings
    {
        string RemoveSpecialCaracter(string text);
        string RemoveAllWhiteSpace(string text);
        string CodifyToBase64(string data);
        string DecodeToBase64(string data);
    }
}