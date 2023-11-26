namespace UnifiedDevelopmentPlatform.Application.Interfaces
{
    public interface IServiceCrypto
    {
        string Encrypt(string value);
        string Decrypt(string value);
        string DecodeBase64(string? value);
    }
}