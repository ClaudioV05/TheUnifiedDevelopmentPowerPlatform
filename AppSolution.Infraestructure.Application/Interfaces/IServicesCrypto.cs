namespace AppSolution.Infraestructure.Application.Interfaces
{
    public interface IServicesCrypto
    {
        string Encrypt(string value);
        string Decrypt(string value);
        string DecodeBase64(string value);
    }
}