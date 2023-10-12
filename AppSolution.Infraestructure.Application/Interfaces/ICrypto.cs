namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface ICrypto
    {
        string Encrypt(string value);
        string Decrypt(string value);
    }
}